namespace NCollaborate.Session
{
    public class SutSession : ISutSession
    {
        public bool IsSutOperationExecuting { get; set; }

        public string CurrentlyExecutingOperationName { get; set; }

        public object[] CurrentlyExecutingOperationArguments { get; set; }
    }
}
