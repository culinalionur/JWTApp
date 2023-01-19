using JWTApp.Core.Application.DTOs;
using MediatR;

namespace JWTApp.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest :IRequest<CategoryListDto>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
