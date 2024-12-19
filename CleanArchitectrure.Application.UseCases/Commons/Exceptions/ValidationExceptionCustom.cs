using CleanArchitectrure.Application.UseCases.Commons.Bases;

namespace CleanArchitectrure.Application.UseCases.Commons.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class ValidationExceptionCustom : Exception
    {
        /// <summary>
        /// List of errors
        /// </summary>
        public IEnumerable<BaseError?> Errors { get; }

        /// <summary>
        /// Creates a new instance of <see cref="ValidationExceptionCustom"/>
        /// </summary>
        public ValidationExceptionCustom()
            : base("One or more validation failures have occured.")
        {
            Errors = [];
        }

        /// <summary>
        /// Creates a new instance of <see cref="ValidationExceptionCustom"/>
        /// </summary>
        /// <param name="errors"></param>
        public ValidationExceptionCustom(IEnumerable<BaseError?> errors)
            : this()
        {
            Errors = errors;
        }
    }
}
