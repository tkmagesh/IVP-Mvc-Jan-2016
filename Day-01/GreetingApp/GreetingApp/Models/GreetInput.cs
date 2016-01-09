using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreetingApp.Models
{
    public class GreetInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IDictionary<string, string> ErrorMessages { get; set; }

        public GreetInput()
        {
            ErrorMessages = new Dictionary<string, string>();
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.FirstName))
                ErrorMessages.Add("FirstName", "First Name cannot be empty!");
            if (string.IsNullOrEmpty(this.LastName))
                ErrorMessages.Add("LastName", "Last Name cannot be empty!");
        }

        public bool IsValid
        {
            get { return ErrorMessages.Count <= 0; }
        }

        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}