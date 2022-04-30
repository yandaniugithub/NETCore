using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yak.EFCore.DB.Model;

namespace Yak.EFCore.DB
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// 重写父类的方法 用于连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;database=CapDb;uid=sa;pwd=sa123456");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sys_User>(entity => {
                entity.Property(t => t.Password).HasDefaultValue("123456");
            });
            modelBuilder.Entity<Sys_UserInfoDetails>(entity => {
                entity.HasOne(t => t.Userinfo)
                .WithMany(t => t.UserInfoDetails)
                .HasForeignKey(t => t.UserId); //外键
            });

        }
        public DbSet<Sys_User> Users { get; set; }
        public DbSet<Sys_UserInfoDetails> UserInfoDetails { get; set; }
        
    }
}

