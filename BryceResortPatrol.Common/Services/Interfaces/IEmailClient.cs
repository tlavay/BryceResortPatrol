using System.Threading.Tasks;

namespace BryceResortPatrol.Common.Services.Interfaces;

public interface IEmailClient
{
    Task Send(string[] recipients, string subject, string plainTextMessage);
}