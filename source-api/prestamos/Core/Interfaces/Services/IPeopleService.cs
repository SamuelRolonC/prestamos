using Core.Entities;
using System;
using System.Collections.Generic;

namespace Core.Interfaces.Services
{
    public interface IPeopleService
    {
        IEnumerable<People> GetListPeople();
    }
}
