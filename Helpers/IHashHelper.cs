namespace AkodoAPI.Helpers
{
    public interface IHashHelper
    {
        string Hash(string value);
        bool Verify(string hashValue, string value);
    }
}