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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeviceManagement_WebApp.Repository
{

    public class DevicesRepository : GenericRepository<Device>, IDeviceRepository
    {

        protected readonly ConnectedOfficeContext _context;
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

        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var device = await _context.Device
        //         .Include(d => d.Category)
        //         .Include(d => d.Zone)
        //         .FirstOrDefaultAsync(m => m.DeviceId == id);

        //    _devicesRepository.Update(device);
        //    if (device == null)
        //    {
        //        return NotFound();
        //    }


        //    ViewData["CategoryId"] = new SelectList(_devicesRepository., "CategoryId", "CategoryName", device.CategoryId);
        //    ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneName", device.ZoneId);
        //    return View(device);
        //}

        private bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }

        bool IDeviceRepository.DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }


        public async Task<Device> DeleteConfirmed(Guid id)
        {
            var device = await _context.Device.FindAsync(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();

            return device;
           
        }


    }
}
