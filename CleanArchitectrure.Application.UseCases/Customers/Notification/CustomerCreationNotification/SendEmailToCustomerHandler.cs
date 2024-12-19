using CleanArchitectrure.Domain.Events;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Customers.Notification.CustomerCreationNotification
{
    /// <summary>
    /// Notification handler for sending email post successful customer creation to customer
    /// </summary>
    public class SendEmailToCustomerHandler : INotificationHandler<CustomerCreatedEvent>
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
            Console.WriteLine($"Notification Triggered, Email has been sent to customer for successful profile creation : {notification.ContactName}");
            return Task.CompletedTask;
        }
    }
}
