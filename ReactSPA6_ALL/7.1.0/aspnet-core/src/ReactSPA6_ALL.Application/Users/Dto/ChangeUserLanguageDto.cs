using System.ComponentModel.DataAnnotations;

namespace ReactSPA6_ALL.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}