using CleanArchitectrure.Domain.Events;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Customers.Notification.UserRegistrationNotification
{
    /// <summary>
    /// Notification handler for new customer created
    /// </summary>
    public class CustomerCreatedNotificationhandler : INotificationHandler<CustomerCreatedEvent>
    {
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // other processing or logic
            Console.WriteLine($"Notification Triggered, New Customer is created : {notification.ContactName}");
            return Task.CompletedTask;
        }
    }
}
