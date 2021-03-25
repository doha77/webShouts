namespace WebShouts.Models
{
    public class UserWebShoutsVM
    {
        public int WebShoutId { get; set; }
        public string UserName { get; set; }
        public int ApplicationUserId { get; set; }
        public string Content { get; set; }
        public bool HasFollowed { get; set; }
    }
}
