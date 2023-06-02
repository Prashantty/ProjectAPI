namespace ProjectAPI.Models
{
    public class City
    {

        public int Id { get; set; }

        public string CityName { get; set; }  
        
        public CountryReference Country { get; set; }

        public int CountryId { get; set; }  

    }
}
