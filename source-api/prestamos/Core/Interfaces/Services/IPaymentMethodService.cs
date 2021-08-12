using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPaymentMethodService
    {
        IEnumerable<PaymentMethod> GetListPaymentMethod();
    }
}
