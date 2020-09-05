using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public interface IService
{
    [OperationContract]
    ApplicantEducationPoco Get(Guid id);
    [OperationContract]
    List<ApplicantEducationPoco> GetAll();
    [OperationContract]
    void Update(ApplicantEducationPoco[] pocos);
    [OperationContract]
    void Add(ApplicantEducationPoco[] pocos);
    [OperationContract]
    void Delete(ApplicantEducationPoco[] pocos);

}


public class ApplicantEducationPoco 
{
    public Guid Id { get; set; }
    public Guid Applicant { get; set; }
    public string Major { get; set; }
    public string CertificateDiploma { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public Byte? CompletionPercent { get; set; }
    public Byte[] TimeStamp { get; set; }
}



