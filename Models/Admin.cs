using ecommerceAPP.Data;

namespace EFpfa.Models
{
    public class Admin : Utilisateur
    {
        public Admin()
        {
            Type = "Admin"; // Automatically set type
        }
    }
}
