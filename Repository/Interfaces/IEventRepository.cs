﻿using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    internal interface IEventRepository : IRepository<Event>
    {
        List<Event> GetEventsByOrganizerId(string organizerId);
        List<Event> GetEventsByDateRange(DateTime startDate, DateTime endDate);
        List<Event> GetEventsByAddress(string address);
        List<Event> GetUpcomingEvents();
        List<Event> GetEventsByAddressKeyword(string keyword);
    }

}
