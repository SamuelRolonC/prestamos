using Core.Entities;
using System;
using System.Collections.Generic;

namespace Core.Interfaces.Services
{
    public interface ILoanService
    {
        IEnumerable<Loan> GetListLoanByPeople(int peopleId);
        Loan GetById(int id);
    }
}
