using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace DynamixPostgreSQLHandler.Helpers
{
    public partial class DataSourceHelper
    {
        /// <summary>
        /// Return array list from object.
        /// </summary>
        /// <param name="objType">Type od datatype.</param>
        /// <returns>Array list</returns>
        public static ArrayList GetPropertyInfo(Type objType)
        {

            // Use the cache because the reflection used later is expensive
            ArrayList objProperties = null;

            if (objProperties == null)
            {
                objProperties = new ArrayList();
                foreach (PropertyInfo objProperty in objType.GetProperties())
                {
                    objProperties.Add(objProperty);
                }
            }

            return objProperties;

        }
        /// <summary>
        /// Return object of array of integer.
        /// </summary>
        /// <param name="objProperties">ArrayList</param>
        /// <param name="dr">The DataReader</param>
        /// <returns>Array of integer.</returns>
        private static int[] GetOrdinals(ArrayList objProperties, IDataReader dr)
        {

            int[] arrOrdinals = new int[objProperties.Count + 1];
            int intProperty;

            if ((dr != null))
            {
                for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
                {
                    arrOrdinals[intProperty] = -1;
                    try
                    {
                        arrOrdinals[intProperty] = dr.GetOrdinal(((PropertyInfo)objProperties[intProperty]).Name);
                    }
                    catch
                    {
                        // property does not exist in datareader
                    }
                }
            }

            return arrOrdinals;

        }


    }
}
