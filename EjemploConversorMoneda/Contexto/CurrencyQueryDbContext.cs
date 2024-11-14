
namespace EjermploConversorMoneda.Contexto;

public class CurrencyQueryDbContext : DbContext {

    public DbSet<CurrencyQuery> CurrencyQueries { get; set; }

    public CurrencyQueryDbContext(DbContextOptions<CurrencyQueryDbContext> options)
        : base(options) {
    }
}
