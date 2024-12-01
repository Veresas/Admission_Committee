using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Contracts.Models;
using System.Runtime.Remoting.Contexts;


namespace Database
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ConectStr")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
