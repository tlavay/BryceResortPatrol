using MediatR;

namespace BryceResortPatrol.Controllers.Schedule
{
    public record ShiftsGetQuery(string Year) : IRequest<ShiftsGetResponse>;
}
