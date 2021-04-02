namespace ElasticSearch
{
    public interface IElasticSearchHelper
    {
        ESresult AddNewDocument(CustomActionLog log);
    }
}
