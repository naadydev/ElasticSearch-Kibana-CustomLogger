namespace ElasticSearch
{
    public class CustomActionLog
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
    }

    public enum SysAction
    {
        Add,
        Update,
        Delete,
        View,
        List,
        Patch
    }
}
