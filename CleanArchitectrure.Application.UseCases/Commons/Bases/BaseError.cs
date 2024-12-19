namespace CleanArchitectrure.Application.UseCases.Commons.Bases
{
    /// <summary>
    /// BaseError
    /// </summary>
    public class BaseError
    {
        /// <summary>
        /// PropertyName
        /// </summary>
        public string? PropertyMessage { get; set; }
        /// <summary>
        /// ErrorMessage
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}
