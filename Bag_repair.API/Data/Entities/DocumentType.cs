using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Bag_repair.API.Data.Entities
{
     public class DocumentType
     {
          public int Id { get; set; }

          [Display(Name = "Tipo de Documento")]
          [MaxLength(50, ErrorMessage = "El campo {0} no puede tenner más de {1} carácteres")]
          [Required(ErrorMessage = "El campo {0} es obligatorio.")]
          public string Description { get; set; }
     }
}
