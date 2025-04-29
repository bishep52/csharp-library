using System.ComponentModel.DataAnnotations;

namespace DB_connect.Models
{
    public class Reader
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле 'Фамилия' обязательно для заполнения")]
        public string SecondName { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
