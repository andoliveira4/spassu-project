using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "O Campo ProductName é obrigatório")]
        [StringLength(100, ErrorMessage = "ProductName não pode conter mais de 100 characteres")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "O Campo ProductQuantity é obrigatório")]
        [Range(1, 1000, ErrorMessage = "ProductQuantity não pode ser superior a 1000")]
        public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "O Campo ProductPrice é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "ProductPrice must be greater than 0")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "O Campo Active é obrigatório")]
        public bool Active {get; set; }
    }
}