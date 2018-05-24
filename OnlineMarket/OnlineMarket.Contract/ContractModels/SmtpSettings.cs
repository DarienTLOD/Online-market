namespace OnlineMarket.Contract.ContractModels
{
    public class SmtpSettings
    {
        public bool EnableSsl { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseDefaultCredentials { get; set; }
    }
}
