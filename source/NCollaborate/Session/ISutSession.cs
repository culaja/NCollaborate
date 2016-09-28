namespace NCollaborate.Session
{
    public interface ISutSession
    {
        bool IsSutOperationExecuting { get; set; }

        string CurrentlyExecutingOperationName { get; set; }

        object[] CurrentlyExecutingOperationArguments { get; set; }
    }
}
