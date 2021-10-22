using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPhilosopher.Models
{
    public class Philosopher
    {
        [Key]
        public int Id {get;set;}
        [Required]
        [StringLength(100)]
        [Display(Name = "First_Name")]
        public string First {get;set;}
        [Required]
        [StringLength(100)]
        [Display(Name = "Last_Name")]
        public string Last {get;set;}
        [Required]
        [StringLength(200)]
        public string Field {get;set;}
        [Required]
        [StringLength(100)]
        [Display(Name = "Invented")]
        public string Invention {get;set;}
        [Required]
        [StringLength(100)]
        [Display(Name = "Country_Of_Origin")]
        public string Country {get;set;}
        [Required]
        public int Age {get;set;}
        public string Image {get;set;}
    }
}