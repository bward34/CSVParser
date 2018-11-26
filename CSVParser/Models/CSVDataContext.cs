/*
    CSVDataContext.cs
    Author: Brandon Ward
    Last update: 11/26/2018

    This class is the DBContext for the orders
    and tickets table in the database. This contains
    two DbSets for CRUD opertaions.
*/
using Microsoft.EntityFrameworkCore;
namespace CSVParser.Models
{
    public class CSVDataContext : DbContext
    {
        public CSVDataContext(DbContextOptions<CSVDataContext> options)
          : base(options)
        {
        }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
    }
}
