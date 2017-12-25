using System.ComponentModel.DataAnnotations;

namespace Vig.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name {get; set;}
        public Make Make { get; set; }
        public int MakeID { get; set; }
    }
}