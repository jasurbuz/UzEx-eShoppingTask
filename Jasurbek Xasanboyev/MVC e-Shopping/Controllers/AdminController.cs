using AutoMapper;
using e_Shopping.Data.Models;
using e_Shopping.Services.DTOs.Client;
using e_Shopping.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_e_Shopping.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clients = await _unitOfWork.Clients.GetAll();

            return View(clients.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Add(ClientForCreationDto clientDto)
        {

            var client = _mapper.Map<Client>(clientDto);

            await _unitOfWork.Clients.Insert(client);

            await _unitOfWork.Save();

            return Redirect("Index");
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var client = await _unitOfWork.Clients.Get(c => c.Id == Id);

            return View(client);
        }

        public async Task<IActionResult> Save(Client client)
        {
            _unitOfWork.Clients.Update(client);

            await _unitOfWork.Save();

            return Redirect("Index");
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var client = await _unitOfWork.Clients.Get(c => c.Id == Id);

            return View(client);
        }
        public async Task<IActionResult> Delete(Guid Id)
        {
            var client = await _unitOfWork.Clients.Get(c => c.Id == Id);

            return View(client);
        }

        public async Task<IActionResult> Remove(Client client)
        {
            _unitOfWork.Clients.Delete(client);

            await _unitOfWork.Save();

            return Redirect("Index");
        }
    }
}
