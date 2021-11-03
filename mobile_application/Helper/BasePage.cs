using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace mobile_application.Helper
{
    public class BasePage<T> : ContentPage
    {
        public event Action<T> PageDisapearing;
        protected T _navigationResut;

        public BasePage()
        {
        }

        protected override void OnDisappearing()
        {
            PageDisapearing?.Invoke(_navigationResut);
            if (PageDisapearing != null)
            {
                foreach (var @delegate in PageDisapearing.GetInvocationList())
                {
                    PageDisapearing -= @delegate as Action<T>;
                }
            }
            base.OnDisappearing();
        }
    }
}
