namespace findmytutor.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public int City { get; set; }
    }
}