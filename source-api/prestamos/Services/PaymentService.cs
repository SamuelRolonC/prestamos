using Core.Entities;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Services
{
    public class PaymentService : IPaymentService
    {
        public IEnumerable<Payment> GetListPaymentByPeople(int peopleId)
        {
            var list = new List<Payment>();

            list.Add(new Payment()
            {
                Id = 1,
                Description = "Test 1",
                PaidDate = DateTime.Today,
                Amount = 1000,
                PeopleId = 2,
                PaymentMethodId = 2,
                Comments = ""
            });

            list.Add(new Payment()
            {
                Id = 2,
                Description = "Test 2",
                PaidDate = DateTime.Today,
                Amount = 1000,
                PeopleId = 2,
                PaymentMethodId = 2,
                Comments = ""
            });

            list.Add(new Payment()
            {
                Id = 3,
                Description = "Test 3",
                PaidDate = DateTime.Today,
                Amount = 1000,
                PeopleId = 2,
                PaymentMethodId = 2,
                Comments = ""
            });

            return list;
        }

        public Payment GetById(int id)
        {
            var payment = new Payment()
            {
                Id = 1,
                Description = "Test 1",
                PaidDate = DateTime.Today,
                Amount = 1000,
                PeopleId = 2,
                PaymentMethodId = 2,
                Comments = ""
            };

            return payment;
        }
    }
}
