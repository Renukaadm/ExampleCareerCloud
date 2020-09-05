using CareerCloud.ADODataAccessLayer;
using System;

namespace ADOTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicantEducationRepository repo = 
                new ApplicantEducationRepository();


            var result = 
                repo.GetSingle(x => x.Id == Guid.Parse("0FC77D6E-134C-0D88-ACFE-4D10777B3712"));





        }
    }
}
