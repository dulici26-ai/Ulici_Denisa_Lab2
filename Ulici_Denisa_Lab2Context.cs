using Microsoft.EntityFrameworkCore;

public class Ulici_Denisa_Lab2Context(DbContextOptions<Ulici_Denisa_Lab2Context> options) : DbContext(options)
{
    public DbSet<Ulici_Denisa_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Ulici_Denisa_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Ulici_Denisa_Lab2.Models.Author> Author { get; set; } = default!;
}
