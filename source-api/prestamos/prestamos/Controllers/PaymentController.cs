using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prestamos.Models;

namespace prestamos.Controllers
{
    public class PaymentController : CustomApiController
    {
        #region Services

        private readonly IPaymentService _paymentService;
        private readonly ILoanService _loanService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IPeopleService _peopleService;

        #endregion

        #region Other Fields

        private readonly ILogger<CustomApiController> _logger;

        #endregion

        #region Constructors

        public PaymentController(
            IPaymentService paymentService
            , ILoanService loanService
            , IPaymentMethodService paymentMethodService
            , IPeopleService peopleService
            , ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _loanService = loanService;
            _paymentMethodService = paymentMethodService;
            _peopleService = peopleService;

            _logger = logger;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Payment> list = new List<Payment>();
            
            try
            {
                list = _paymentService.GetListPaymentByPeople(0);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return Json(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Payment(int id)
        {
            var viewModel = new PaymentViewModel();

            try
            {
                var payment = _paymentService.GetById(id);

                var paid = (decimal)100;

                var listPeople = _peopleService.GetListPeople().ToList();
                var listPeopleDdl = MapListTo<People, DropDownListViewModel>(listPeople);

                var listPaymentMethod = _paymentMethodService.GetListPaymentMethod().ToList();
                var listPaymentMethodDdl = MapListTo<PaymentMethod, DropDownListViewModel>(listPaymentMethod);

                var listLoan = _loanService.GetListLoanByPeople(0).ToList();
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
