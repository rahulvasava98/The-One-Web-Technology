using Microsoft.EntityFrameworkCore;

namespace The_One_Web_Technology.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<trainingRegistrationmst> trainingRegistrationmsts { get; set; }
        public DbSet<contactMst> contactMsts { get; set; }

        public DbSet<serviceMst> serviceMsts { get; set; }

        //public DbSet<serviceRegistrationMst> serviceRegistrationMsts { get; set; }

        public DbSet<serviceRegistrationMaster> serviceRegistrationMasters { get; set; }

        public DbSet<coursecollectionMst> coursecollectionMsts { get; set;}

        public DbSet<categoriesMst> categoriesMsts { get; set; }
        public DbSet<courseDetailsMst> courseDetailsMsts { get; set; }

        public DbSet<courseRequestHandleMst> courseRequestHandleMsts { get; set; }

        public DbSet<courseLikeMst> courseLikeMsts { get; set; }


        public DbSet<cartMst> cartMsts {  get; set; }   
        

        //courseCategoriesMst
        public DbSet<courseCategoriesMst> courseCategoriesMsts { get; set; }

        public DbSet<courseModuleDetailsMst> courseModuleDetailsMsts { get; set; }

        public DbSet<courseLectureDetailsMst> courseLectureDetailsMsts { get; set; }

        //coursePayMentMst
        public DbSet<coursePaymentRequestMst> coursePaymentRequestMsts { get; set; }

        //Course Refreall Mst
        public DbSet<CourseReffrealMst> courseReffrealMsts { get;set; }

        public DbSet<CourseRefreallMangeMst> courseRefreallMangeMsts { get; set; }


    }
}
