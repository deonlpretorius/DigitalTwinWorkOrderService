using DigitalTwinWorkOrderService.Models.WorkOrders;

/// <summary>
/// Namespace <c>DigitalTwinWorkOrderProcessor.Interfaces</c> contains the contract for managing background tasks.
/// </summary>
namespace DigitalTwinWorkOrderProcessor.Interfaces
{
    /// <summary>
    /// Interface <c>IQueueService</c> represents the contract for the Queue Service.
    /// </summary>
    public interface IQueueService<T>
    {
        void Enqueue(T workOrderEvent);
        bool TryDequeue(out T workOrderEvent);
    }
}
