using System.ComponentModel.DataAnnotations;

namespace DataEmployees.Models
{
    public class Organization: IExportableToCsv
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите наименование организации")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите Инн организации")]
        [MaxLength(10)]
        public string Inn { get; set; }
        [Required(ErrorMessage = "Введите юр.адрес организации")]
        [MaxLength(50)]
        public string LegalAdress { get; set; }
        [Required(ErrorMessage = "Введите фактический адрес организации")]
        [MaxLength(50)]
        public string ActualAdress { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public string ToCsvString()
        {
            return $"{Name},{Inn},{LegalAdress},{ActualAdress}";
        }
    }
}
