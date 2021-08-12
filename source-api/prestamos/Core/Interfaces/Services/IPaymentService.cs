using Core.Entities;
using System;
using System.Collections.Generic;

namespace Core.Interfaces.Services
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetListPaymentByPeople(int peopleId);
        Payment GetById(int id);
    }
}
