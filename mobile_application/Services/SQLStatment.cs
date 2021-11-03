using System;
using System.Collections.Generic;
using System.Text;

namespace mobile_application.Services
{
    public static class SQLStatment
    {


        private static string _object_name =
                                                "SELECT DISTINCT Fkal01 AS Code,Fkal02 AS Sharh " +
                                                "FROM F_Kala " +
                                                "WHERE ISNULL(Fkal16,0)=0 AND Fkal00= 1 " +
                                                "AND (Fkal02 Like '%@objName%')";
        /// <summary>
        /// sql parameter is @objName
        /// </summary>
        public static string object_search_query
        {
            get 
            {
                return _object_name; 
            }   
        }

    }
}
