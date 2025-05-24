using QLSX.Based.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Services.Interfaces
{
    public interface IDBService
    {
        Task<ObservableCollection<Product>> GetAllProductsAsync();
        //Task<User> GetUserByIdAsync(int id);
        //Task AddUserAsync(User user);
        //Task UpdateUserAsync(User user);
        //Task DeleteUserAsync(int id);
    }
}
