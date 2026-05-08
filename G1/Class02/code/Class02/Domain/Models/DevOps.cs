using Domain.BaseEntity;

namespace Domain.Models
{
    public class DevOps : Person
    {
        public bool AWSCertified { get; set; }
        public bool AzureCertified { get; set; }

        public DevOps(
            string firstName, 
            string lastName, 
            int age, 
            string mobileNumber,
            bool hasAwsCertificate,
            bool hasAzureCertificate) 
            : base(firstName, lastName, age, mobileNumber)
        {
            AWSCertified = hasAwsCertificate;
            AzureCertified = hasAzureCertificate;
        }

    }
}
