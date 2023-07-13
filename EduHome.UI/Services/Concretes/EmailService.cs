using EduHome.UI.Services.Interfaces;

namespace EduHome.UI.Services.Concretes
{
    public class EmailService : IEmailService
    {
        public string Server { get ; set ; }
        public int Port { get ; set ; }
        public string FormAddres { get ; set  ; }
        public string UserName { get  ; set  ; }
        public string Password { get ; set  ; }
    }
}
