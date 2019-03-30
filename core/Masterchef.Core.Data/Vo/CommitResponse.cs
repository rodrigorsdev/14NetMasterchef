namespace Masterchef.Core.Data.Vo
{
    public class CommitResponse
    {
        public static CommitResponse Ok = new CommitResponse { Success = true };
        public static CommitResponse Fail = new CommitResponse { Success = false };

        public CommitResponse(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}