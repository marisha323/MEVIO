namespace MEVIO.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }

        //ClientStatus
        public int ClientStatusId { get; set; }
        public ClientStatus? ClientStatus { get; set; }

        public string? PassportNumber { get; set; }
    }
    

}
