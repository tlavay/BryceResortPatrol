using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BryceResortPatrol.Controllers
{
    public class JoinPostHandler : IRequestHandler<JoinPostCommand, JoinPostResponse>
    {
        private readonly DatabaseContext databaseContext;

        public JoinPostHandler(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<JoinPostResponse> Handle(JoinPostCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Description = request.Description
            };

            await this.databaseContext.Candidate.CreateItemAsync<Candidate>(candidate);
            return new JoinPostResponse();
        }
    }
}
