using JWTApp.Core.Application.Features.CQRS.Commands;
using JWTApp.Core.Application.Interfaces;
using JWTApp.Core.Domain;
using MediatR;

namespace JWTApp.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedCategory = await this._repository.GetByIdAsync(request.Id);
            if (updatedCategory != null)
            {
                updatedCategory.Definition = request.Definition;
                await this._repository.UpdateAsync(updatedCategory);
            }

            return Unit.Value;
        }
    }
}
