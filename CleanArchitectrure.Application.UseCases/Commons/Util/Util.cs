using CleanArchitectrure.Application.UseCases.Commons.Bases;

namespace CleanArchitectrure.Application.UseCases.Commons.Util
{
    /// <summary>
    /// Utility Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal static class Util<T>
    {
        /// <summary>
        /// Generic error response
        /// </summary>
        /// <param name="response"></param>
        /// <param name="ex"></param>
        internal static void GenerateError(BaseResponse<T> response, Exception ex)
        {
            var lstErrors = new List<BaseError>();
            var error = new BaseError() { ErrorMessage = Convert.ToString(ex.Message) };
            lstErrors.Add(error);
            response.Errors = lstErrors;
            response.Message = ex.Message;
        }
    }
}
