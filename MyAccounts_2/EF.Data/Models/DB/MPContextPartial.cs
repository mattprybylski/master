using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Models.DB
{
    public partial class MpContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=mp;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
 
    }
}
