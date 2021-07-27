using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraineeRegistrationApplication.Models
{
    public class Picture
    {
        public string traineeId { get; set; }
        public HttpPostedFileBase File { get;set;}
    }
}