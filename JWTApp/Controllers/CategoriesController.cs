using JWTApp.Core.Application.Features.CQRS.Commands;
using JWTApp.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JWTApp.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await this._mediator.Send(new GetCategoryQueryRequest(id));
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await this._mediator.Send(new GetCategoriesQueryRequest());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
        {
            await this._mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            await this._mediator.Send(request);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await this._mediator.Send(new DeleteCategoryCommandRequest(id));
            return NoContent();

        }

    }
}
