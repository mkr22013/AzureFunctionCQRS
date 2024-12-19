using FluentValidation;

namespace CleanArchitectrure.Application.UseCases.Customers.Commands.CreateCustomerCommand
{
    /// <summary>
    /// CreateCustomerValidator
    /// </summary>
    public class CreateCustomerValidator: AbstractValidator<CreateCustomerCommand>
    {
        /// <summary>
        /// CreateCustomerValidator constructor
        /// </summary>
        public CreateCustomerValidator()
        {
            //RuleFor(x => x.CustomerId).NotEmpty().NotNull().MinimumLength(1).MaximumLength(5);
            RuleFor(x => x.ContactName).NotEmpty().NotNull();
            RuleFor(x => x.Phone).NotEmpty().NotNull();
            RuleFor(x => x.Region).NotEmpty().NotNull();
        }
    }
}
