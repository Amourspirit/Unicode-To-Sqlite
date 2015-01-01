using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace UCD.DataCommon
{
    /// <summary>
    /// Misc methods for helping process data
    /// </summary>
    class DataHelper
    {
        #region StringToBool
        // static 
        /// <summary>
        /// Static method. Converts expected xml values from string to boolean values for UCD xml entries
        /// </summary>
        /// <param name="value">
        /// The string to parse for string representations of boolean.Case Insensitive.
        /// Valid values are Y,N,1,0,t,f,true,false
        /// </param>
        /// <returns>
        /// Return true if a valid true value if found in <paramref name="value"/> otherwise false.
        /// </returns>
        public static bool StringToBool(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            bool retval;
            string str = value.ToLowerInvariant();
            switch (str)
            {
                case "y":
                    retval = true;
                    break;
                case "1":
                    retval = true;
                    break;
                case "t":
                    retval = true;
                    break;
                case "true":
                    retval = true;
                    break;
                default:
                    retval = false;
                    break;
            }
            return retval;
        }
        #endregion
        #region YesNoMabeyToInt32
        // static 
        /// <summary>
        /// Static method. Converts expected xml values from string to Yes,No, Maybe for UCD xml entries
        /// </summary>
        /// <param name="value">
        /// The string to parse for string representations of Yes, No, Maybe. Case Insensitive.
        /// Valid values are Y,N,M
        /// </param>
        /// <returns>
        /// Return 0 for false, 1 for true and 2 for Maybe if found in <paramref name="value"/> otherwise 0.
        /// </returns>
        public static Int32 YesNoMabeyToInt32(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }
            Int32 retval;
            string str = value.ToLowerInvariant();
            switch (str)
            {
                case "y":
                    retval = 1;
                    break;
                case "m":
                    retval = 2;
                    break;
                default:
                    retval = 0;
                    break;
            }
            return retval;
        }
        #endregion
        #region ThrowIfNull
        /// <summary>
        /// Static method. Throws Exception if <paramref name="value"/> is null or white space value
        /// </summary>
        /// <param name="value">The string value to check</param>
        /// <returns>
        /// <paramref name="vlaue"/> if no exception is thrown.
        /// </returns>
        public static string ThrowIfNull(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Required value is null");
            }
           return value;
        }


        /// <summary>
        /// Static method. Throws Exception if <paramref name="value"/> is null or white space value
        /// </summary>
        /// <param name="value">The string value to check</param>
        /// <param name="ParamName">The name of the parameter that is being checked</param>
        /// <returns>
        /// <paramref name="vlaue"/> if no exception is thrown.
        /// </returns>
        /// <remarks>
        /// If null exception thrown will contain <paramref name="ParaName"/> in the message.
        /// </remarks>
        public static string ThrowIfNull(string value, string ParamName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception(string.Format("Required value is null: '{0}'", ParamName));
            }
            return value;
        }
        #endregion
        #region StringToDecimal
        /// <summary>
        /// Static Method. Converts expected xml values from string to decimal values for UCD xml entries
        /// </summary>
        /// <param name="value">The string to convert to decimal.</param>
        /// <returns>
        /// Returns <paramref name="value"/> as decimal if successful conversion.
        /// If conversion fails 0.0 is returned
        /// </returns>
        public static decimal StringToDecimal(string value)
        {
            return DataHelper.StringToDecimal(value, 0.0m);
        }
        /// <summary>
        /// Static Method. Converts expected xml values from string to decimal values for UCD xml entries
        /// </summary>
        /// <param name="value">The string to convert to decimal.</param>
        /// <param name="DefaultVal">The decimal value to retrun if conversion fails</param>
        /// <returns>
        /// Returns <paramref name="value"/> as decimal if successful conversion otherwise
        /// returns <paramref name="DefaultVal"/>
        /// </returns>
        public static decimal StringToDecimal(string value, decimal DefaultVal)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return DefaultVal;
            }
            decimal retval;
            string str = value.ToLowerInvariant();
            if (!decimal.TryParse(value, out retval))
                retval = DefaultVal;
            return retval;
        }
        #endregion
        #region StringToInt32
        /// <summary>
        /// Static Method. Converts expected xml values from string to integer values for UCD xml entries
        /// </summary>
        /// <param name="value">The string value to convert for interger</param>
        /// <returns>
        /// Returns <paramref name="value"/> as decimal if successful conversion.
        /// If conversion fails 0.0 is returned
        /// </returns>
        public static Int32 StringToInt32(string value)
        {
            return DataHelper.StringToInt32(value, 0);
        }

        /// <summary>
        /// Static Method. Converts expected xml values from string to integer values for UCD xml entries
        /// </summary>
        /// <param name="value">The string to convert to integer.</param>
        /// <param name="DefaultVal">The integer value to retrun if conversion fails</param>
        /// <returns>
        /// Returns <paramref name="value"/> as integer if successful conversion otherwise
        /// returns <paramref name="DefaultVal"/>
        /// </returns>
        public static Int32 StringToInt32(string value, Int32 DefaultVal)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return DefaultVal;
            }
            Int32 retval;

            if (!Int32.TryParse(value, out retval))
                retval = DefaultVal;
            return retval;
        }
        #endregion
        #region HexStringToInt32
        /// <summary>
        /// Static Method. Converts expected xml values from string containing HEX value to integer values for UCD xml entries
        /// </summary>
        /// <param name="value">The string containing HEX value to convert to integer.</param>
        /// <returns>
        /// Returns <paramref name="value"/> as integer if successful conversion.
        /// If conversion fails 0 is returned
        /// </returns>
        public static Int32 HexStringToInt32(string value)
        {
            return DataHelper.HexStringToInt32(value, 0);
        }
        
        /// <summary>
        /// Static Method. Converts expected xml values from string containing HEX value to integer values for UCD xml entries
        /// </summary>
        /// <param name="value">The string containing HEX value to convert to integer.</param>
        /// <param name="DefaultVal">The integer value to retrun if conversion fails</param>
        /// <returns>
        /// Returns <paramref name="value"/> as integer if successful conversion otherwise
        /// returns <paramref name="DefaultVal"/>
        /// </returns>
        public static Int32 HexStringToInt32(string value, Int32 DefaultVal)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return DefaultVal;
            }
            Int32 retval;

            NumberStyles ns = (NumberStyles.AllowHexSpecifier | NumberStyles.HexNumber);
            try
            {
                retval = Int32.Parse(value, ns);
            }
            catch
            {
                retval = DefaultVal;
            }
                return retval;
        }
        #endregion
        #region HexStringToInt32Null

        /// <summary>
        /// Static Method. Converts expected xml values from string containing HEX value to integer values for UCD xml entries
        /// </summary>
        /// <param name="value">The string containing HEX value to convert to integer.</param>
        /// <returns>
        /// Returns <paramref name="value"/> as integer if successful conversion.
        /// If conversion fails null is returned
        /// </returns>
        public static Int32? HexStringToInt32Null(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            Int32? retval = null;


            NumberStyles ns = (NumberStyles.AllowHexSpecifier | NumberStyles.HexNumber);
            try
            {
                retval = Int32.Parse(value, ns);
            }
            catch
            {
                retval = null;
            }
            return retval;
        }
        #endregion
        #region Split Hex String
        /// <summary>
        /// Converts strings containg hex values ("304B 309A") seperated by white space into a list of integers.
        /// </summary>
        /// <param name="input">The string to split from hex values to integer list</param>
        /// <returns>
        /// Returns a list of integer representing the the hex values in the order the hex values
        /// are found in <paramref name="input"/>. If not match is found an empty list of integer is returned
        /// </returns>
        /// <remarks>
        /// There is not limit to the number of Hex values that can be parsed at once.
        /// Some valid values for <paramref name="input"/>: "23AB" "27ac A56B" "8BC3 B3F5 1455   34FD F49A"
        /// The number or white spaces between hex values in the string does not matter.
        /// </remarks>
        public static List<Int32> SplitHexString(String input)
        {
            List<Int32> values = new List<Int32>();
            if (String.IsNullOrWhiteSpace(input))
            {
               return values;
            }
            Regex regex = new Regex(
                "([0-9A-Fa-f]{4})(?=\\s+|$)",
                RegexOptions.IgnoreCase
                | RegexOptions.Multiline
                | RegexOptions.CultureInvariant
                | RegexOptions.Compiled
                );

            // Test to see if there is a match in the InputText
            bool IsMatch = regex.IsMatch(input);
            if (IsMatch)
            {
                // Capture all Matches in the InputText
                MatchCollection ms = regex.Matches(input);
                for (int i = 0; i < ms.Count; i++)
                {
                    values.Add(DataHelper.HexStringToInt32(ms[i].Value, -1));
                }
               
                return values;
            }
            return values;
        }
        #endregion
    }
}
