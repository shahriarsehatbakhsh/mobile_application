using System;
using System.Collections.Generic;
using System.Text;

namespace ElegantLandingPage
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Onboarding = GetOnboarding();
        }

        public List<Onboarding> Onboarding { get; set; }



        private List<Onboarding> GetOnboarding()
        {
            return new List<Onboarding>
            {
                new Onboarding{Heading = "",Caption = ""},
                new Onboarding{Heading = "",Caption = ""},
                new Onboarding{Heading = "",Caption = ""}
            };
        }
    }

    public class Onboarding
    { 
        public string Heading { get; set; }
        public string Caption { get; set; }
    }

}