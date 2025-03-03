﻿using AutoMapper;
using Repository.Entity;
using Repository.Interfaces;
using Service.Dtos;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EventService:IService<EventDto>
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public EventDto Add(EventDto item)
        {
            return _mapper .Map<EventDto>(_repository.Add(_mapper.Map<Event>(item)));
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public EventDto Get(string id)
        {
            return _mapper.Map<EventDto>(_repository.Get(id));
        }

        public List<EventDto> GetAll()
        {
            return _mapper.Map<List<EventDto>>(_repository.GetAll());
        }

        public EventDto Update(string id, EventDto item)
        {
            return _mapper.Map<EventDto>(_repository.Update(id, _mapper.Map<Event>(item)));
        }
    }
}
