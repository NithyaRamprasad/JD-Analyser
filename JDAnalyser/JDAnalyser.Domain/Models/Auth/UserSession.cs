namespace JDAnalyser.Domain.Models.Auth
{
    public record UserSession(
        int UserId,
        IReadOnlyList<string> Roles
    );
}
