using CSC.NotesMgnt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.NotesMgnt.Infrastructure
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) 
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
