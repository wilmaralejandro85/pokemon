namespace Servicios.Core.Interfaces
{
    public interface IPasswordHelper
    {
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public bool ValidateToken(string token, out Guid userId, out string userRoles);
    }
}
