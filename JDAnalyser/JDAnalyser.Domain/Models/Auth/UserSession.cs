namespace JDAnalyser.Domain.Models.Auth
{
    public record UserSession(
        string UserId,
        IReadOnlyList<string> Roles
    );
}
