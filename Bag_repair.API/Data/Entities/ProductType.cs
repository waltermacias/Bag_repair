using System.ComponentModel.DataAnnotations;

namespace Bag_repair.API.Data.Entities
{
     public class ProductType
     {
          public int Id { get; set; }

          [Display(Name = "Tipo de Producto")]
          [MaxLength(50, ErrorMessage = "El campo {0} no puede tenner más de {1} carácteres")]
          [Required(ErrorMessage = "El campo {0} es obligatorio.")]
          public string Description { get; set; }
     }
}
