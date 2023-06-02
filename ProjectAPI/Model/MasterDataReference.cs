using System.Reflection.Metadata.Ecma335;

namespace ProjectAPI.Models
{
    public class MasterDataReference
    {
        public int Id { get; set; }

        public int MasterId { get; set; }   

        public string Description { get; set; }

        public string Mode { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public Boolean IsActive { get; set; } = true;


    }
}
