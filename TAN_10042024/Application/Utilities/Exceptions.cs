namespace TAN_10042024.Application.Utilities {
    public class Exceptions {
        /// <summary>
        /// General error occured.
        /// </summary>
        public class ApiException : Exception {
            /// <param name="message">Exception message</param>
            /// <param name="innerException">Inner exception</param>
            public ApiException(string message = null, Exception innerException = null) : base(message, innerException) { }
        }

        /// <summary>
        /// Business Logic error occured.
        /// </summary>
        public class ServiceException : Exception {
            //public class ServiceException(Exception innerException = null) : base(innerException) { }
            /// <param name="message">Exception message</param>
            /// <param name="innerException">Inner Exception</param>
            public ServiceException(string message = null, Exception innerException = null) : base(message, innerException) { }
        }

        /// <summary>
        /// Repository doing database stuff(s) error occured.
        /// </summary>
        public class RepositoryException : Exception {
            /// <param name="message">Exception message</param>
            /// <param name="innerException">Inner Exception</param>
            public RepositoryException(string message = null, Exception innerException = null) : base(message, innerException) { }
        }
    }
}
