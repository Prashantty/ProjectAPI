using Microsoft.VisualBasic;
using System.Data;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace ProjectAPI.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string UserName { get; set; }

        public UserRoleMapping userRoleMapping { get; set; }

        public int UserRoleMappingId { get; set; }

        public string ProjectName { get; set; }
        public string ReasonForTraveling { get; set; }

        public string TypeOfBooking { get; set; }

        public string AadharNumber { get; set; }    
        public string AadharPath { get; set; }  
        public string VisaNumber { get; set; }  

        public string VisaPath { get; set; }    
        public string PassportNumber { get; set; }  

        public string PassportPath { get; set; }    

        public string CreatedBy { get; set; }   
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string  ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public Boolean IsActive { get; set; }   
        public Comment Comment { get; set; }
        public int CommentId { get; set; }



    }
}
