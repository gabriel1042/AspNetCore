using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;

namespace erp_usitronic.business.services
{
    public class CashFlowDayService : BaseService, ICashFlowDayService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IReceiptRepository _receiptRepository;
        public CashFlowDayService(INotificator notificador,
                                    IPaymentRepository paymentRepository,
                                    IReceiptRepository receiptRepository) : base(notificador)
        {
            _paymentRepository = paymentRepository;
            _receiptRepository = receiptRepository;
        }
    }
}
