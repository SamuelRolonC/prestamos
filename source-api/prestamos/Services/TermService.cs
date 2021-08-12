using Core.Entities;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Services
{
    public class TermService : ITermService
    {
        public IEnumerable<Term> GetListTerm()
        {
            var list = new List<Term>
            {
                new Term() { Id = 1, Description = "Enero" },
                new Term() { Id = 2, Description = "Febrero" },
                new Term() { Id = 3, Description = "Marzo" },
                new Term() { Id = 4, Description = "Abril" },
                new Term() { Id = 5, Description = "Mayo" },
                new Term() { Id = 6, Description = "Junio" },
                new Term() { Id = 7, Description = "Julio" },
                new Term() { Id = 8, Description = "Agosto" },
                new Term() { Id = 9, Description = "Septiembre" },
                new Term() { Id = 10, Description = "Octubre" },
                new Term() { Id = 11, Description = "Noviembre" },
                new Term() { Id = 12, Description = "Diciembre" },
            };

            return list;
        }
    }
}
