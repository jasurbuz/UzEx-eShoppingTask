using e_Shopping.Data.Models;
using e_Shopping.Data.Models.Indentity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shopping.Services.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();

        Task<string> SaveFileAsync(IFormFile file, string folder = "Images");

        void DeleteFile(string fileName, string folder = "Images");
        IGenericRepository<Admin> Admins { get; }
        IGenericRepository<Moderator> Moderators { get; }
        IGenericRepository<Client> Clients { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Bid> Bids { get; }
    }
}
