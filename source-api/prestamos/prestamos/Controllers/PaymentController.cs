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
            
                var listLoan = new List<Loan>
                {
                    new Loan() { Id = 1, Description = "Griferia" },
                    new Loan() { Id = 2, Description = "Spotify" },
                    new Loan() { Id = 3, Description = "Supermercado" },
                    new Loan() { Id = 4, Description = "Movistar" },
                };
                var listLoanDdl = MapListTo<Loan, DropDownListViewModel>(listLoan);

                viewModel = new PaymentViewModel()
                {
                    Payment = payment,
                    ListLoan = listLoanDdl,
                    ListPeople = listPeopleDdl,
                    ListPaymentMethod = listPaymentMethodDdl,
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
