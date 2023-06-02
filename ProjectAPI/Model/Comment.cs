namespace ProjectAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public Boolean IsActive { get; set; } = true;
    }
}
