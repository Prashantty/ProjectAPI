namespace ProjectAPI.Models
{
    public class UserRoleMapping
    {
        public int Id  { get; set; }    

        public User User { get; set; }
        public int UserId { get; set; }    

        public Department Department { get; set; }
        public int DepartmentId { get; set; }   

        public Role Role { get; set; }  

        public int RoleId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public Boolean IsActive { get; set; } = true;

    }
}
