using System.ComponentModel.DataAnnotations;

namespace DBrokerAPI.Model
{
    public class CRData
    {
        [Key]
        public string CrNumber { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
    }
}
