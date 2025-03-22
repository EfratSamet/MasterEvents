﻿using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestInEventController : ControllerBase
    {
        private readonly IGuestInEventService _guestInEventService;

        public GuestInEventController(IGuestInEventService guestInEventService)
        {
            _guestInEventService = guestInEventService;
        }

        [HttpGet]
        public IEnumerable<GuestInEventDto> Get()
        {
            return _guestInEventService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<GuestInEventDto> Get(int id)
        {
            var guest = _guestInEventService.Get(id);
            if (guest == null)
                return NotFound();
            return Ok(guest);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GuestInEventDto value)
        {
            var addedGuest = _guestInEventService.Add(value);
            return CreatedAtAction(nameof(Get), new { id = addedGuest.id }, addedGuest);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GuestInEventDto value)
        {
            var updatedGuest = _guestInEventService.Update(id, value);
            if (updatedGuest == null)
                return NotFound();
            return Ok(updatedGuest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingGuest = _guestInEventService.Get(id);
            if (existingGuest == null)
                return NotFound();

            _guestInEventService.Delete(id);
            return NoContent();
        }

        [HttpGet("byEvent/{eventId}")]
        public IEnumerable<GuestInEventDto> GetGuestsByEvent(int eventId)
        {
            return _guestInEventService.GetGuestsByEventId(eventId);
        }

        [HttpGet("confirmed/{eventId}")]
        public IEnumerable<GuestInEventDto> GetConfirmedGuests(int eventId)
        {
            return _guestInEventService.GetGuestsByEventIdOk(eventId);
        }

        [HttpGet("assign-tables")]
        public async Task<IActionResult> AssignGuestsToTables([FromQuery] int eventId, [FromQuery] int seatsPerTable)
        {
            try
            {
                var tables = await _guestInEventService.AssignGuestsToTablesWithSubGuestsAsync(eventId, seatsPerTable);
                return Ok(tables);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error assigning guests to tables: {ex.Message}");
            }
        }

    }
}
