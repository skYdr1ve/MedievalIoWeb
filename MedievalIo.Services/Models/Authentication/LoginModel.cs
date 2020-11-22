using System.ComponentModel.DataAnnotations;

namespace MedievalIo.Services.Models.Authentication
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
