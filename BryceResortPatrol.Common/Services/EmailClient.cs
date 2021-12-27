using BryceResortPatrol.Common.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceResortPatrol.Common.Services;

internal sealed class EmailClient : IEmailClient
{
    private readonly SendGridClient sendGridClient;

    public EmailClient(SendGridClient sendGridClient)
    {
        this.sendGridClient = sendGridClient;
    }

    public async Task Send(string recipient, string subject, string plainTextMessage)
    {
        var from = new EmailAddress("doNotReply@brycepatrol.com");
        var to = new EmailAddress(recipient);
        var email = MailHelper.CreateSingleEmail(from, to, subject, plainTextMessage, null);
        await this.sendGridClient.SendEmailAsync(email);
    }
}