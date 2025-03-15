using Timelive.Application.DTOs.Account;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Account;

public record GetAccountQuery(int UserId) : IQuery<UserResultDto>;
