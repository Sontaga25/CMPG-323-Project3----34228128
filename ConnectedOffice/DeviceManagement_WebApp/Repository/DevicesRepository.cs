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
     


    }
}
