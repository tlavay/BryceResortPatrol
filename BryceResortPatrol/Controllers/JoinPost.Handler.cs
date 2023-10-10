using System;
using System.Threading;
using System.Threading.Tasks;
using BryceResortPatrol.Common.DataServices;
using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Services.Interfaces;
using MediatR;

namespace BryceResortPatrol.Controllers;

internal class JoinPostHandler : IRequestHandler<JoinPostCommand, JoinPostResponse>
{
    private readonly IEmailClient emailClient;

    public JoinPostHandler(IEmailClient emailClient)
    {
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

        var message = @$"A new candidate would like more information about the patrol.
                        {candidate}
        
                        This is an automated message.
                        Email tnlavay@gmail.com for techincal support.";
        var recipients = new string[] { "glenn@bryceresort.com", "tnlavay@gmail.com" };
        var emailTask = this.emailClient.Send(recipients, $"New Candidate Alert: Name: {candidate.FirstName}", message);
        await Task.WhenAll(createTask, emailTask);
        return new JoinPostResponse();
    }
}