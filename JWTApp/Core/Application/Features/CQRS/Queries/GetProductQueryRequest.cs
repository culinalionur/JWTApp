using JWTApp.Core.Application.DTOs;
using MediatR;

namespace JWTApp.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest :IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
