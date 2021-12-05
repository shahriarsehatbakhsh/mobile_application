namespace mobile_application.Service.Helper
{
    public static class Static_Function
    {
        public static string Create_Kala_Code(string code)
        { 
            var len = 20 - code.Length;
            //3 = 20 - 17

            string temp = "";
            for (int i = 0; i < len; i++)
            {
                temp += "0";
            }

            return temp + code;
        }
    }
}
