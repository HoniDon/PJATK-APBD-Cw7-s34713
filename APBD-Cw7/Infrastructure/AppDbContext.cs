using Microsoft.EntityFrameworkCore;

namespace APBD_Cw7.Infrastructure;

public class AppDbContext(DbContextOptions opt) : DbContext(opt)
{
    
}