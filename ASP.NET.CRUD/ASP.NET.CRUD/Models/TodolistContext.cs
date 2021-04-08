using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ASP.NET.CRUD.Models
{
    public class TodolistContext : DbContext
    {
        public TodolistContext(DbContextOptions<TodolistContext> options):base(options)
        {
             
        }

        public DbSet<Todolist> Todolists { get; set; }
    }
}
