using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data.Repositories;
using backend.Domain.Models;
using MediatR;
using Microsoft.WindowsAzure.Storage.Table;

namespace backend.Domain.Features.Voorstelling
{
    public class AddVoorstelling
    {
        public class Request : IRequest<Result>
        {
            private string GezelschapNaam { get; set; }
            private string VoorstellingNaam { get; set; }
            private DateTime VoorstellingDatum { get; set; }
            private IEnumerable<string> BeschikbareStoelen { get; set; }
            private IEnumerable<string> GereserveerdeStoelen { get; set; }
        }

        public class Result : ApiResult<TableResult>
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
                var item = await _repository.CreateItemAsync(_mapper.Map<Request, VoorstellingEntity>(request));
                var result = new Result {Data = item};
                return result;
            }
        }
    }
}