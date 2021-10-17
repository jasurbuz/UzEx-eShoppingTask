using AutoMapper;
using e_Shopping.Data.Models;
using e_Shopping.Services.DTOs.Bid;
using e_Shopping.Services.DTOs.Client;
using e_Shopping.Services.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_e_Shopping.Configuration
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<Client, ClientForCreationDto>().ReverseMap();
            CreateMap<Product, ProductForCreationDto>().ReverseMap();
            CreateMap<Bid, BidForCreationDto>().ReverseMap();
        }
    }
}
