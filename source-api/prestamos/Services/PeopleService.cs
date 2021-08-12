using Core.Entities;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Services
{
    public class PeopleService : IPeopleService
    {
        public IEnumerable<People> GetListPeople()
        {
            var list = new List<People>
            {
                new People() { Id = 1, Name = "Mamá", Lastname = "" },
                new People() { Id = 2, Name = "Papá", Lastname = "" },
                new People() { Id = 3, Name = "Jairo", Lastname = "Rolón" },
            };

            return list;
        }
    }
}
