using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "O Campo Name é obrigatório")]
        [StringLength(100, ErrorMessage = "Name não pode conter mais de 100 characteres")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O Campo Quantity é obrigatório")]
        [Range(1, 1000, ErrorMessage = "Quantidade não pode ser superior a 1000")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "O Campo Price é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O Campo Active é obrigatório")]
        public bool Active {get; set; }
    }
}