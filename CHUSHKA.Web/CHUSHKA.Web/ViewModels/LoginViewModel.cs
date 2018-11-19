using System.ComponentModel.DataAnnotations;

namespace CHUSHKA.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {1} and at most {2} characters long.", MinimumLength = 3)]
        public string Password { get; set; }
    }
}