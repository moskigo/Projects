using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppContact.Models
{
    public class Contact
    {
        public int ID { get; set; }
        
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string EmailContact { get; set; }

        public bool? MainContact { get; set; }

        public Guid? GUID { get; set; }

        public string RetailLocationID { get; set; }

        public string AccountType { get; set; }

        public string RetailLocationName { get; set; }

        public double? ContactNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string ActiveInactive { get; set; }

        public string RLProgram { get; set; }

        public string ProgramStage { get; set; }

        public string NutProgram { get; set; }

        public double CaseSales { get; set; }

        public DateTime LastShipmentDate { get; set; }

        public double TotalActivites { get; set; }

        public double Last6MonthsActivityCount { get; set; }

        public double Last12MonthsActivityCount { get; set; }

        public double Last24MonthsActivityCount { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? Deleted { get; set; }

        public string NewFirstName { get; set; }

        public string NewLastName { get; set; }
    }
}