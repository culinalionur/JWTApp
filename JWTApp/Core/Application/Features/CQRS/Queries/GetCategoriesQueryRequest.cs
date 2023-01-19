using JWTApp.Core.Application.DTOs;
using MediatR;

namespace JWTApp.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {

    }
}
