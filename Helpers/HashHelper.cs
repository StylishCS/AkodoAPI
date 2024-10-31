namespace AkodoAPI.Helpers
{
    using BCrypt.Net;
    public class HashHelper : IHashHelper
    {
        public string Hash(string value)
        {
            return BCrypt.HashString(value);
        }

        public bool Verify(string value, string hashValue)
        {
            return BCrypt.Verify(value, hashValue);
        }
    }
}
