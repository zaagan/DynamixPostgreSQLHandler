using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// References: 
/// http://logicsmaze.blogspot.com/p/c.html
/// https://github.com/SageFrame/SageFrameV3.6/tree/master/SageFrame.Common/Shared
/// </summary>
namespace DynamixPostgreSQLHandler.Helpers
{
    public partial class DataSourceHelper
    {


        /// <summary>
        /// Return list of array.
        /// </summary>
        /// <param name="dr">The DataReader</param>
        /// <param name="objType">Type od datatype.</param>
        /// <returns>Object of ArrayList</returns>
        public static ArrayList FillCollection(IDataReader dr, Type objType)
        {

            ArrayList objFillCollection = new ArrayList();
            object objFillObject;

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);

            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);

            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                // add to collection
                objFillCollection.Add(objFillObject);
            }

            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }

            return objFillCollection;

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr">The DataReader.</param>
        /// <param name="objType">Type of datatype.</param>
        /// <param name="objToFill">The List.</param>
        /// <returns>Object of list.</returns>
        public static IList FillCollection(IDataReader dr, Type objType, ref IList objToFill)
        {

            object objFillObject;

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);

            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);

            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                // add to collection
                objToFill.Add(objFillObject);
            }

            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }

            return objToFill;

        }




        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of FillCollection fills a List custom business object of a specified type 
        /// from the supplied DataReader
        /// </summary>
        /// <typeparam name="T">The type of the business object</typeparam>
        /// <param name="dr">The IDataReader to use to fill the object</param>
        /// <returns>A List of custom business objects</returns>
        /// <remarks></remarks>
        public static List<T> FillCollection<T>(IDataReader dr)
        {
            List<T> objFillCollection = new List<T>();
            T objFillObject;

            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject<T>(dr);
                // add to collection
                objFillCollection.Add(objFillObject);
            }

            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }

            return objFillCollection;

        }



        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of FillCollection fills a provided IList with custom business 
        /// objects of a specified type from the supplied DataReader
        /// </summary>
        /// <typeparam name="T">The type of the business object</typeparam>
        /// <param name="dr">The IDataReader to use to fill the object</param>
        /// <param name="objToFill">The IList to fill</param>
        /// <returns>An IList of custom business objects</returns>
        /// <remarks></remarks>
        public static IList<T> FillCollection<T>(IDataReader dr, ref IList<T> objToFill)
        {

            T objFillObject;

            while (dr.Read())
            {
                objFillObject = CreateObject<T>(dr);
                objToFill.Add(objFillObject);
            }

            if ((dr != null))
            {
                dr.Close();
            }

            return objToFill;

        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of FillCollection fills a List custom business object of a specified type 
        /// from the supplied DataTable
        /// </summary>
        /// <typeparam name="T">The type of the business object</typeparam>
        /// <param name="dt">The DataTable to use to fill the object</param>
        /// <returns>A List of custom business objects</returns>
        /// <remarks></remarks>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public static List<T> FillCollection<T>(DataTable dt)
        {
            List<T> objFillCollection = new List<T>();
            T objFillObject;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objFillObject = CreateObject<T>(dt.Rows[i]);
                objFillCollection.Add(objFillObject);
            }
            return objFillCollection;
        }



    }
}
