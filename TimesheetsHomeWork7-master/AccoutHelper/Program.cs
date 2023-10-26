using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccoutHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PasswordUtils.CreatePasswordHash("12345"));
            // (6saAOjm3IHoDEtN3pR065w==, SZ/2iDPgKvL2IVg1WLjOfza36c3x+GViMpbSJaMXmPHtM79g2OnAVjjPVZUJEzrfu20DU7zIGNqr2Ihajri2hg==)
        }
    }
}
