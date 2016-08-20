using CryptTool = BCrypt.Net.BCrypt;
namespace WeQuestion.Common
{
    public static class PasswordHashing
    {
        private const int _workfactor = 12;

        public static string Hash(string password)
        {
            return CryptTool.HashPassword(password, CryptTool.GenerateSalt(_workfactor));
        }

        public static bool Validate(string password, string passwordHash)
        {
            return CryptTool.Verify(password, passwordHash);
        }
    }
}
