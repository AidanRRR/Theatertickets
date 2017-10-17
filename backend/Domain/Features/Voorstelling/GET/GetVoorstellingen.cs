using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data.Repositories;
using backend.Domain.Models;
using MediatR;

namespace backend.Domain.Features.Voorstelling.GET
{
    public class GetVoorstellingen
    {
        public class Request : IRequest<Result>
        {
        }

        public class Result : ApiResult<IEnumerable<VoorstellingEntity>>
        {
        }

        public class Handler : IAsyncRequestHandler<Request, Result>
        {
            private readonly ITheaterTicketsRepository _repository;

            public Handler(ITheaterTicketsRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(Request request)
            {
                var result = new Result {Data = await _repository.GetAllItemsAsync<VoorstellingEntity>()};
                return result;
            }
        }
    }
}