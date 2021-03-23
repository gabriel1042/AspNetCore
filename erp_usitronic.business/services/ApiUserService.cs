using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.business.interfaces;

namespace erp_usitronic.business.services
{    
    public class ApiUserService : BaseService, IApiUserService
    {
        private readonly IApiUserRepository _apiUserRepository;
        public ApiUserService(INotificator notificator,
                               IApiUserRepository apiUserRepository) : base(notificator)
        {
            _apiUserRepository = apiUserRepository;
        }

        public bool IsAuthorized(string userName, string resource, string method)
        {
            return _apiUserRepository.IsAuthorized(userName, resource, method);
        }
    }
}
