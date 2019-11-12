using AutoMapper;
using PowerSoftScanner.Business.Models.Business;
using PowerSoftScanner.Business.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.Business.MappingProfiles
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<StockItemDto, StockItem>();
        }
    }
}
