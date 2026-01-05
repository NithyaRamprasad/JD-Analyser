namespace JDAnalyser.Application.Interfaces.Common
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string? Username { get; }
        IReadOnlyCollection<string> Roles { get; }
        bool IsAuthenticated { get; }
    }
}
