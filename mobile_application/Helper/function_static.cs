using System;
using System.Collections.Generic;
using System.Text;

namespace mobile_application
{
    public static class function_static
    {
        public static string Create_Kala_Code(string code)
        {
            var len = 20 - code.Length;
            //3 = 20 - 17

            string temp = "";
            for (int i = 0; i < len; i++)
            {
                temp += " ";
            }

            return temp + code;
        }
    }
}
