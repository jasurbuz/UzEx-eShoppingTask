using e_Shopping.Data.Contexts;
using e_Shopping.Data.Models;
using e_Shopping.Data.Models.Indentity;
using e_Shopping.Services.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shopping.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Members

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _host;
        private GenericRepository<Client> _client;
        private GenericRepository<Admin> _admin;
        private GenericRepository<Moderator> _moderator;
        private GenericRepository<Product> _product;
        private GenericRepository<Bid> _bid;

        #endregion

        #region Constructors

        public UnitOfWork(AppDbContext context, IWebHostEnvironment hostEnvironmnet)
        {
            _context = context;

            _host = hostEnvironmnet;
        }

        #endregion

        #region Public Members

        public IGenericRepository<Client> Clients => _client ??= new GenericRepository<Client>(_context);
        public IGenericRepository<Admin> Admins => _admin ??= new GenericRepository<Admin>(_context);
        public IGenericRepository<Moderator> Moderators => _moderator ??= new GenericRepository<Moderator>(_context);
        public IGenericRepository<Product> Products => _product ??= new GenericRepository<Product>(_context);
        public IGenericRepository<Bid> Bids => _bid ??= new GenericRepository<Bid>(_context);

        #endregion

        public void Dispose()
        {
            _context.Dispose();

            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        #region File functions

        public async Task<string> SaveFileAsync(IFormFile file, string folder = "Images")
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fileName = new String(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_host.ContentRootPath, folder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

        public void DeleteFile(string fileName, string folder = "Images")
        {
            var filePath = Path.Combine(_host.ContentRootPath, folder, fileName);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        #endregion
    }
}
