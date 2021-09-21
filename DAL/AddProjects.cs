using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public enum ProjectPriority
    {
        Low = 1,            // low has a value of 1
        Medium = 2,         // medium has a value 2
        High = 3            // High has a value 3
    }
    public class AddProjects
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        //DateTime is formatted to DD-MM-YYYY
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProjectStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProjectEndDate { get; set; }

        public ProjectPriority projectPriority { get; set; }

        //public int ProjectPriority { get; set; }

        public string EmpId { get; set; }
    }
}
