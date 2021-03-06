using System.ComponentModel.DataAnnotations;

namespace Bag_repair.API.Data.Entities
{
     public class Procedure
     {
          public int Id { get; set; }

          [Display(Name = "Procedimiento")]
          [MaxLength(50, ErrorMessage = "El campo {0} no puede tenner más de {1} carácteres")]
          [Required(ErrorMessage = "El campo {0} es obligatorio.")]
          public string Description { get; set; }

          [Display(Name = "Comentarios")]
          [Required(ErrorMessage = "El campo {0} es obligatorio.")]
          public string Remarks { get; set; }

          [Display(Name = "Precio")]
          [DisplayFormat(DataFormatString = "{0:C2}")]
          [Required(ErrorMessage = "El campo {0} es obligatorio.")]
          public decimal Price { get; set; }
     }
}
