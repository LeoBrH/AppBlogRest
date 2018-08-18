using SQLite;

namespace AppBlogRest.Models.Entities
{
    public partial class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public partial class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }

    public partial class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }

    public class UserJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }
    }


    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Address_Street { get; set; }
        public string Address_Suite { get; set; }
        public string Address_City { get; set; }
        public string Address_Zipcode { get; set; }

        public string Address_Geo_Lat { get; set; }
        public string Address_Geo_Lng { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }

        public string Company_Name { get; set; }
        public string Company_CatchPhrase { get; set; }
        public string Company_Bs { get; set; }
    }
}
