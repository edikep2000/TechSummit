using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouthConference.Models.ViewModels
{
   public class RegistrantViewModel
    {
       public int Id { get; set; }

       [Display(Name = "Full Name")]
       [Required]
       [StringLength(100)]
       public String FullName { get; set; }

       [EmailAddress]
       [Required]
       [StringLength(100)]
       [Display(Name = "Email Address")]
       public String EmailAddress { get; set; }

       [Required]
       [StringLength(100)]
       [Display(Name = "Phone Number")]
       public String PhoneNumber { get; set; }

       [Required]
       [StringLength(100)]
       [Display(Name = "Gender")]
       public String Gender { get; set; }

       [Required]
       [StringLength(100)]
       [Display(Name = "State")]
       public String State { get; set; }


       [StringLength(100)]
       [Display(Name = "Institution of Study")]
       public String Institution { get; set; }

         [StringLength(100)]
       [Display(Name = "Course Of Study (If Applicable)")]
       public String CourseOfStudy { get; set; }

       [Required]
       [StringLength(100)]
       public String Country { get; set; }
      
     
    }
}
