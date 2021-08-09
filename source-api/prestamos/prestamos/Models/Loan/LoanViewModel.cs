using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prestamos.Models
{
    public class LoanViewModel
    {
        public Loan Loan { get; set; }

        public decimal? Paid { get; set; }

        public decimal? Balance { get; set; }

        public IEnumerable<DropDownListViewModel> ListPeople { get; set; }
        public IEnumerable<DropDownListViewModel> ListPaymentMethod { get; set; }
        public IEnumerable<DropDownListViewModel> ListTerm { get; set; }
    }
}
