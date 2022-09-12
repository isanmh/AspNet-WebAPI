using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? NamaBuku { get; set; }
        public string? JenisBuku { get; set; }
    }
}