using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureUserManager.Business
{
    public abstract class AzureUser
    {
        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual string UserId { get; set; }

        [Required]
        public virtual string Email { get; set; }

        public virtual string HsaId { get; set; }
    }
}