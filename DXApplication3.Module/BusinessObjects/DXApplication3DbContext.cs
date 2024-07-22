using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace DXApplication3.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class DXApplication3ContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<DXApplication3EFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new DXApplication3EFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class DXApplication3DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DXApplication3EFCoreDbContext> {
	public DXApplication3EFCoreDbContext CreateDbContext(string[] args) {
		//throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
		var optionsBuilder = new DbContextOptionsBuilder<DXApplication3EFCoreDbContext>();
		optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DXApplication3");
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
		return new DXApplication3EFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(DXApplication3ContextInitializer))]
public class DXApplication3EFCoreDbContext : DbContext {
	public DXApplication3EFCoreDbContext(DbContextOptions<DXApplication3EFCoreDbContext> options) : base(options) {

	}
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<Employee> Employees { get; set; }
    //public DbSet<ModuleInfo> ModulesInfo { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.SetOneToManyAssociationDeleteBehavior(DeleteBehavior.SetNull, DeleteBehavior.Cascade);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
    }
}
