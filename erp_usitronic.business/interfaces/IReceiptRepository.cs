﻿using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.interfaces
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        bool UpdatePaidStatus(Receipt receipt);
    }
}
