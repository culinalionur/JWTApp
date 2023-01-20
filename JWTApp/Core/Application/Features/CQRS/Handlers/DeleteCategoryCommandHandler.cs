using JWTApp.Core.Application.Features.CQRS.Commands;
using JWTApp.Core.Application.Interfaces;
using JWTApp.Core.Domain;
using MediatR;

namespace JWTApp.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedCategory = await this._repository.GetByIdAsync(request.Id);
            if (deletedCategory != null)
            {
                await this._repository.RemoveAsync(deletedCategory);
            }

            return Unit.Value;
        }
    }
}
