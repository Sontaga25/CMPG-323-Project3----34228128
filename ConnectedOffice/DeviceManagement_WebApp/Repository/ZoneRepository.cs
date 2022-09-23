using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq;
using System.Security.Policy;
using Zone = DeviceManagement_WebApp.Models.Zone;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {

        }

      
    }

}



