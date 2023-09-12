using IronForgeFitness.Domain.Abstractions;
using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.Domain.Entities
{
    /// <summary>
    /// Represents the entity that identify the user
    /// </summary>
    public class Account : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.None;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
