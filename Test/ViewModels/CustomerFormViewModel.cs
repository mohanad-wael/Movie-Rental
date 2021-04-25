using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }
}