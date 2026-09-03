using DigitalTwinWorkOrderService.Models.WorkOrders;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Namespace <c>DigitalTwinWorkOrderService.WorkOrderProcessor.Data</c> contains the database access layer operations for the application.
/// </summary>
namespace DigitalTwinWorkOrderService.WorkOrderProcessor.Data
{
    /// <summary>
    /// Class <c>WorkOrderProcessorDbContext</c> represents the data access layer context for the Work Order Processor.
    /// <remarks>
    /// Inherits from DbContext <see cref="DbContext"/>
    /// </remarks>
    /// </summary>
    public class WorkOrderProcessorDbContext : DbContext
    {
        public WorkOrderProcessorDbContext(DbContextOptions<WorkOrderProcessorDbContext> options) : base(options)
        {
        }

        public DbSet<WorkOrderEvent> WorkOrderEvents { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }

        public DbSet<WorkOrderHistory> WorkOrderHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
