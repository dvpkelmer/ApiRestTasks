using ApiRestTask.Application.Interfaces;

namespace ApiRestTask.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        IEmailService Email_Service = null;
        //injecting the IMailService into the constructor
        public MailController(IEmailService _emailService)
        {
            Email_Service = _emailService;
        }
        [HttpPost]
        public async Task<bool> SendMail(MailData Mail_Data)
        {
            return await Email_Service.SendMail(Mail_Data);
        }
    }


}