using Core.Entities;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Services
{
    public class LoanService : ILoanService
    {
        public IEnumerable<Loan> GetListLoanByPeople(int peopleId)
        {
            var list = new List<Loan>();

            list.Add(new Loan()
            {
                Id = 1,
                Description = "Test 1",
                LoanedDate = DateTime.Today,
                Amount = 1000,
                PeopleId = 2,
                PaymentMethodId = 2,
                TermId = 2,
                Comments = ""
            });

            list.Add(new Loan()
            {
                Id = 2,
                Description = "Test 2",
                LoanedDate = DateTime.Today,
                Amount = 1000,
                PeopleId = 2,
                PaymentMethodId = 2,
                TermId = 2,
                Comments = ""
            });

            list.Add(new Loan()
            {
                Id = 3,
                Description = "Test 3",
                LoanedDate = DateTime.Today,
                Amount = 1000,
                PeopleId = 2,
                PaymentMethodId = 2,
                TermId = 2,
                Comments = ""
            });

            return list;
        }

        public Loan GetById(int id)
        {
            var loan = new Loan()
            {
                Id = 1,
                Description = "Test 1",
                LoanedDate = DateTime.Today,
                Amount = 1000,
                PeopleId = 2,
                PaymentMethodId = 2,
                TermId = 2,
                Comments = ""
            };

            return loan;
        }
    }
}
