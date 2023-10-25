using BookStoreAPI._Core.ResponseModels;
using BookStoreAPI._Core.ServiceFactories;
using BookStoreAPI.Domain.RequestQueries;
using BookStoreAPI.Domain.ResponseModels.cs;
using BookStoreAPI.Domain.SPModels;
using Dapper;
using MediatR;
using System.Data;
using System.Net;  

namespace BookStoreAPI.Infrastructure.Handler.Queries
{
    public class GetBooksListAuthorTitleHandler : IRequestHandler<GetBooksListAuthorTitleQuery, Result<List<GetBooksListResponse>>>
    {
        private IDatabaseDapper _dapper;
        public GetBooksListAuthorTitleHandler(IDatabaseDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<Result<List<GetBooksListResponse>>> Handle(GetBooksListAuthorTitleQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get Books List Handler Method Hit");
            Result<List<GetBooksListResponse>> result = new Result<List<GetBooksListResponse>>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@title", request.Title);
                parameters.Add("@authorFirstName", request.AuthorFirstName);
                parameters.Add("@authorLastName", request.AuthorLastName);

                var set = await _dapper.GetAll<SPGetBooksList>("[BK].[GETBOOKSLIST]", parameters, CommandType.StoredProcedure);

                if (set.Count > 0)
                {
                    result.Data = new List<GetBooksListResponse>(set.Select(x => (GetBooksListResponse)x));
                    result.IsSuccess = true;
                    result.Message = "Success";
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}
