namespace RATA.Shared.Models
{
    public class Tenant
    { 
        public int ID { get; set; }
        public string TenantName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime RentedDate { get; set; }
        public decimal Advance { get; set; }
        public string PermanentAddress { get; set; }
        public string SiteNumber { get; set; }
        public string FlatNumber { get; set; }
        public DateTime VacatedDate { get; set; }
        public decimal Rent { get; set; }
    }
}
