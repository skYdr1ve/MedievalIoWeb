using System.ComponentModel.DataAnnotations;

namespace MedievalIo.Services.Models.Authentication
{
    public class RegistrationModel
    {
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
