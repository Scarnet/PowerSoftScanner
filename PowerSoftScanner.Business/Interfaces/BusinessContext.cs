using AutoMapper;
using Infrastructure.Interfaces;
using PowerSoftScanner.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.Business.Interfaces
{
    public abstract class BusinessContext
    {
        protected INetworkProvider NetworkProvider;
        protected IMapper Mapper;
        protected readonly string BaseUrl = ApiSettings.BaseUrl;
        protected BusinessContext(INetworkProvider networkProvider, IMapper mapper)
        {
            NetworkProvider = networkProvider;
            Mapper = mapper;
        }
    }
}
