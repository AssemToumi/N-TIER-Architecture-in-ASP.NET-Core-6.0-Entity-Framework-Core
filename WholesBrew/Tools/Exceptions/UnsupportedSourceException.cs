namespace Helper
{
    [Serializable]
    public class UnsupportedSourceException : EntityNotFoundException
    {
        public UnsupportedSourceException(string source)
            : base($"The specified source <{source}> is not supported!")
        {
        }
    }
}
