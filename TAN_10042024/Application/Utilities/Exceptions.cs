namespace TAN_10042024.Application.Utilities
{
    public class Exceptions
    {
        /// <summary>
        /// General error occured.
        /// </summary>
        public class ApiException : Exception
        {
            /// <param name="message">Exception message</param>
            /// <param name="innerException">Inner exception</param>
            public ApiException(string message = null, Exception innerException = null) : base(message, innerException) { }
        }

        /// <summary>
        /// Repository doing database stuff(s) error occured against the builder.
        /// </summary>
        public class RepositoryException : Exception
        {
            /// <param name="message">Exception message</param>
            public RepositoryException(string message = null, Exception innerException = null) : base(message, innerException) { }
        }
    }
}
