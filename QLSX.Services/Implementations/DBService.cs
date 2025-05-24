using Microsoft.EntityFrameworkCore;
using QLSX.Based.Common.Models;
using QLSX.Services.Data;
using QLSX.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace QLSX.Services.Implementations
{
    public class DBService : IDBService
    {
        private readonly AppDbContext _dbContext;
        public DBService(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<ObservableCollection<Product>> GetAllProductsAsync()
        {
            var products = await _dbContext.Products.ToListAsync();
            return new ObservableCollection<Product>(products);
        }
    }
}
