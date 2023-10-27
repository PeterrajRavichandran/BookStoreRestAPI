using BookStoreAPI._Core.ResponseModels;
using BookStoreAPI.Domain.RequestQueries;
using BookStoreAPI.Domain.ResponseModels.cs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        protected virtual IMediator _mediator { get; set; }
        public StoreController(ILogger<StoreController> logger, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("get-books-list")]
        public async Task<Result<List<GetBooksListResponse>>> GetBooksList(GetBooksListQuery query, CancellationToken cancellationToken)
        {

            return await _mediator.Send(query);
        }

        [HttpPost("booksList-authorTitle-based")]
        public async Task<Result<List<GetBooksListResponse>>> GetBooksList(GetBooksListAuthorTitleQuery query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query);
        }

        [HttpPost("get-books-totalPrice")]
        public async Task<Result<decimal>> GetBooksTotalPrice(CancellationToken cancellationToken)
        {

            GetBooksTotalPriceQuery query = new GetBooksTotalPriceQuery();
            return await _mediator.Send(query);
        }

        [HttpPost("bulk-save-books")]
        public async Task<Result<int>> BulkSave(BulkSaveBooksQuery query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query);
        }
    }
}
