using Microsoft.EntityFrameworkCore;
using OMS_Abp.Domain.Entities;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace OMS_Abp.EntityFrameworkCore;

[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class OMS_AbpDbContext :
    AbpDbContext<OMS_AbpDbContext>,
    ITenantManagementDbContext,
    ISettingManagementDbContext
{
    #region Entities from the modules
    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<SettingDefinitionRecord> SettingDefinitionRecords { get; set; }
    #endregion

    #region Northwind entities
    public DbSet<Category> Categories { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }

    public DbSet<CustomerDemographic> CustomerDemographics { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Region> Regions { get; set; }

    public DbSet<Shipper> Shippers { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Territory> Territories { get; set; }
    #endregion

    public OMS_AbpDbContext(DbContextOptions<OMS_AbpDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region modules
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        #endregion

        #region entities
        builder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "Categories_CategoryName");

            entity.Property(e => e.Id).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Picture).HasColumnType("image");
        });

        builder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.City, "Customers_City");

            entity.HasIndex(e => e.CompanyName, "Customers_CompanyName");

            entity.HasIndex(e => e.PostalCode, "Customers_PostalCode");

            entity.HasIndex(e => e.Region, "Customers_Region");

            entity.Property(e => e.Id)
                .HasColumnType("nchar(5)")
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(60)");
            entity.Property(e => e.City)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.CompanyName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(40)");
            entity.Property(e => e.ContactName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(30)");
            entity.Property(e => e.ContactTitle)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(30)");
            entity.Property(e => e.Country)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.Fax)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(24)");
            entity.Property(e => e.Phone)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(24)");
            entity.Property(e => e.PostalCode)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(10)");
            entity.Property(e => e.Region)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
        });

        builder.Entity<CustomerCustomerDemo>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.CustomerTypeId });

            entity.ToTable("CustomerCustomerDemo");

            entity.Property(e => e.CustomerId)
                .HasColumnType("nchar(5)")
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerTypeId)
                .UseCollation("NOCASE")
                .HasColumnType("nchar(10)")
                .HasColumnName("CustomerTypeID");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerCustomerDemos)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CustomerType).WithMany(p => p.CustomerCustomerDemos)
                .HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        builder.Entity<CustomerDemographic>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId);

            entity.Property(e => e.CustomerTypeId)
                .HasColumnType("nchar(10)")
                .HasColumnName("CustomerTypeID");
            entity.Property(e => e.CustomerDesc).HasColumnType("ntext");
        });

        builder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.LastName, "Employees_LastName");

            entity.HasIndex(e => e.PostalCode, "Employees_PostalCode");

            entity.Property(e => e.Id).HasColumnName("EmployeeID");
            entity.Property(e => e.Address)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(60)");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.Country)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.Extension)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(4)");
            entity.Property(e => e.FirstName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(10)");
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.HomePhone)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(24)");
            entity.Property(e => e.LastName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(20)");
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.Photo).HasColumnType("image");
            entity.Property(e => e.PhotoPath)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(255)");
            entity.Property(e => e.PostalCode)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(10)");
            entity.Property(e => e.Region)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.ReportsTo).HasColumnType("INT");
            entity.Property(e => e.Title)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(30)");
            entity.Property(e => e.TitleOfCourtesy)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(25)");

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation).HasForeignKey(d => d.ReportsTo);
        });

        builder.Entity<EmployeeTerritory>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.TerritoryId });

            entity.Property(e => e.EmployeeId)
                .HasColumnType("INT")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.TerritoryId)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(20)")
                .HasColumnName("TerritoryID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Territory).WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.TerritoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        builder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "Orders_CustomerID");

            entity.HasIndex(e => e.CustomerId, "Orders_CustomersOrders");

            entity.HasIndex(e => e.EmployeeId, "Orders_EmployeeID");

            entity.HasIndex(e => e.EmployeeId, "Orders_EmployeesOrders");

            entity.HasIndex(e => e.OrderDate, "Orders_OrderDate");

            entity.HasIndex(e => e.ShipPostalCode, "Orders_ShipPostalCode");

            entity.HasIndex(e => e.ShippedDate, "Orders_ShippedDate");

            entity.HasIndex(e => e.ShipVia, "Orders_ShippersOrders");

            entity.Property(e => e.Id).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .UseCollation("NOCASE")
                .HasColumnType("nchar(5)")
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("INT")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Freight)
                .HasDefaultValue(0.0)
                .HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(60)");
            entity.Property(e => e.ShipCity)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.ShipCountry)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.ShipName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(40)");
            entity.Property(e => e.ShipPostalCode)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(10)");
            entity.Property(e => e.ShipRegion)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.ShipVia).HasColumnType("INT");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders).HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders).HasForeignKey(d => d.ShipVia);
        });

        builder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.HasIndex(e => e.OrderId, "Order Details_OrderID");

            entity.HasIndex(e => e.OrderId, "Order Details_OrdersOrder_Details");

            entity.HasIndex(e => e.ProductId, "Order Details_ProductID");

            entity.HasIndex(e => e.ProductId, "Order Details_ProductsOrder_Details");

            entity.Property(e => e.OrderId)
                .HasColumnType("INT")
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasColumnType("INT")
                .HasColumnName("ProductID");
            entity.Property(e => e.Quantity)
                .HasDefaultValue((short)1)
                .HasColumnType("smallint");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        builder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "Products_CategoriesProducts");

            entity.HasIndex(e => e.CategoryId, "Products_CategoryID");

            entity.HasIndex(e => e.ProductName, "Products_ProductName");

            entity.HasIndex(e => e.SupplierId, "Products_SupplierID");

            entity.HasIndex(e => e.SupplierId, "Products_SuppliersProducts");

            entity.Property(e => e.Id).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasColumnType("INT")
                .HasColumnName("CategoryID");
            entity.Property(e => e.Discontinued).HasColumnType("bit");
            entity.Property(e => e.ProductName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(40)");
            entity.Property(e => e.QuantityPerUnit)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(20)");
            entity.Property(e => e.ReorderLevel)
                .HasDefaultValue((short)0)
                .HasColumnType("smallint");
            entity.Property(e => e.SupplierId)
                .HasColumnType("INT")
                .HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice)
                .HasDefaultValue(0.0)
                .HasColumnType("money");
            entity.Property(e => e.UnitsInStock)
                .HasDefaultValue((short)0)
                .HasColumnType("smallint");
            entity.Property(e => e.UnitsOnOrder)
                .HasDefaultValue((short)0)
                .HasColumnType("smallint");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products).HasForeignKey(d => d.SupplierId);
        });

        builder.Entity<Region>(entity =>
        {
            entity.ToTable("Region");

            entity.Property(e => e.RegionId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("RegionID");
            entity.Property(e => e.RegionDescription)
                .UseCollation("NOCASE")
                .HasColumnType("nchar(50)");
        });

        builder.Entity<Shipper>(entity =>
        {
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(40)");
            entity.Property(e => e.Phone)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(24)");
        });

        builder.Entity<Supplier>(entity =>
        {
            entity.HasIndex(e => e.CompanyName, "Suppliers_CompanyName");

            entity.HasIndex(e => e.PostalCode, "Suppliers_PostalCode");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(60)");
            entity.Property(e => e.City)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.CompanyName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(40)");
            entity.Property(e => e.ContactName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(30)");
            entity.Property(e => e.ContactTitle)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(30)");
            entity.Property(e => e.Country)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
            entity.Property(e => e.Fax)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(24)");
            entity.Property(e => e.HomePage).HasColumnType("ntext");
            entity.Property(e => e.Phone)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(24)");
            entity.Property(e => e.PostalCode)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(10)");
            entity.Property(e => e.Region)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(15)");
        });

        builder.Entity<Territory>(entity =>
        {
            entity.Property(e => e.TerritoryId)
                .HasColumnType("nvarchar(20)")
                .HasColumnName("TerritoryID");
            entity.Property(e => e.RegionId)
                .HasColumnType("INT")
                .HasColumnName("RegionID");
            entity.Property(e => e.TerritoryDescription)
                .UseCollation("NOCASE")
                .HasColumnType("nchar(50)");

            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        #endregion
    }
}