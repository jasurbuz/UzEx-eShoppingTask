using AutoMapper;
using e_Shopping.Data.Models;
using e_Shopping.Services.DTOs.Client;
using e_Shopping.Services.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_e_Shopping.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ClientForCreationDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);

            await _unitOfWork.Clients.Insert(client);

            await _unitOfWork.Save();

            return View();
        }
    }
}
