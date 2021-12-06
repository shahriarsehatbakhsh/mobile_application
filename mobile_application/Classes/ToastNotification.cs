
using Android.Widget;


namespace mobile_application
{
    public static class ToastNotification
    {
        public static void TostMessage(string message)
        {
            var context = Android.App.Application.Context;
            var tostMessage = message;
            var durtion = ToastLength.Long;


            Toast.MakeText(context, tostMessage, durtion).Show();
        }
    }
}