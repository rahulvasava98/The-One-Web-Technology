using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_One_Web_Technology.Data
{
    public class CourseReferralMangeMst
    {
        [Key]
        public int id { get; set; }
        public int usershareid { get; set; }
        public int userid { get; set; }
        public DateTime date { get; set; } = DateTime.Now;

        [ForeignKey("CourseReffrealMst")]
        public int refreallid { get; set; }
        public CourseReferralMst CourseReffrealMst { get; set; }
    }
}
