using Core.Entities;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        public IEnumerable<PaymentMethod> GetListPaymentMethod()
        {
            var list = new List<PaymentMethod>
            {
                new PaymentMethod() { Id = 1, Description = "Tarjeta de crédito" },
                new PaymentMethod() { Id = 2, Description = "Transferencia bancaria" },
                new PaymentMethod() { Id = 3, Description = "Efectivo" },
            };

            return list;
        }
    }
}
