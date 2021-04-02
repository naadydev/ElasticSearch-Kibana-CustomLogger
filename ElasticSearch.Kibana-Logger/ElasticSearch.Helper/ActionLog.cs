namespace ElasticSearch
{
    public class CustomActionLog
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
        // 3 points 
        // Put the latest emplyeer first 
        // More than 8 years leading teams 
        // Reasearch center Team Lead (how many people , and tech)
        // 
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
