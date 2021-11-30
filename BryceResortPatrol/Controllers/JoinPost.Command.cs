using MediatR;

namespace BryceResortPatrol.Controllers
{
    public record JoinPostCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Description) : IRequest<JoinPostResponse>;
}
