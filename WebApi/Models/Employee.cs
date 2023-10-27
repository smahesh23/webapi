using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Data;

namespace WebApi.Models
{
    public class Employee:IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key()]
        public int Id { get; set; }
        
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Company { get; set; }
        public string? Role { get; set; }
        public string? City { get; set; }
        //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
