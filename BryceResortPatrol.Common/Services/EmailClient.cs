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

    public async Task Send(string[] recipients, string subject, string plainTextMessage)
    {
        var from = new EmailAddress("donotreply@brycepatrol.com");
        var tos = recipients.Select(recipient => new EmailAddress(recipient)).ToList();
        var email = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, plainTextMessage, null);
        var response = await this.sendGridClient.SendEmailAsync(email);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"An erro occured sening email. Email Message: {plainTextMessage}");
        }
    }
}