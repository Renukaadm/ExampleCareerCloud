using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FindIPocoReferences
{
    class Program
    {
        static void Main(string[] args)
        {

            IServiceCollection collection = new ServiceCollection();

            collection.AddTransient(typeof(IDataRepository<>), typeof(EFGenericRepository<>));

            var locator = collection.BuildServiceProvider();


            Type progType = typeof(Program);
            MemberInfo member = progType.GetMembers()
                .Where(m => m.Name == "YourLogicMethod").FirstOrDefault();

            MethodInfo method = (MethodInfo)member;
            ParameterInfo paraMeter = 
                method.GetParameters().Where(p => p.Name == "repo").FirstOrDefault();


        }

        public static void YourLogicMethod(IDataRepository<ApplicantEducationPoco> repo)
        {

        }
    }


    

}
