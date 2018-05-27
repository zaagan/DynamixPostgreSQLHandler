using System;
using System.Collections;
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
        /// Return object.
        /// </summary>
        /// <param name="objObject">object</param>
        /// <param name="objType">Type of datatype.</param>
        /// <returns>object</returns>
        public static object InitializeObject(object objObject, Type objType)
        {
            PropertyInfo objPropertyInfo;
            object objValue;
            int intProperty;

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);

            // initialize properties
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                objPropertyInfo = (PropertyInfo)objProperties[intProperty];
                if (objPropertyInfo.CanWrite)
                {
                    objValue = null;
                    objPropertyInfo.SetValue(objObject, objValue, null);
                }
            }

            return objObject;

        }




        /// <summary>
        /// Reuturn object based on given parameters.
        /// </summary>
        /// <param name="dr">The DataReader.</param>
        /// <param name="objType">Type od datatype.</param>
        /// <returns>Object</returns>
        public static object FillObject(IDataReader dr, Type objType)
        {
            return FillObject(dr, objType, true);
        }


        public static object FillObject(IDataReader dr, Type objType, bool ManageDataReader)
        {

            object objFillObject;

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);

            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);

            bool Continue;
            if (ManageDataReader)
            {
                Continue = false;
                // read datareader
                if (dr.Read())
                {
                    Continue = true;
                }
            }
            else
            {
                Continue = true;
            }

            if (Continue)
            {
                // create custom business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
            }
            else
            {
                objFillObject = null;
            }

            if (ManageDataReader)
            {
                // close datareader
                if ((dr != null))
                {
                    dr.Close();
                }
            }

            return objFillObject;

        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of FillObject fills a custom business object of a specified type 
        /// from the supplied DataReader
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="dr">The IDataReader to use to fill the object</param>
        /// <returns>The object</returns>
        /// <remarks>This overloads sets the ManageDataReader parameter to true and calls 
        /// the other overload</remarks>
        /// <history>
        /// 	[cnurse]	10/10/2005	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static T FillObject<T>(IDataReader dr)
        {

            return FillObject<T>(dr, true);

        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of FillObject fills a custom business object of a specified type 
        /// from the supplied DataReader
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="dr">The IDataReader to use to fill the object</param>
        /// <param name="ManageDataReader">A boolean that determines whether the DatReader
        /// is managed</param>
        /// <returns>The object</returns>
        /// <remarks>This overloads allows the caller to determine whether the ManageDataReader 
        /// parameter is set</remarks>
        /// <history>
        /// 	[cnurse]	10/10/2005	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static T FillObject<T>(IDataReader dr, bool ManageDataReader)
        {

            T objFillObject;

            bool Continue;
            if (ManageDataReader)
            {
                Continue = false;
                // read datareader
                if (dr.Read())
                {
                    Continue = true;
                }
            }
            else
            {
                Continue = true;
            }

            if (Continue)
            {
                // create custom business object
                objFillObject = CreateObject<T>(dr);
            }
            else
            {
                objFillObject = default(T);
            }

            if (ManageDataReader)
            {
                // close datareader
                if ((dr != null))
                {
                    dr.Close();
                }
            }

            return objFillObject;

        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of CreateObject creates an object of a specified type from the 
        /// provided DataRow
        /// </summary>
        /// <typeparam name="T">The type of the business object</typeparam>
        /// <param name="dr">The DataRow</param>
        /// <returns>The custom business object</returns>
        /// <remarks></remarks>
        /// -----------------------------------------------------------------------------
        private static T CreateObject<T>(DataRow dr)
        {

            PropertyInfo objPropertyInfo;
            object objValue;
            Type objPropertyType = null;
            int intProperty;
            T objObject = Activator.CreateInstance<T>();
            ArrayList objProperties = GetPropertyInfo(objObject.GetType());
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                objPropertyInfo = (PropertyInfo)objProperties[intProperty]; if (objPropertyInfo.CanWrite)
                {
                    objValue = Null.SetNull(objPropertyInfo);
                    try
                    {
                        if (System.Convert.IsDBNull(dr[objPropertyInfo.Name]))
                        {
                            objPropertyInfo.SetValue(objObject, objValue, null);
                        }
                        else
                        {
                            try
                            {
                                objPropertyInfo.SetValue(objObject, dr[objPropertyInfo.Name], null);
                            }
                            catch
                            {
                                try
                                {
                                    objPropertyType = objPropertyInfo.PropertyType;
                                    if (objPropertyType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        int testint = 0;
                                        if (testint.GetType() == dr[objPropertyInfo.Name].GetType())
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, Convert.ToInt32(dr[objPropertyInfo.Name])), null);
                                        }
                                        else
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, dr[objPropertyInfo.Name]), null);
                                        }
                                    }
                                    else
                                    {
                                        objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr[objPropertyInfo.Name], objPropertyType), null);
                                    }
                                }
                                catch
                                {
                                    objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr[objPropertyInfo.Name], objPropertyType), null);
                                }
                            }
                        }
                    }
                    catch
                    {
                        objPropertyInfo.SetValue(objObject, objValue, null);
                    }
                }
            }

            return objObject;

        }



        /// <summary>
        /// Return object of XmlDocument.
        /// </summary>
        /// <param name="objObject">object</param>
        /// <returns>Object of XmlDocument.</returns>
        public static XmlDocument Serialize(object objObject)
        {

            XmlSerializer objXmlSerializer = new XmlSerializer(objObject.GetType());
            StringBuilder objStringBuilder = new StringBuilder();
            TextWriter objTextWriter = new StringWriter(objStringBuilder);
            objXmlSerializer.Serialize(objTextWriter, objObject);
            StringReader objStringReader = new StringReader(objTextWriter.ToString());
            DataSet objDataSet = new DataSet();
            objDataSet.ReadXml(objStringReader);
            XmlDocument xmlSerializedObject = new XmlDocument();
            xmlSerializedObject.LoadXml(objDataSet.GetXml());
            return xmlSerializedObject;

        }




        /// <summary>
        /// Return object based on parameters.
        /// </summary>
        /// <param name="objType">Type od datatype.</param>
        /// <param name="dr">The DataReader</param>
        /// <param name="objProperties">ArrayList</param>
        /// <param name="arrOrdinals">Array of integer.</param>
        /// <returns>Object</returns>
        private static object CreateObject(Type objType, IDataReader dr, ArrayList objProperties, int[] arrOrdinals)
        {

            PropertyInfo objPropertyInfo;
            object objValue;
            Type objPropertyType = null;
            int intProperty;

            //objPropertyInfo.ToString() == BuiltyNumber
            object objObject = Activator.CreateInstance(objType);

            // fill object with values from datareader
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                objPropertyInfo = (PropertyInfo)objProperties[intProperty];
                if (objPropertyInfo.CanWrite)
                {
                    objValue = Null.SetNull(objPropertyInfo);
                    if (arrOrdinals[intProperty] != -1)
                    {
                        if (System.Convert.IsDBNull(dr.GetValue(arrOrdinals[intProperty])))
                        {
                            // translate Null value
                            objPropertyInfo.SetValue(objObject, objValue, null);
                        }
                        else
                        {
                            try
                            {
                                // try implicit conversion first
                                objPropertyInfo.SetValue(objObject, dr.GetValue(arrOrdinals[intProperty]), null);
                            }
                            catch
                            {
                                // business object info class member data type does not match datareader member data type
                                try
                                {
                                    objPropertyType = objPropertyInfo.PropertyType;
                                    //need to handle enumeration conversions differently than other base types
                                    if (objPropertyType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        // check if value is numeric and if not convert to integer ( supports databases like Oracle )
                                        int test = 0;
                                        if (test.GetType() == dr.GetValue(arrOrdinals[intProperty]).GetType())
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, Convert.ToInt32(dr.GetValue(arrOrdinals[intProperty]))), null);
                                        }
                                        else
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, dr.GetValue(arrOrdinals[intProperty])), null);
                                        }
                                    }
                                    else if (objPropertyType.FullName.Equals("System.Guid"))
                                    {
                                        // guid is not a datatype common across all databases ( ie. Oracle )
                                        objPropertyInfo.SetValue(objObject, Convert.ChangeType(new Guid(dr.GetValue(arrOrdinals[intProperty]).ToString()), objPropertyType), null);
                                    }
                                    else
                                    {
                                        // try explicit conversion
                                        objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), objPropertyType), null);
                                    }
                                }
                                catch
                                {
                                    objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), objPropertyType), null);
                                }
                            }
                        }
                    }
                    else
                    {
                        // property does not exist in datareader
                    }
                }
            }

            return objObject;

        }



        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generic version of CreateObject creates an object of a specified type from the 
        /// provided DataReader
        /// </summary>
        /// <typeparam name="T">The type of the business object</typeparam>
        /// <param name="dr">The DataReader</param>
        /// <returns>The custom business object</returns>
        /// <remarks></remarks>
        /// <history>
        /// 	[cnurse]	10/10/2005	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static T CreateObject<T>(IDataReader dr)
        {

            PropertyInfo objPropertyInfo;
            object objValue;
            Type objPropertyType = null;
            int intProperty;

            T objObject = Activator.CreateInstance<T>();

            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objObject.GetType());

            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);

            // fill object with values from datareader
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                objPropertyInfo = (PropertyInfo)objProperties[intProperty];
                if (objPropertyInfo.CanWrite)
                {
                    objValue = Null.SetNull(objPropertyInfo);
                    if (arrOrdinals[intProperty] != -1)
                    {
                        if (System.Convert.IsDBNull(dr.GetValue(arrOrdinals[intProperty])))
                        {
                            // translate Null value
                            objPropertyInfo.SetValue(objObject, objValue, null);
                        }
                        else
                        {
                            try
                            {
                                // try implicit conversion first
                                objPropertyInfo.SetValue(objObject, dr.GetValue(arrOrdinals[intProperty]), null);
                            }
                            catch
                            {
                                // business object info class member data type does not match datareader member data type
                                try
                                {
                                    objPropertyType = objPropertyInfo.PropertyType;
                                    //need to handle enumeration conversions differently than other base types
                                    if (objPropertyType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        // check if value is numeric and if not convert to integer ( supports databases like Oracle )
                                        int testint = 0;
                                        if (testint.GetType() == dr.GetValue(arrOrdinals[intProperty]).GetType())
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, Convert.ToInt32(dr.GetValue(arrOrdinals[intProperty]))), null);
                                        }
                                        else
                                        {
                                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(objPropertyType, dr.GetValue(arrOrdinals[intProperty])), null);
                                        }
                                    }
                                    else
                                    {
                                        // try explicit conversion
                                        objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), objPropertyType), null);
                                    }
                                }
                                catch
                                {
                                    objPropertyInfo.SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), objPropertyType), null);
                                }
                            }
                        }
                    }
                    else
                    {
                        // property does not exist in datareader
                    }
                }
            }

            return objObject;

        }





    }
}
