using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInformation.Domain.Models
{
    public class PatientNCDs :BaseEntity
    {
        public long PatientId { get; set; }//fk
        public long NonCommunicableDiseaseId { get; set; }//fk
        public virtual NonCommunicableDisease NonCommunicableDisease { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
