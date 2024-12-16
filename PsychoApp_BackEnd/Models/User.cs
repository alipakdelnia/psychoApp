namespace psychoApp.Models
{
    public class User
    {
         public int Id { get; set; }
<<<<<<< HEAD

        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
  
=======
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }
>>>>>>> 98d3c957708bcee2e752ba1b932e03fc0f525415

    }
}