using Nest;
using System;

namespace ElasticSearch
{

    public class ElasticSearchHelper : IElasticSearchHelper
    {
        private readonly ConnectionSettings _esSettings;
        private readonly ElasticClient _esClient;
        private readonly string _esURL;
        private readonly string _indexName;

        public ElasticSearchHelper()
        {

        }

        public ElasticSearchHelper(string eSUrl, string indexName)
        {
            _esURL = eSUrl;
            _indexName = indexName;
            _esSettings = new ConnectionSettings(new Uri(_esURL)).DefaultIndex(_indexName);
            _esClient = new ElasticClient(_esSettings);

            CreateIndexIfNotExists();
        }

        private CreateIndexResponse CreateIndexIfNotExists()
        {
            if (!_esClient.Indices.Exists(_indexName).Exists)
                return _esClient.Indices.Create(_indexName, index => index.Map<CustomActionLog>(x => x.AutoMap()));
            else
                return null;
        }

        public ESresult AddNewDocument(CustomActionLog log)
        {
            var indexResponse = _esClient.IndexDocument(log);

            if (indexResponse.IsValid && indexResponse.Result == Result.Created)
                return new ESresult { Succeeded = true, Id = indexResponse.Id };
            else
                return new ESresult { Succeeded = false, Id = "0" };
        }
    }

    public class ESresult
    {
        public bool Succeeded { get; set; }
        public string Id { get; set; }
    }

}
