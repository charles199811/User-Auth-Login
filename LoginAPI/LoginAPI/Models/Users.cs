using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string first_name { get; set; }

        public string last_name { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string token { get; set; }

        public string email { get; set; }
    }
}
