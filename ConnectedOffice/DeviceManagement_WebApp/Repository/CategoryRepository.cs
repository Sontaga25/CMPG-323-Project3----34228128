using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DeviceManagement_WebApp.Repository
{ 
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {
            //public async Task<> DeleteConfirmed(Guid id)
            //{
            //    var category = await _context.Category.FindAsync(id);
            //    _context.Category.Remove(category);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

        }
     
    }
}
