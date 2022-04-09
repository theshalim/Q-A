using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QA.Areas.MasterData.Models;
using QA.Models;

namespace QA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<qa> qa { get; set; }
        public DbSet<MasterData> MasterDatas { get; set; }
        public DbSet<Category> Categorys { get; set; }
    }
}
