using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class LoginVM:IValidatableObject
    {
        [Required]
        [MinLength(5)]
        public string username { get; set; }

        [Required]
        [MinLength(6)]
        public string password { get; set; }

        public bool chekAuth()
        {
            return (this.username == "wechen" && this.password == "123456789");
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!chekAuth())
            {
                yield return new ValidationResult("login fail", new string[] { "username" });
                yield break;
            }
            yield return ValidationResult.Success;
        }
    }
}