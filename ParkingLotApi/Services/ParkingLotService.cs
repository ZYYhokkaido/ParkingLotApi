﻿using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        public async Task<ParkingLotDto> AddAsync(ParkingLotDto parkingLotDto) 
        { 
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return null;
        }
    }
}
