using FluentValidation;

namespace CleanArchitectrure.Application.UseCases.Customers.Queries.GetByIdCustomerQuery
{
    /// <summary>
    /// Validator for GetByIdCustomerQuery
    /// </summary>
    public class GetByIdCustomerValidator: AbstractValidator<GetByIdCustomerQuery>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GetByIdCustomerValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(36);
        }
    }
}
