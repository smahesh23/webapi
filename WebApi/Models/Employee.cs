﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key()]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Company { get; set; }
        public string? Role { get; set; }
        public string? City { get; set; }
    }
}
