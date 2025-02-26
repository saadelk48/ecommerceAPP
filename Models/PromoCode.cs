using System.ComponentModel.DataAnnotations;

namespace EFpfa.Models
{
    public class PromoCode
    {
        [Key]
        public string Code { get; set; }
        public float Reduction { get; set; }
        public DateTime DateExpiration { get; set; }
        public bool EstActive { get; set; }
    }
}
