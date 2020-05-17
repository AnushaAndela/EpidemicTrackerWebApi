using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Transformers
{
    public static class ModelTransformer
    {
        public static Address ConvertToAddress(this AddressDto addressDto)
        {
            var address = new Address();
            address.AddressId = addressDto.AddressDtoId;
            address.AddressType = addressDto.AddressType;
            address.Hno = addressDto.Hno;
            address.Street = addressDto.Street;
            address.City = addressDto.City;
            address.State = addressDto.State;
            address.Country = addressDto.Country;
            address.Pincode = addressDto.Pincode;

            return address;
        }
    }
}
