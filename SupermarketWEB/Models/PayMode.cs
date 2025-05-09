using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    public class PayMode
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")] // Data Annotation para validación
        public string Name { get; set; }
    }
}
