using AutoMapper;
using e_Shopping.Data.Models;
using e_Shopping.Services.DTOs.Bid;
using e_Shopping.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_e_Shopping.Controllers
{
    public class BidController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BidController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.Products.GetAll(p => p.Count > 0);
            
            return View(products.ToList());
        }

        public async Task<IActionResult> Buy(Guid Id)
        {
            var product = await _unitOfWork.Products.Get(p => p.Id == Id);

            return View(product);
        }

        public async Task<IActionResult> Bidding(BidForCreationDto bidDto)
        {
            Bid bid = _mapper.Map<Bid>(bidDto);

            var product = await _unitOfWork.Products.Get(p => p.Id == bidDto.ProductId);

            bid.Total = product.Price * bidDto.Count;

            product.Count -= bidDto.Count;

            _unitOfWork.Products.Update(product);

            await _unitOfWork.Bids.Insert(bid);

            await _unitOfWork.Save();

            return Redirect("Index");
        }
    }
}
