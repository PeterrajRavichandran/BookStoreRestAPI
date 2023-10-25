using BookStoreAPI._Core.ResponseModels;
using BookStoreAPI._Core.ServiceFactories;
using BookStoreAPI.Domain.RequestQueries;
using BookStoreAPI.Domain.ResponseModels.cs;
using BookStoreAPI.Domain.SPModels;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace BookStoreAPI.Infrastructure.Handler.Queries
{
    public class GetBooksListHandler : IRequestHandler<GetBooksListQuery, Result<List<GetBooksListResponse>>>
    {

        private IDatabaseDapper _dapper;

        public GetBooksListHandler(IDatabaseDapper dapper) 
        {
            _dapper = dapper;
        }

        public async Task<Result<List<GetBooksListResponse>>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
        {
            Result<List<GetBooksListResponse>> result = new Result<List<GetBooksListResponse>>();
            List<GetBooksListResponse> response = new List<GetBooksListResponse>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@publisher", request.Publisher);
                parameters.Add("@title", request.Title);
                parameters.Add("@authorFirstName", request.AuthorFirstName);
                parameters.Add("@authorLastName", request.AuthorLastName);

                var _set = await _dapper.ExecuteGridReaderAsync("[BKS].[SP_GETBOOKSLIST]", parameters, CommandType.StoredProcedure);
                var set = (await _set.ReadAsync<SPGetBooksList>()).ToList();

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
