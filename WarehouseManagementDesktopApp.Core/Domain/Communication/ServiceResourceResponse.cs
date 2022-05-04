using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Communication
{
    public class ServiceResourceResponse<TResource> : ServiceResponse
    {
        public TResource Resource { get; private set; }

        public ServiceResourceResponse(TResource resource)
        {
            Success = true;
            Error = null;
            Resource = resource;
        }

        public ServiceResourceResponse(Error error)
        {
            Success = false;
            Error = error;
            Resource = default;
        }
    }
}
