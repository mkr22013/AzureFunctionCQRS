using FluentValidation;

namespace CleanArchitectrure.Application.UseCases.Customers.Queries.GetAllWithPaginationCustomerQuery
{
    /// <summary>
    /// GetAllWithPaginationCustomerValidator
    /// </summary>
    public class GetAllWithPaginationCustomerValidator : AbstractValidator<GetAllWithPaginationCustomerQuery>
    {
        /// <summary>
        /// GetAllWithPaginationCustomerValidator constructor
        /// </summary>
        public GetAllWithPaginationCustomerValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .NotNull()
                .NotEmpty();
        }
    }
}
