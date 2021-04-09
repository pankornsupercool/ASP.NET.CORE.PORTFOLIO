using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.CRUD.Models
{
    public class Todolist
    {
        [Key]
        public int TodolistId { get; set; }
        [Column(TypeName= "nvarchar(50)")]
        [Required(ErrorMessage ="Title is required")]
        [DisplayName("Todo Title")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(400)")]
        [Required(ErrorMessage = "Content is required")]
        [DisplayName("What stuff you want to get it done ?")]
        public string Content { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("How long would you spend time to it ?")]
        public string Period { get; set; }
    }
}
