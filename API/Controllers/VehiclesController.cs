using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.DTOs.VehicleDtos;
using API.Entities;
using API.Extensions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class VehiclesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VehiclesController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDetailsDto>>> GetVehicles()
        {   
            var username = User.GetUsername();    // -> Extensions

            return await _context.Vehicles
                            .Where(vehicle => vehicle.AppUser.UserName == username)
                            .ProjectTo<VehicleDetailsDto>(_mapper.ConfigurationProvider)
                            .ToListAsync();
        }

        // Get specific vehicle
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDetailsDto>> GetVehicle(int id)
        {   
            // var username = User.GetUsername();    // -> Extensions

            var vehicle = await _context.Vehicles
                            .ProjectTo<VehicleDetailsDto>(_mapper.ConfigurationProvider)
                            .SingleOrDefaultAsync(vehicle => vehicle.Id == id);

            if(vehicle == null) return NotFound("Nie znaleziono pojazdu o podanym id!");

            return vehicle;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVehicle(int id, VehicleUpdateDto vehicle)
        {   
            // var username = User.GetUsername();    // -> Extensions

            Vehicle vehicleToUpdate = await _context.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.Id == id);

            if(vehicleToUpdate == null) return NotFound($"Pojazd o Id {id} nie istnieje!");

            // Change UpdateAt date
            vehicle.UpdatedAt = DateTime.Now;

            _mapper.Map(vehicle, vehicleToUpdate);
            _context.Vehicles.Update(vehicleToUpdate);

            if(await _context.SaveChangesAsync() > 0) return NoContent();
            return StatusCode(StatusCodes.Status500InternalServerError, "Problem z aktualizacją pojazdu!");
        }

        [HttpPost]
        public async Task<ActionResult<VehicleDetailsDto>> CreateClient(VehicleCreateDto vehicle)
        {   
            Vehicle newVehicle = new Vehicle();

            _mapper.Map(vehicle, newVehicle);
            newVehicle.AppUserId = User.GetUserId();
            _context.Vehicles.Add(newVehicle);

            if(await _context.SaveChangesAsync() > 0) return _mapper.Map(newVehicle, new VehicleDetailsDto());
            return StatusCode(StatusCodes.Status500InternalServerError, "Problem z dodaniem pojazdu!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {   
            var userId = User.GetUserId();    // -> Extensions (obtain id of sender)

            var vehicleToDelete = await _context.Vehicles.FirstOrDefaultAsync(vehicle => (vehicle.Id == id) && vehicle.AppUserId == userId);

            if(vehicleToDelete == null) return NotFound($"Pojazd o Id {id} nie istnieje!");

            _context.Vehicles.Remove(vehicleToDelete);

            if(await _context.SaveChangesAsync() > 0) return NoContent();
            return StatusCode(StatusCodes.Status500InternalServerError, "Problem z usunięciem pojazdu!");
        }

    }
}