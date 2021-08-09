using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Loan : StandardEntity
    {
        public DateTime? LoanedDate { get; set; }

        public decimal? Amount { get; set; }
        
        public int? PeopleId { get; set; }
        [ForeignKey(nameof(PeopleId))]
        public People People { get; set; }

        public int? PaymentMethodId { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod PaymentMethod { get; set; }

        public int? TermId { get; set; }
        [ForeignKey(nameof(TermId))]
        public Term Term { get; set; }
        
        public string Comments { get; set; }
    }
}
