using System.ComponentModel.DataAnnotations;

namespace ShopTARge23.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string ALLOWEDDOMAIN;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            ALLOWEDDOMAIN = allowedDomain;
        }
    }
}
