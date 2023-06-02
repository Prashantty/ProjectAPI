using Microsoft.AspNetCore.Identity;

namespace ProjectAPI.Models
{
    public class Booking
    {

        public int BookingId  { get; set; }

        public string TypeOfBooking{ get; set; }

        public int DaysOfStay { get; set; }
        public bool MealRequired { get; set; }

        public string MealType { get; set; } //Type = breakfast , lunch

        public string MealChoice { get; set; } // Choice = veg , non-veg
              

        //Foreign Key Reference

        public City City { get; set; }
        public int CityId { get; set; }

        public Request Request { get; set; }

        public int RequestId { get; set; }




    }

}
