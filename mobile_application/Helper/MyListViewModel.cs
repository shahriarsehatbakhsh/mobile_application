using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace mobile_application.Helper
{
    public class MyListViewModel
    {
        public ObservableCollection<my_list_model_fields> MyListCollector { set; get; }
        public MyListViewModel()
        {
            MyListCollector = new ObservableCollection<my_list_model_fields>()
            {
                new my_list_model_fields(){ title = "title1", detail="this is a new detail", image_url="image_url.png" },
                new my_list_model_fields(){ title = "title2", detail="this is a new detail", image_url="image_url.png" },
                new my_list_model_fields(){ title = "title3", detail="this is a new detail", image_url="image_url.png" },
                new my_list_model_fields(){ title = "title4", detail="this is a new detail", image_url="image_url.png" },
                new my_list_model_fields(){ title = "title5", detail="this is a new detail", image_url="image_url.png" },
                new my_list_model_fields(){ title = "title6", detail="this is a new detail", image_url="image_url.png" },
                new my_list_model_fields(){ title = "title7", detail="this is a new detail", image_url="image_url.png" },
                new my_list_model_fields(){ title = "title8", detail="this is a new detail", image_url="image_url.png" },
                new my_list_model_fields(){ title = "title9", detail="this is a new detail", image_url="image_url.png" },
            };

        }
    }

    public class my_list_model_fields
    {
        public string title { get; set; }
        public string detail { get; set; }
        public string image_url { get; set; }
    }

}
