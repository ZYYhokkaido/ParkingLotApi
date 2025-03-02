﻿using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;
using System.Xml.Linq;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private readonly IParkingLotsRepository parkingLotsRepository;
        public ParkingLotService(IParkingLotsRepository parkingLotsRepository)
        {
            this.parkingLotsRepository = parkingLotsRepository;
        }
        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto) 
        { 
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            var res = await parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
            if (res == null)
            {
                throw new ExistingNameException(parkingLotDto.Name + "already existing.");
            }
            return res;
        }
        public async Task DeleteAsync(string name)
        {
            await parkingLotsRepository.DeleteParkingLot(name);
        }
        public async Task<List<ParkingLot>> GetAsync(int pageIndex)
        {
            return await parkingLotsRepository.GetParkingLot(pageIndex);
        }

        public async Task<ParkingLot> GetByIdAsync(string id)
        {
            var res = await parkingLotsRepository.GetParkingLotById(id);
            if (res != null)
            {
                return res;
            }
            throw new NoExistIdException();
        }

        public async Task<ParkingLot> PutAsync(string id, int capacity)
        {
            var res = await parkingLotsRepository.PutParkingLot(id, capacity);
            if (res != null)
            {
                return res;
            }
            throw new NoExistIdException();
        }
    }
}
