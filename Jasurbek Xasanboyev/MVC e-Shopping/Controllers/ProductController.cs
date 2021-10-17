using AutoMapper;
using e_Shopping.Data.Models;
using e_Shopping.Services.DTOs.Product;
using e_Shopping.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_e_Shopping.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.Products.GetAll();

            return View(products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Add(ProductForCreationDto productDto)
        {

            var product = _mapper.Map<Product>(productDto);

            await _unitOfWork.Products.Insert(product);

            await _unitOfWork.Save();

            return Redirect("Index");
        }
        public async Task<IActionResult> Edit(Guid Id)
        {
            var product = await _unitOfWork.Products.Get(c => c.Id == Id);

            return View(product);
        }

        public async Task<IActionResult> Save(Product product)
        {
            _unitOfWork.Products.Update(product);

            await _unitOfWork.Save();

            return Redirect("Index");
        }
        public async Task<IActionResult> Details(Guid Id)
        {
            var product = await _unitOfWork.Products.Get(c => c.Id == Id);

            return View(product);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var product = await _unitOfWork.Products.Get(c => c.Id == Id);

            return View(product);
        }

        public async Task<IActionResult> Remove(Product product)
        {
            _unitOfWork.Products.Delete(product);

            await _unitOfWork.Save();

            return Redirect("Index");
        }
    }
}
