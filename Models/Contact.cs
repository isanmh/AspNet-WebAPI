using System.ComponentModel.DataAnnotations;
namespace RestApi.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public long Phone { get; set; }
        public string? Address { get; set; }
    }
}