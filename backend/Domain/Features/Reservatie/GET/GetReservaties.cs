﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data.Repositories;
using backend.Domain.Models;
using MediatR;

namespace backend.Domain.Features.Reservatie.GET
{
    public class GetReservaties
    {
        public class Request : IRequest<Result>
        {
        }

        public class Result : ApiResult<IEnumerable<ReservatieEntity>>
        {
        }

        public class Handler : IAsyncRequestHandler<Request, Result>
        {
            private readonly ITheaterTicketsRepository _repository;
            private readonly IMapper _mapper;

            public Handler(ITheaterTicketsRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result> Handle(Request request)
            {
                var result = new Result {Data = await _repository.GetAllItemsAsync<ReservatieEntity>()};
                return result;
            }
        }
    }
}