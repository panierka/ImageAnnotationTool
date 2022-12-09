namespace Security.Hashing
{
    public interface IHashingFunctionProvider
    {
        public string Hash(string text);
    }
}