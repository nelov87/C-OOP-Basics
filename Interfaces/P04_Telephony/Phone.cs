using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P04_Telephony
{
    /// <summary>
    /// class Phone
    /// </summary>
    public class Phone : ICalls, IBrowse
    {
        
        public string Model { get; set; }

        public Phone()
        {
            Model = "Smartphone";
        }

       
        public string Call(string number)
        {
            if (IsItValidNumber(number))
            {
                return $"Calling... {number}";
            }
            else
            {
                return "Invalid number!";
            }
            
        }

        public string Browse(string site)
        {
            
                if (IsItValidSite(site))
                {
                    return $"Browsing: {site}!";
                }
                else
                {
                    return "Invalid URL!";
                } 
        }

        private bool IsItValidSite(string site)
        {
            
            
            if (site.Any(Char.IsDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsItValidNumber(string number)
        {
            if (number.All(Char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
