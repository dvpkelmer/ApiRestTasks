using ApiRestTask.Application.DTOs;
using ApiRestTask.Domain.Entities;

namespace ApiRestTask.Application.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendMail(MailData Mail_Data);
    }
}
