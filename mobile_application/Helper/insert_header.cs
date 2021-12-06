using System;
using System.Collections.Generic;
using System.Text;

using mobile_application.Models;

namespace mobile_application.Helper
{
    public class insert_header
    {
        public bool _insert_header(List<F_hSefareshSeller> header)
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool _insert_details()
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
