namespace Persistence.SqliteDB.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<FormulaListGoodIssue> formulaListGoodIssues { get; set; }
    public DbSet<IssueBasket> issueBaskets { get; set; }
    public DbSet<ProcessingGoodExportOrder> processingGoodExportOrders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlite("Data Source=database.db");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
                    .HasKey(s => s.id);
        modelBuilder.Entity<FormulaListGoodIssue>()
                    .HasKey(s => s.Id);
        modelBuilder.Entity<IssueBasket>()
                    .HasKey(s => s.Id);
        modelBuilder.Entity<ProcessingGoodExportOrder>()
                    .HasKey(s => s.Id);
        modelBuilder.Entity<ProcessingGoodExportOrder>()
                    .HasMany<FormulaListGoodIssue>(g => g.formulaListGoodIssues)
                    .WithOne(s => s.ProcessingGoodExportOrder)
                    .HasForeignKey(s => s.ProcessingGoodExportOrderId)
                    .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProcessingGoodExportOrder>()
                   .HasMany<IssueBasket>(g => g.issueBaskets)
                   .WithOne(s => s.ProcessingGoodExportOrder)
                   .HasForeignKey(s => s.ProcessingGoodExportOrderId)
                   .OnDelete(DeleteBehavior.Cascade);
    }

}
