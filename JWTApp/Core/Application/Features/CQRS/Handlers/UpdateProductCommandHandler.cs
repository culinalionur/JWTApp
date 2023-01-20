using JWTApp.Core.Application.Features.CQRS.Commands;
using JWTApp.Core.Application.Interfaces;
using JWTApp.Core.Domain;
using MediatR;

namespace JWTApp.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct = await this._repository.GetByIdAsync(request.Id);
            if (updatedProduct != null)
            {
                updatedProduct.Name = request.Name;
                updatedProduct.Price = request.Price;
                updatedProduct.Stock = request.Stock;
                updatedProduct.CategoryId = request.CategoryId;
                await this._repository.UpdateAsync(updatedProduct);
            }

            return Unit.Value;
        }
    }
}
