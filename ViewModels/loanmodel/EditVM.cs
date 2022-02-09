using Projecta.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projecta.ViewModels.loanmodel
{
    public class EditVM
    {
        public int Id { get; set; }
        public List<Loan> Loans { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string EGN { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        [Range(0, 10000.00, ErrorMessage = "the value should be below 10000")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string LastName { get; set; }
    }
}
