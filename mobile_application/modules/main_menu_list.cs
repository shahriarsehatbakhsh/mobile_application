using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace mobile_application.modules
{
    public class main_menu_list
    {

        public ObservableCollection<main_menu_items> application_main_menu_items { set; get; }
        public main_menu_list()
        {

            application_main_menu_items = new ObservableCollection<main_menu_items>()
            {
                new main_menu_items
                {
                    title = "ثبت سفارشات",
                    Description = "در این قسمت شما قادر خواهید بود",
                    picture = "menu01.png",
                    menu_color = "Green",
                    url = "Page1"
                },
                new main_menu_items
                {
                    title = "لیست مشتری ها",
                    Description = "در این قسمت شما قادر خواهید بود",
                    picture = "menu01.png",
                    menu_color = "Red",
                    url = ""
                },
                new main_menu_items
                {
                    title = "لیست کالاها",
                    Description = "در این قسمت شما قادر خواهید بود",
                    picture = "menu01.png",
                    menu_color = "Yellow",
                    url = ""
                },
                new main_menu_items
                {
                    title = "گزارشات",
                    Description = "در این قسمت شما قادر خواهید بود",
                    picture = "menu01.png",
                    menu_color = "Yellow",
                    url = ""
                },
                new main_menu_items
                {
                    title = "اعلانات",
                    Description = "در این قسمت شما قادر خواهید بود",
                    picture = "menu01.png",
                    menu_color = "Yellow",
                    url = ""
                },
                new main_menu_items
                {
                    title = "لیست کالاها",
                    Description = "در این قسمت شما قادر خواهید بود",
                    picture = "menu01.png",
                    menu_color = "Yellow",
                    url = ""
                },
            };
        }

        //public ObservableCollection<main_menu_items> Get_Menu()
        //{
        //    return new ObservableCollection<main_menu_items>
        //    {
        //        new main_menu_items
        //        {
        //            title = "ثبت سفارشات",
        //            Description = "در این قسمت شما قادر خواهید بود",
        //            picture = "menu01.png",
        //            menu_color = "Green",
        //            url = "Page1"
        //        },
        //        new main_menu_items
        //        {
        //            title = "لیست مشتری ها",
        //            Description = "لیست مشتری های ثبت شده را در این قسمت میتوانید مشاهده کنید",
        //            picture = "menu01.png",
        //            menu_color = "Red",
        //            url = ""
        //        },
        //        new main_menu_items
        //        {
        //            title = "لیست کالاها",
        //            Description = "لیست مشتری های ثبت شده را در این قسمت میتوانید مشاهده کنید",
        //            picture = "menu01.png",
        //            menu_color = "Yellow",
        //            url = ""
        //        }
        //    };
        //}
    }

    public class main_menu_items
    {
        public string title { get; set; }
        public string menu_color { get; set; }
        public string Description { get; set; }
        public string picture { get; set; }
        public string url { get; set; }
    }

}