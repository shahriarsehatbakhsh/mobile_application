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
                new Onboarding{Heading = "الگوریتم پویا",Caption = "توضیحات مربوط به سیستم های پایا به شرح زیر میباشد همراه با متن"},
                new Onboarding{Heading = "سیستم فروش پایا",Caption = "توضیحات مربوط به سیستم های پایا به شرح زیر میباشد همراه با متن"},
                new Onboarding{Heading = "سیستم های الگوریتم پویا",Caption = "توضیحات مربوط به سیستم های پایا به شرح زیر میباشد همراه با متن"}
            };
        }
    }

    public class Onboarding
    { 
        public string Heading { get; set; }
        public string Caption { get; set; }
    }

}