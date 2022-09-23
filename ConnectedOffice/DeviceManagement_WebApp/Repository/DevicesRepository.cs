using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManagement_WebApp.Models;
using System.ComponentModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace DeviceManagement_WebApp.Repository
{

    public class DevicesRepository : GenericRepository<Device>, IDeviceRepository
    {
     

        public DevicesRepository(ConnectedOfficeContext connectedOfficeContext) : base(connectedOfficeContext)
        {

        }
        public Device GetMostRecentService()
        {
            return _context.Device.OrderByDescending(Device => Device.DateCreated).FirstOrDefault();
        }

        public List<Device> GetAll()
        {
            return _context.Device.ToList();
        }

        public Task<Device> GetbyID(Guid? id)
        {

            var device = _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone);
           
            return ((Task<Device>)device);
        }





    }
}
