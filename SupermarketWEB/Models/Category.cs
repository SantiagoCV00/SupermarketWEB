namespace SupermarketWEB.Models
{
    public class Category
    {
        public int Id { get; set; } // Será la llave primaria
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Category>? Categories { get; set; } = default!; // Propiedad de navegación
    }
}