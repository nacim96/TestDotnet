using System.ComponentModel.DataAnnotations;
namespace testpfe.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }

    /*  [StringLength(5)]
         [DataType(DataType.Date)] 
         [DataType(DataType.Currency)] 
         [Range(1, 100)]

         // [DataType(DataType.EmailAddress)]
          [EmailAddress]//
*/

}