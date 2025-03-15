using Timelive.Application.DTOs.Account;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Account;

public class GetAccountQueryHandler : IQueryHandler<GetAccountQuery, UserResultDto>
{
    public Task<UserResultDto> Handle(GetAccountQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
