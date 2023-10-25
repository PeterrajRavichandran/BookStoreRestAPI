using BookStoreAPI._Core.ResponseModels;
using BookStoreAPI.Domain.RequestQueries;
using BookStoreAPI.Domain.ResponseModels.cs;
using BookStoreAPI.Infrastructure.Persistence.Context;
using MediatR;
using System.Net;

namespace BookStoreAPI.Infrastructure.Handler.Queries
{
    public class GetBooksTotalPriceHandler : IRequestHandler<GetBooksTotalPriceQuery, Result<decimal>>
    {
        readonly ApplicationReadContext _readContext;
        public GetBooksTotalPriceHandler( ApplicationReadContext readContext)
        {

            _readContext = readContext;
        }
        public async Task<Result<decimal>> Handle(GetBooksTotalPriceQuery request, CancellationToken cancellationToken)
        {
          
            Result<decimal> result = new Result<decimal>();
            try
            {
                result.Data = (decimal)_readContext.Books.Select(s => s.Price).Sum(); 
                result.IsSuccess = true;
                result.Message = "Success";
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;                        
            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}
