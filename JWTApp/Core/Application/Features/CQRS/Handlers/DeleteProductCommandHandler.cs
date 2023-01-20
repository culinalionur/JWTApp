using JWTApp.Core.Application.Features.CQRS.Commands;
using JWTApp.Core.Application.Interfaces;
using JWTApp.Core.Domain;
using MediatR;

namespace JWTApp.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedProduct = await this._repository.GetByIdAsync(request.Id);
            if (deletedProduct != null)
            {
                await this._repository.RemoveAsync(deletedProduct);
            }

            return Unit.Value;
        }
    }
}
