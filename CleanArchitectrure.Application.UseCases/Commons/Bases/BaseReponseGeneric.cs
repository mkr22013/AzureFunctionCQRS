namespace CleanArchitectrure.Application.UseCases.Commons.Bases
{
    /// <summary>
    /// BaseReponseGeneric
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseReponseGeneric<T>
    {
        /// <summary>
        /// succcess
        /// </summary>
        public bool Succcess { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public T? Data { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// Errors
        /// </summary>
        public IEnumerable<BaseError>? Errors { get; set; }
    }
}
