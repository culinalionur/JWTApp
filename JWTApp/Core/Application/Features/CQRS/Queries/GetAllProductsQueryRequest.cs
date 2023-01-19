using JWTApp.Core.Application.DTOs;
using MediatR;

namespace JWTApp.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest : IRequest<List<ProductListDto>>
    {
    }
}
