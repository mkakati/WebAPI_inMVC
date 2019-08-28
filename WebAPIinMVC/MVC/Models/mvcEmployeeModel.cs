using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    
    public class mvcEmployeeModel /*: ISerializable*/
    {

        public int EmployeeID { get; set; }
        [Required(ErrorMessage= "This field is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public string Position { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public Nullable<int> Age { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public Nullable<int> Salary { get; set; }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("EmployeeID", EmployeeID);
        //    info.AddValue("Name", Name);
        //    info.AddValue("Position", Position);

            
        //}
    }
}