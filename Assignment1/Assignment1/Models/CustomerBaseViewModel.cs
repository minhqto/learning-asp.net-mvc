using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Assignment1.Models
{
    //this class is for displaying info on the screen to the user
    //it contains the data we'll be displaying on our view
    public class CustomerBaseViewModel : CustomerAddViewModel
    {
        //CustomersBaseViewModel()
        //{

        //}
        [Key]
        public int CustomerId { get; set; } //we know this is the primary key because by convention, primary keys are ints
        //and are in the format <entityName>Id

     
    }
}