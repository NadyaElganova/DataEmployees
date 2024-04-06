using System.ComponentModel.DataAnnotations;

namespace DataEmployees.Models
{
    public class Employee 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите Имя и Отчество работника (при наличии)")]
        [MaxLength(40)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Введите Фамилию работника")]
        [MaxLength(50)]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Введите серию паспорта")]
        [MaxLength(4)]
        public string SeriesPassport { get; set; }
        [Required(ErrorMessage = "Введите номер паспорта")]
        [MaxLength(6)]
        public string NumberPassport { get; set; }
        [Required(ErrorMessage = "Введите дату рождения работника")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public Organization Organization { get; set; }
    }
}