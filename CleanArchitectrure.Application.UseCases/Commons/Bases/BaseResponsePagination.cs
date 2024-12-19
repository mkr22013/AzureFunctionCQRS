namespace CleanArchitectrure.Application.UseCases.Commons.Bases
{
    /// <summary>
    /// BaseResponsePagination
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponsePagination<T>: BaseReponseGeneric<T>
    {
        /// <summary>
        /// PageNumber
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// PageSize
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// TotalCount
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// HasPreviousPage
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;
        /// <summary>
        /// HasNextPage
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
