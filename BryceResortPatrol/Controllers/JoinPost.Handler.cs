using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Repositories;
using BryceResortPatrol.Common.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BryceResortPatrol.Controllers;

public class JoinPostHandler : IRequestHandler<JoinPostCommand, JoinPostResponse>
{
    private readonly DatabaseContext databaseContext;
    private readonly IEmailClient emailClient;

    public JoinPostHandler(DatabaseContext databaseContext, IEmailClient emailClient)
    {
        this.databaseContext = databaseContext;
        this.emailClient = emailClient;
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

        var createTask = this.databaseContext.Candidate.CreateItemAsync<Candidate>(candidate);
        var message = $"A new candidate would like more information about the patrol./r/n {candidate}/r/nThis is an automated message./r/nEmail tnlavay@gmail.com for techincal support.";
        var emailTask = this.emailClient.Send("tnlavay@gmail.com", $"New Candidate Alert: Name: {candidate.FirstName}", message);
        await Task.WhenAll(createTask, emailTask);
        return new JoinPostResponse();
    }
}