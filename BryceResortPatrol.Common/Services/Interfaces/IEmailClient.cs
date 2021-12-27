using System.Threading.Tasks;

namespace BryceResortPatrol.Common.Services.Interfaces;

public interface IEmailClient
{
    Task Send(string recipient, string subject, string plainTextMessage);
}