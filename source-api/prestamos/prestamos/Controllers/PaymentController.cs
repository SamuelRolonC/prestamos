using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prestamos.Models;

namespace prestamos.Controllers
{
    public class PaymentController : CustomApiController
    {
        private readonly ILogger<ControllerBase> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Payment(int id)
        {
            var viewModel = new PaymentViewModel();

            try
            {
                var payment = new Payment()
                {
                    Id = 1,
                    Description = "Test",
                    PaidDate = DateTime.Today,
                    Amount = 1000,
                    PeopleId = 2,
                    PaymentMethodId = 2,
                    Comments = ""
                };

                var paid = (decimal)100;

                var listPeople = new List<People>
                {
                    new People() { Id = 1, Name = "Mamá", Lastname = "" },
                    new People() { Id = 2, Name = "Papá", Lastname = "" },
                    new People() { Id = 3, Name = "Jairo", Lastname = "Rolón" },
                };
                var listPeopleDdl = MapListTo<People, DropDownListViewModel>(listPeople);

                var listPaymentMethod = new List<PaymentMethod>
                {
                    new PaymentMethod() { Id = 1, Description = "Tarjeta de crédito" },
                    new PaymentMethod() { Id = 2, Description = "Transferencia bancaria" },
                    new PaymentMethod() { Id = 3, Description = "Efectivo" },
                };
                var listPaymentMethodDdl = MapListTo<PaymentMethod, DropDownListViewModel>(listPaymentMethod);
            
                var listTerm = new List<Term>
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
                var listTermDdl = MapListTo<Term, DropDownListViewModel>(listTerm);

                viewModel = new PaymentViewModel()
                {
                    Payment = payment,
                    ListLoan = null,
                    ListPeople = listPeopleDdl,
                    ListPaymentMethod = listPaymentMethodDdl,
                    ListTerm = listTermDdl,
                    Paid = paid,
                    Balance = paid - payment.Amount,
                };

            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }

            //if (id > 0)

            return Json(viewModel);
        }
    }
}
