using System.ComponentModel.DataAnnotations;

namespace lab9.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression("[a-zA-Zа-яА-Я]{1,20}", ErrorMessage = "Только буквы")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression("[a-zA-Zа-яА-Я]{1,20}", ErrorMessage = "Только буквы")]
        public string LastName { get; set; }

        [RegularExpression("[a-zA-Zа-яА-Я]{1,100}", ErrorMessage = "Только буквы")]
        public string City { get; set; }

        public string Date { get; set; }

        [RegularExpression("[1234567890]", ErrorMessage = "Только цифры")]
        public int Age { get; set; }
    }
}