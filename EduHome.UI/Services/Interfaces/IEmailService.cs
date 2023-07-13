namespace EduHome.UI.Services.Interfaces
{
    public interface IEmailService
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string FormAddres { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
