using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCloud.GraphQL.GraphQL
{
    public class Query
    {
        private IDataRepository<ApplicantEducationPoco> _repo;

        public Query(IDataRepository<ApplicantEducationPoco> repo )
        {
            _repo = repo;
        }

        public IQueryable<ApplicantEducationPoco>
            ApplicantEducations => _repo.GetAll();
    }
}
