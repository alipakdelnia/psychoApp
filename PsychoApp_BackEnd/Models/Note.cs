namespace psychoApp.Models
{
    public class Note : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }

        //Foregin key for user
        public int UserId { get; set; }

        //Navigation for user 
        public User User { get; set; }
    }
}
