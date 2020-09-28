using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

using System.Security.Cryptography;
using System.IO;

using System.Drawing;

using System.Reflection;
using System.Net.NetworkInformation;

 
namespace common
{
    public class clsCommon
    {
        #region Variables
        public const string ReplicateDBString = "[*#DBNAME#*]";

        public const string HistTablePostFix = "_Hist_Data";
        public const string HistTableColHistBy = "Hist_By";
        public const string HistTableColHistOn = "Hist_On";
        public const string HistTableColHistVersion = "Hist_Version";

        private static int intItemCount = 0;
        private static string loginid = "";
        private static string strSql;
        private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

        static frmProgressBar frmPB = new frmProgressBar();
        static Thread thProgressBar;
        private static string ExportReportHeading = "";
        private static List<String> ExportArrHeader = null;
        
        #endregion

        public static int myLen(object value)
        {
            if (value == null || value is DBNull || value == string.Empty)
            {
                return 0;
            }
            return Convert.ToString(value).Trim().Length;
        }

        public static string LoginId
        {
            get
            {
                return loginid;
            }
            set
            {
                loginid = value;
            }
        }

        public static string myCstr(object value)
        {
            try
            {
                if (value == null || value is DBNull || value == string.Empty)
                {
                    return "";
                }
                return Convert.ToString(value).Trim();
            }
            catch (Exception err)
            {
                return "";
            }
        }

        //public static DataTable getPermission()
        //{
        //    //strSql="exec proc_getPermission " + clsCommon.myCstr(LoginId) + "";
        //    //return clsDBFuncationality.GetDataTable(strSql);            
        //    return null;
        //}

        //public static DataRow getPermissionFormWise(string FormName)
        //{
        //    DataTable dt = new DataTable();
        //    dt = getPermission();
        //    DataRow[] dr = dt.Select("Project_Resource='" + FormName + "'");
        //    if (dt.Rows.Count > 0)
        //    {
        //        return dr[0];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public static bool myCBool(object value)
        {
            if (value == null || value is DBNull)
            {
                return false;
            }
            return Convert.ToBoolean(value);
        }

        public static DateTime myCDate(object value)
        {
            return myCDate(value, "dd-MMM-yyyy hh:mm:ss tt");
        }

        public static DateTime myCDate(object value, string strFormat)
        {
            return Convert.ToDateTime(Convert.ToDateTime(value).ToString(strFormat));
        }

        public static double myCdbl(object value)
        {
            double dblRet = 0;
            try
            {
                dblRet = Convert.ToDouble(value);
                if (dblRet == null || dblRet is DBNull || double.IsInfinity(dblRet) || double.IsNaN(dblRet)
                    || double.IsNegativeInfinity(dblRet) || double.IsPositiveInfinity(dblRet)
                    || dblRet < double.MinValue || dblRet > double.MaxValue)
                {
                    dblRet = 0;
                }
            }
            catch (Exception err)
            {
                dblRet = 0;
            }
            return dblRet;
        }

        public static CompairStringResult CompairString(string strFirst, string strSecond)
        {
            return CompairString(strFirst, strSecond, false);
        }
        public static CompairStringResult CompairString(string strFirst, string strSecond, bool isCaseSencitive)
        {
            int x = string.Compare(myCstr(strFirst), myCstr(strSecond), !isCaseSencitive);
            if (x == 0)
            {
                return CompairStringResult.Equal;
            }
            else if (x < 0)
            {
                return CompairStringResult.Less;
            }
            else
            {
                return CompairStringResult.Greater;
            }
        }

        public static void AddColumnsForChange(Hashtable ht, string strColName, object objValue)
        {
            AddColumnsForChange(ht, strColName, objValue, false);
        }

        public static void AddColumnsForChange(Hashtable ht, string strColName, object objValue, bool NullIfBlank)
        {
            string strValue;
            if (IsDecimalNumber(objValue))
            {
                strValue = String.Format("{0:F10}", objValue);
                ht.Add(strColName, NullIfBlank && clsCommon.myLen(objValue) <= 0 ? "null" : strValue);
            }
            else
            {
                strValue = clsCommon.myCstr(objValue).Replace("'", "''");
                ht.Add(strColName, NullIfBlank && clsCommon.myLen(objValue) <= 0 ? "null" : "'" + strValue + "'");
            }
        }

        public static DateTime GETSERVERDATE()
        {
            return GETSERVERDATE(null);
        }

        public static DateTime GETSERVERDATE(SqlTransaction trans)
        {
            return GETSERVERDATE(trans, "dd-MMM-yyyy hh:mm:ss tt");
        }

        public static DateTime GETSERVERDATE(SqlTransaction trans, string strFormat)
        {
            DateTime dt = new DateTime();
            try
            {
                dt = clsCommon.myCDate(clsDBFuncationality.getSingleValue("select getdate()", trans), strFormat);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                //db.Close();
            }
            return dt;
        }

        public static DateTime GetDateWithStartTime(DateTime dt)
        {
            dt = clsCommon.myCDate(dt);
            DateTime dtReturn = new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 00);
            return dtReturn;
        }

        public static DateTime GetDateWithEndTime(DateTime dt)
        {
            dt = clsCommon.myCDate(dt);
            DateTime dtReturn = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            return dtReturn;
        }

        public static string GetDateString(DateTime dt)
        {
            string strReturn = "'" + dt.ToString() + "'";
            return strReturn;

        }

        //public static bool IsValidText(ComboBox cmb, string strText)
        //{
        //    bool IsTrue = false;
        //    intItemCount = 0;
        //    if (cmb.Items.Count > 0)
        //    {
        //        foreach (DataRowView drv in cmb.Items)
        //        {
        //            if (cmb.DisplayMember == string.Empty || cmb.DisplayMember == null)
        //            {
        //                if (drv.Row.ItemArray[0].ToString().ToUpper().Trim() == strText.ToUpper().Trim())
        //                {
        //                    intItemCount = intItemCount + 1;
        //                }
        //            }
        //            else
        //            {
        //                if (drv.Row[cmb.DisplayMember].ToString().ToUpper().Trim() == strText.ToUpper().Trim())
        //                {
        //                    intItemCount = intItemCount + 1;
        //                }
        //            }
        //        }
        //        if (intItemCount == 0)
        //        {
        //            IsTrue = false;
        //        }
        //        else
        //        {
        //            IsTrue = true;
        //        }
        //    }
        //    return IsTrue;
        //}

        /*public static string incval(string code)
        {
            code = code.Trim();
            string numPart = "";
            string strPart = "";
            char[] arrCode = code.ToCharArray();
            for (int i = arrCode.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(arrCode[i]))
                {
                    strPart = code.Substring(0, i + 1);
                    break;
                }
            }
            if (strPart.Length > 0)
            {
                numPart = code.Replace(strPart, "");
            }
            else
            {
                numPart = code;
            }
            long num = (long)clsCommon.myCdbl(numPart);
            num += 1;
            numPart = clsCommon.myCstr(num);
            num = code.Length - strPart.Length;
            if (numPart.Length > num)
            {
                numPart = numPart.Substring(numPart.Length - (int)num, (int)num);
            }
            else
            {
                num = num - numPart.Length;
                for (int i = 0; i < num; i++)
                {
                    numPart = "0" + numPart;
                }
            }
            code = strPart + numPart;
            return code;
        }*/

        public static string incval(string code)
        {
            return incval(code, 0, 1);
        }
        public static string incval(string code, int intRightPading)
        {
            return incval(code, intRightPading, 1);
        }
        public static string incval(string code, int intRightPading, int IncrementBy)
        {
            code = code.Trim();
            string strAfterPart = string.Empty;
            if (clsCommon.myLen(code) > 0 && intRightPading > 0)
            {
                strAfterPart = code.Substring(code.Length - intRightPading);
                code = code.Substring(0, code.Length - intRightPading);
            }

            string numPart = string.Empty;
            string strPart = string.Empty;
            char[] arrCode = code.ToCharArray();
            for (int i = arrCode.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(arrCode[i]))
                {
                    strPart = code.Substring(0, i + 1);
                    break;
                }
            }
            if (strPart.Length > 0)
            {
                numPart = code.Replace(strPart, "");
            }
            else
            {
                numPart = code;
            }
            long num = (long)clsCommon.myCdbl(numPart);
            num += IncrementBy;

            numPart = clsCommon.myCstr(num);
            num = code.Length - strPart.Length;
            if (numPart.Length > num)
            {
                numPart = numPart.Substring(numPart.Length - (int)num, (int)num);
            }
            else
            {
                num = num - numPart.Length;
                for (int i = 0; i < num; i++)
                {
                    numPart = "0" + numPart;
                }
            }
            code = strPart + numPart;
            if (clsCommon.myLen(strAfterPart) > 0)
            {
                code = code + strAfterPart;
            }
            return code;
        }

        //public static void SetComboOnLoad(ComboBox cbo, string strCode, string strName)
        //{
        //    cbo.DataSource = null;
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("CODE", typeof(string));
        //    dt.Columns.Add("Name", typeof(string));
        //    DataRow dr = dt.NewRow();
        //    dr["CODE"] = strCode;
        //    dr["Name"] = strName;
        //    dt.Rows.Add(dr);
        //    cbo.DataSource = dt;
        //    cbo.ValueMember = "CODE";
        //    cbo.DisplayMember = "NAME";
        //}

        public static string GetPrintDate(DateTime dateTime)
        {
            return GetPrintDate(dateTime, "");
        }
        public static string GetPrintDate(DateTime dateTime, string strFormat)
        {
            string strRet = string.Empty;
            if (clsCommon.myLen(strFormat) <= 0)
            {
                strRet = dateTime.ToString("dd-MMM-yyyy");
            }
            else
            {
                strRet = dateTime.ToString(strFormat);
            }
            return strRet;
        }

        #region Get NuberToCurrency
        public static String changeNumericToWords(double numb)
        {
            String num = numb.ToString();

            return changeToWords(num, false, "");
        }

        public static String changeNumericToWords(String numb)
        {
            return changeToWords(numb, false, "");
        }

        public static String changeCurrencyToWords(String numb)
        {
            return changeCurrencyToWords(numb, "Paisa");
        }
        public static String changeCurrencyToWords(String numb, String strCENTESIMAL)
        {
            numb = string.Format("{0:####0.00}", numb);
            return changeToWords(numb, true, strCENTESIMAL);
        }

        public static String changeCurrencyToWords(double numb)
        {
            return changeCurrencyToWords(numb, "Paisa");
        }

        public static String changeCurrencyToWords(double numb, String strCENTESIMAL)
        {
            string StrNumb = string.Format("{0:####0.00}", numb);
            return changeToWords(StrNumb, true, strCENTESIMAL);
        }

        ////private static String changeToWords(String numb, bool isCurrency)
        ////{
        ////    return changeToWords(numb, isCurrency, "Paisa");
        ////}

        private static String changeToWords(String numb, bool isCurrency, string strCENTESIMAL)
        {
            strCENTESIMAL = clsCommon.myLen(strCENTESIMAL) > 0 ? strCENTESIMAL : "Paisa ";
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("and") : ("point");//just to separate whole numbers from points/cents
                        endStr = (isCurrency) ? (strCENTESIMAL + " " + endStr) : ("");
                        // changed by richa agarwal 21/07/2015 shnwn decimal amount in proper currency format
                        //pointStr = translateToPoint(points, isCurrency);
                        if (clsCommon.myCdbl(points) > 0)
                        {
                            pointStr = translateWholeNumber(clsCommon.myCstr(clsCommon.myCdbl(points)));
                        }
                    }
                }
                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { ;}
            return val;
        }

        private static String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(number);
                            isDone = true;
                            break;

                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;

                        case 4://thousands' range
                        case 5:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;

                        case 6:
                        case 7:
                            pos = (numDigits % 6) + 1;
                            place = " Lakh ";
                            break;
                        case 8:
                        case 9:
                            pos = (numDigits % 8) + 1;
                            place = " Crore ";
                            break;
                        case 10:
                        case 11:
                            pos = (numDigits % 10) + 1;
                            place = " Arab ";
                            break;
                        case 12:
                        case 13:
                            pos = (numDigits % 12) + 1;
                            place = " Kharab ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            throw new Exception("Above 99 Kharab.Not Impletementing Yet");
                            isDone = true;
                            break;
                    }

                    if (!isDone)
                    {
                        //if transalation is not done, continue...(Recursion comes in now!!)
                        word = clsCommon.myLen(translateWholeNumber(number.Substring(0, pos)).TrimStart().TrimEnd()) > 0 ? translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos)) : translateWholeNumber(number.Substring(0, pos)) + translateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero && clsCommon.myLen(translateWholeNumber(number.Substring(0, pos)).TrimStart().TrimEnd()) > 0) word = " and " + word.TrimStart().TrimEnd();
                    }

                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { ;}
            return word.Trim();
        }

        private static String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private static String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;

        }

        private static String translateToPoint(String cents, bool isCurrency)
        {
            String cts = "", digit = "", engOne = "";
            for (int i = 0; i < cents.Length; i++)
            {
                digit = cents[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cts += " " + engOne;
            }
            return cts;
        }
        #endregion

        public static string myFormat(Object chamt)
        {
            return (myFormat(chamt, false, true, true, 2, true));
        }
        private static string myFormat(Object chamt, bool showdc)
        {
            return (myFormat(chamt, showdc, true, false, 0, true));
        }
        public static string myFormat(Object chamt, bool showdc, bool showzero)
        {
            return (myFormat(chamt, showdc, showzero, false, 0, true));
        }
        public static string myFormat(Object chamt, bool showdc, bool showzero, bool IndianCommaStyle)
        {
            return (myFormat(chamt, showdc, showzero, IndianCommaStyle, 0, true));
        }
        public static string myFormat(Object chamt, bool showdc, bool showzero, bool IndianCommaStyle, int DECIMALPLACES, bool RoundAccordNoChar)
        {
            int nochar = myLen(chamt) + DECIMALPLACES;
            string strMinus = string.Empty;
            double amt = myCdbl(chamt);
            string strAmt = myCstr(amt);
            double AmtToReturn = 0;
            string strAmtToReturn = "";
            if (amt == 0.0)
            {
                if (showzero)
                {
                    strAmtToReturn = "0";
                    if (DECIMALPLACES > 0)
                    {
                        strAmtToReturn += ".";
                    }
                    for (int ii = 0; ii < DECIMALPLACES; ii++)
                    {
                        strAmtToReturn += "0";
                    }
                }
                else
                {
                    for (int i = 0; i < (nochar - DECIMALPLACES); i++)
                    {
                        strAmtToReturn = strAmtToReturn + " ";
                    }
                    strAmtToReturn = strAmtToReturn + ".";
                    for (int i = 0; i < DECIMALPLACES; i++)
                    {
                        strAmtToReturn = strAmtToReturn + " ";
                    }
                }
            }
            else
            {
                int amtLength = myLen(strAmt);   //Length of given amount.
                char[] arrStr = new char[1];
                arrStr[0] = '.';
                string[] str = strAmt.Split(arrStr);
                string strAmtIntPart = str[0];  //Integer part of given amount
                int strAmtIntPartLen = myLen(strAmtIntPart);
                if (str.Length > 1)
                {
                    if (myLen(str[1]) > 0)
                    {
                        string strAmtDecPart = str[1];  //Decimal part of given amount
                        int strAmtDecPartLen = myLen(strAmtDecPart);
                    }
                }
                if (nochar >= strAmtIntPartLen)
                {
                    string showCrDr = "";
                    AmtToReturn = Math.Round(amt, DECIMALPLACES);

                    if (showdc)
                    {
                        strMinus = "";
                        if (AmtToReturn < 0)
                        {
                            AmtToReturn = -(AmtToReturn);
                            showCrDr = "Dr";
                        }
                        else
                        {
                            showCrDr = "Cr";
                        }
                    }
                    else if (AmtToReturn < 0)
                    {
                        AmtToReturn = -(AmtToReturn);
                        strMinus = "-";
                    }
                    int AmtToReturnLen = myLen(myCstr(AmtToReturn));
                    if (AmtToReturnLen <= nochar || RoundAccordNoChar)
                    {
                        char[] arrStr1 = new char[1];
                        arrStr[0] = '.';

                        string[] str1 = myCstr(AmtToReturn).Split(arrStr);

                        string strAmtIntPart1 = str1[0];  //Integer part of given amount
                        int strAmtIntPartLen1 = myLen(strAmtIntPart1);

                        string strAmtDecPart1 = "";
                        int strAmtDecPartLen1 = 0;
                        if (str1.Length > 1)
                        {
                            if (myLen(str1[1]) > 0)
                            {
                                strAmtDecPart1 = str1[1];  //Decimal part of given amount
                                strAmtDecPartLen1 = myLen(strAmtDecPart1);
                            }
                        }
                        if (nochar > (strAmtDecPartLen1 + strAmtIntPartLen1) && strAmtDecPartLen1 < DECIMALPLACES)
                        {
                            for (int i = 0; i < (DECIMALPLACES - strAmtDecPartLen1); i++)
                            {
                                strAmtDecPart1 = strAmtDecPart1 + "0";
                            }
                        }

                        string strComma = ",";

                        StringBuilder strBulAmtIntPart = new StringBuilder();
                        strBulAmtIntPart.Append(strAmtIntPart1);

                        StringBuilder strBulAmtDecPart = new StringBuilder();
                        strBulAmtDecPart.Append(strAmtDecPart1);
                        if (strAmtIntPartLen1 > 3)
                        {
                            int intCommaInsert = strAmtIntPartLen1 - 3;
                            strBulAmtIntPart.Insert(intCommaInsert, strComma);
                            if (IndianCommaStyle)
                            {
                                int i = 2;
                                while (i < intCommaInsert)
                                {

                                    intCommaInsert = intCommaInsert - 2;

                                    strBulAmtIntPart.Insert(intCommaInsert, strComma);
                                }
                            }
                            else
                            {
                                int i = 3;
                                while (i < intCommaInsert)
                                {

                                    intCommaInsert = intCommaInsert - 3;

                                    strBulAmtIntPart.Insert(intCommaInsert, strComma);
                                }
                            }
                        }


                        string tmpstrToReturn = strBulAmtIntPart.ToString() + "." + strBulAmtDecPart.ToString();
                        if (showdc)
                        {
                            strAmtToReturn = tmpstrToReturn + showCrDr;
                        }
                        else
                        {
                            strAmtToReturn = strMinus + tmpstrToReturn;
                        }
                    }
                    else
                    {
                        StringBuilder strBulAmt = new StringBuilder();
                        for (int i = 0; i < nochar; i++)
                        {
                            strBulAmt.Append("#");
                        }
                        strAmtToReturn = strBulAmt.ToString();

                    }
                }
                else
                {
                    StringBuilder strBulAmt = new StringBuilder();
                    for (int i = 0; i < nochar; i++)
                    {
                        strBulAmt.Append("#");
                    }
                    strAmtToReturn = strBulAmt.ToString();

                }
            }
            return strAmtToReturn;
        }

        public static string GetMulcallString(ArrayList Arr)
        {
            string strRet = string.Empty;
            if (Arr != null && Arr.Count > 0)
            {
                for (int ii = 0; ii < Arr.Count; ii++)
                {
                    if (ii != 0)
                    {
                        strRet += ",";
                    }
                    strRet += "'" + clsCommon.myCstr(Arr[ii]) + "'";
                }
            }
            else
            {
                strRet = "''";
            }
            return strRet;
        }

        public static string GetMulcallString(List<string> Arr)
        {
            string strRet = string.Empty;
            if (Arr != null && Arr.Count > 0)
            {
                for (int ii = 0; ii < Arr.Count; ii++)
                {
                    if (ii != 0)
                    {
                        strRet += ",";
                    }
                    strRet += "'" + clsCommon.myCstr(Arr[ii]) + "'";
                }
            }
            else
            {
                strRet = "''";
            }
            return strRet;
        }

        public static string GetMulcallString(DataTable dt, string strColName)
        {
            string strReturn = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (clsCommon.myLen(dr[strColName]) > 0)
                    {
                        if (clsCommon.myLen(strReturn) > 0)
                        {
                            strReturn += ",";
                        }
                        strReturn += "'" + clsCommon.myCstr(dr[strColName]) + "'";
                    }
                }
            }
            return strReturn;
        }

        public static string GetMulcallStringWithComma(ArrayList Arr)
        {
            string strRet = string.Empty;
            if (Arr != null && Arr.Count > 0)
            {
                for (int ii = 0; ii < Arr.Count; ii++)
                {
                    if (ii != 0)
                    {
                        strRet += ",";
                    }
                    strRet += clsCommon.myCstr(Arr[ii]);
                }
            }
            else
            {
                //strRet = "''";
            }
            return strRet;
        }

        public static string GetMulcallStringWithComma(List<string> Arr)
        {
            string strRet = string.Empty;
            if (Arr != null && Arr.Count > 0)
            {
                for (int ii = 0; ii < Arr.Count; ii++)
                {
                    if (ii != 0)
                    {
                        strRet += ",";
                    }
                    strRet += clsCommon.myCstr(Arr[ii]);
                }
            }
            else
            {
                //strRet = "''";
            }
            return strRet;
        }



        static public string EncryptStringBase64(string plainText)
        {
            if (clsCommon.myLen(plainText) <= 0) throw new ArgumentNullException("Please pass plain Text");

            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(plainText);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        static public string DecryptStringBase64(string EncryptText)
        {
            if (clsCommon.myLen(EncryptText) <= 0) throw new ArgumentNullException("Please pass Encrypt Text");
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(EncryptText);
            string returnValue =
               System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public static string EncryptString(string plainText)
        {
            return EncryptString(plainText, "Ballu");
        }

        public static string EncryptString(string plainText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;                       // Encrypted string to return
            RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return outStr;
        }

        public static string DecryptString(string cipherText)
        {
            return DecryptString(cipherText, "Ballu");
        }
        public static string DecryptString(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.                
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }
        public static string GetEncrptPassword(string password)
        {
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(encode);


        }
        public static string GetDecrptPassword(string password)
        {
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(password);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            return new String(decoded_char);
        }

        public static string ShowSelectForm(string ReportID, string strQry, string strColName, string strWhrCls, string strCurrCode)
        {
            return ShowSelectForm(ReportID, strQry, strColName, strWhrCls, strCurrCode, "", false);
        }
        public static string ShowSelectForm(string ReportID, string strQry, string strSelectedColCode, string strWhrCls, string strCurrCode, string strOrderByColumns, bool isShowSelectForm)
        {
            return ShowSelectForm(ReportID, strQry, strSelectedColCode, strWhrCls, strCurrCode, strOrderByColumns, isShowSelectForm, "");
        }

        public static string ShowSelectForm(string ReportID, string strQry, string strSelectedColCode, string strWhrCls, string strCurrCode, string strOrderByColumns, bool isShowSelectForm, string DateColumn)
        {
            DataTable dt = null;
            string strReturn = string.Empty;
            string strQryForOneRecord = string.Empty;
            DateTime ToDate = clsCommon.GETSERVERDATE();
            DateTime FromDate = ToDate.AddMonths(-1);
            frmSelectOneRowNew frm = null;
            try
            {
                if (clsCommon.myLen(strCurrCode) <= 0 && !isShowSelectForm)
                {
                    return strReturn;
                }
                if (!isShowSelectForm)
                {
                    strQryForOneRecord = strQry + " Where 2=2";
                    if (clsCommon.myLen(strWhrCls) > 0)
                    {
                        strQryForOneRecord += " and " + strWhrCls + "";
                    }
                    strQryForOneRecord = "Select " + strSelectedColCode + " from (" + strQryForOneRecord + " ) Final where " + strSelectedColCode + "='" + strCurrCode + "'";
                    dt = clsDBFuncationality.GetDataTable(strQryForOneRecord);
                    if (dt != null && dt.Rows.Count == 1)
                    {
                        return clsCommon.myCstr(dt.Rows[0][strSelectedColCode]);
                    }
                }
                string strQryFind = strQry + " Where 2=2";
                if (clsCommon.myLen(strWhrCls) > 0)
                {
                    strQryFind += " and " + strWhrCls + "";
                }

                strQryFind = " select count(1) as cnt from (" + strQryFind + ")x";
                double intCount  = clsCommon.myCdbl( clsDBFuncationality.getSingleValue(strQryFind));
                if (intCount > 0)
                {
                    frm = new frmSelectOneRowNew();
                    frm.strQuery = strQry;
                    frm.ReportID = ReportID;
                    frm.strWhrCls = strWhrCls;
                    frm.strColName = strSelectedColCode;
                    frm.strCurrCode = strCurrCode;
                    frm.strOrderByColumns = strOrderByColumns;
                    frm.fromDate = FromDate;
                    frm.ToDate = ToDate;
                    frm.DateColumn = DateColumn;
                    if (clsCommon.myLen(DateColumn) > 0)
                    {
                        frm.isEnableGoBtn = true;
                    }
                    else
                    {
                        frm.isEnableGoBtn = false;
                    }

                    frm.ShowDialog();
                    strReturn = frm.strReturn;
                }
                else
                {
                    RadMessageBox.Show("No Data found to Display");
                    strReturn = "";
                }
            }

            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                dt = null;
                strQryForOneRecord = null;
                if (frm != null)
                {
                    frm.Dispose();
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return strReturn;
        }

        public static DataRow ShowSelectFormForRow(string ReportID, string strQry)
        {
            return ShowSelectFormForRow(ReportID, strQry, "", "");
        }
        public static DataRow ShowSelectFormForRow(string ReportID, string strQry, string strSelectedColCode, string strCurrCode)
        {
            string qry = string.Empty;
            frmSelectOneRowNew frm = null;
            DataTable dt = null;
            DataRow drRet = null;
            try
            {
                if (clsCommon.myLen(strSelectedColCode) > 0 && clsCommon.myLen(strCurrCode) > 0)
                {
                    qry = "Select * from (" + strQry + ") Final where [" + strSelectedColCode + "]='" + strCurrCode + "'";
                    dt = clsDBFuncationality.GetDataTable(qry);
                    if (dt != null && dt.Rows.Count == 1)
                    {
                        drRet = dt.Rows[0];
                    }
                }

                frm = new frmSelectOneRowNew();
                frm.isReturnCurrentRow = true;
                frm.strQuery = strQry;
                frm.ReportID = ReportID;
                frm.ShowDialog();
                drRet = frm.drRet;
            }
            catch (Exception ex)
            {
                clsCommon.MyMessageBoxShow(ex.Message);
            }
            finally
            {
                qry = null;
                dt = null;
                frm.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return drRet;
        }

        public static ArrayList ShowMultipleSelectForm(string ReportID, string strQry, string strValueMember, string strDisplayMember, ArrayList arrValueMember, ref ArrayList arrDisplayMember)
        {
            return ShowMultipleSelectForm(true, ReportID, strQry, strValueMember, strDisplayMember, arrValueMember, ref arrDisplayMember);
        }
        public static ArrayList ShowMultipleSelectForm(Boolean isShowRadioButtons, string ReportID, string strQry, string strValueMember, string strDisplayMember, ArrayList arrValueMember, ref ArrayList arrDisplayMember)
        {
            string qry = string.Empty;
            frmMultiSelection frm = null;
            DataTable dt = null;
            ArrayList ArrRet = null;
            //ArrayList arrOldDisplayMember = arrDisplayMember;
            //arrDisplayMember = new ArrayList();
            try
            {
                frm = new frmMultiSelection();
                frm.strQuery = strQry;
                frm.ReportID = ReportID;
                frm.ValueMember = strValueMember;
                frm.DisplayMember = strDisplayMember;
                frm.arr = arrValueMember;
                frm.isShowRadioButtons = isShowRadioButtons;
                //frm.arrDisplay = arrDisplayMember;
                frm.ShowDialog();
                if (frm.isCancel)
                {
                    ArrRet = arrValueMember;
                }
                else
                {
                    ArrRet = frm.arr;
                    if (clsCommon.myLen(strDisplayMember) > 0)
                    {
                        arrDisplayMember = frm.arrDisplay;
                    }
                }
            }
            catch (Exception ex)
            {
                clsCommon.MyMessageBoxShow(ex.Message);
            }
            finally
            {
                qry = null;
                dt = null;
                frm.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return ArrRet;
        }

        public static DataTable ShowMultipleSelectForm_ForDatatable(string ReportID, string strQry)
        {
            string qry = string.Empty;
            FrmMultiSelection_ForDatatable frm = null;
            DataTable dt = null;
            
            try
            {
                frm = new FrmMultiSelection_ForDatatable();
                frm.strQuery = strQry;
                frm.ReportID = ReportID;
                frm.ShowDialog();
                if (frm.isCancel)
                {
                    dt = null;
                }
                else
                {
                    dt = frm.Multiple_Dt;
                }
            }
            catch (Exception ex)
            {
                clsCommon.MyMessageBoxShow(ex.Message);
            }
            finally
            {
                qry = null;
                frm.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return dt;
        }

        public static string GetQueryWithAllSelectedDataBase(string BaseQry, List<string> arrDBName, bool isUsingGroupBy)
        {
            string FinalQuery = string.Empty;
            try
            {
                bool isFirstTime = true;
                if ((arrDBName != null && arrDBName.Count > 0))
                {
                    foreach (string strDatabase in arrDBName)
                    {
                        if ((clsCommon.myLen(strDatabase) > 0))
                        {
                            if (!isFirstTime)
                            {
                                FinalQuery += " Union All ";
                            }
                            FinalQuery += BaseQry.Replace(ReplicateDBString, strDatabase + ".dbo.");
                            isFirstTime = false;
                        }
                    }
                }
                else
                {
                    throw new Exception("Please select At least one Company");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isUsingGroupBy ? FinalQuery : "select * from ( " + FinalQuery + " )xxx";
        }

        public static string GetQueryWithAllSelectedDataBase(string BaseQry, ArrayList arrDBName, bool isUsingGroupBy)
        {
            string FinalQuery = "";
            try
            {
                bool isFirstTime = true;
                if ((arrDBName != null && arrDBName.Count > 0))
                {
                    foreach (string strDatabase in arrDBName)
                    {
                        if ((clsCommon.myLen(strDatabase) > 0))
                        {
                            if (!isFirstTime)
                            {
                                FinalQuery += " Union All ";
                            }
                            FinalQuery += BaseQry.Replace(ReplicateDBString, strDatabase + ".dbo.");
                            isFirstTime = false;
                        }
                    }
                }
                else
                {
                    throw new Exception("Please select At least one Company");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isUsingGroupBy ? FinalQuery : "select * from ( " + FinalQuery + " )xxx";
        }

        public static string ReplaceString(string OriginalString, string OldString, string NewString)
        {
            int count, position0, position1;
            count = position0 = position1 = 0;
            string upperString = OriginalString.ToUpper();
            string upperPattern = OldString.ToUpper();
            int inc = (OriginalString.Length / OldString.Length) *
                      (NewString.Length - OldString.Length);
            char[] chars = new char[OriginalString.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern, position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = OriginalString[i];
                for (int i = 0; i < NewString.Length; ++i)
                    chars[count++] = NewString[i];
                position0 = position1 + OldString.Length;
            }
            if (position0 == 0) return OriginalString;
            for (int i = position0; i < OriginalString.Length; ++i)
                chars[count++] = OriginalString[i];
            return new string(chars, 0, count);
        }


        public static void ProgressBarShow()
        {
            WaitingForm1.ShowForm(null);
        }
        public static void ProgressBarUpdate(string strMessage)
        {
            WaitingForm1.UpdateProgressBarValue(strMessage);
        }
        public static void ProgressBarHide()
        {
            WaitingForm1.CloseForm();
        }

        public static void ProgressBarPercentShow()
        {
            WaitingFormProgress.ShowForm(null);
        }

        public static void ProgressBarPercentUpdate(Int32 intPer, string strMessage)
        {
            WaitingFormProgress.UpdateProgressBarValue(intPer, strMessage);
        }
        public static void ProgressBarPercentHide()
        {
            WaitingFormProgress.CloseForm();

        }

        private static void ShowForm()
        {
            frmPB = new frmProgressBar();
            frmPB.ShowDialog();
        }

        
        public static bool MyExportToExcelGrid(string ReportHeading, RadGridView gv1, List<String> arrHeader, string strReportNameInSaveDialog)
        {
            return MyExportToExcelGrid(ReportHeading, gv1, arrHeader, strReportNameInSaveDialog, false);
        }
        public static bool MyExportToExcelGrid(string ReportHeading, RadGridView gv1, List<String> arrHeader, string strReportNameInSaveDialog, bool ExportVisualSettings)
        {
            string subPath = string.Empty;
            return MyExportToExcelGrid(ReportHeading, gv1, arrHeader, strReportNameInSaveDialog, ExportVisualSettings, out subPath);
        }


         
        public static bool MyExportToExcelGrid(string ReportHeading, RadGridView gv1, List<String> arrHeader, string strReportNameInSaveDialog, bool ExportVisualSettings, out string subPath)
        {
            subPath = "C:\\ERPTempFolder";
            try
            {
                bool IsExists = System.IO.Directory.Exists(subPath);
                if (!IsExists)
                {
                    System.IO.Directory.CreateDirectory(subPath);
                }
                strReportNameInSaveDialog += clsCommon.GetPrintDate(DateTime.Now, "yyyyMMddhhmmss");
                string FilePath = "C:\\ERPTempFolder\\" + strReportNameInSaveDialog.Replace("/", "_").Replace("\\", "_") + ".xls";
                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.File.Delete(FilePath);
                }
                subPath = FilePath;
                int i = 0;
                for (i = 0; i <= gv1.ColumnCount - 1; i++)
                {
                    GridViewRowInfo grow = gv1.Rows[0] as GridViewRowInfo;
                    if (grow.Cells[i].Value is DateTime)
                    {
                        GridViewDateTimeColumn datecol = gv1.Columns[i] as GridViewDateTimeColumn;
                        datecol.ExcelExportType = DisplayFormatType.ShortDate;
                    }

                    if (grow.Cells[i].Value is Decimal )
                    {
                        GridViewDecimalColumn decimalcol = gv1.Columns[i] as GridViewDecimalColumn;
                        decimalcol.ExcelExportFormatString = "{0:n2}";
                        
                    }
                }
                ExportReportHeading = ReportHeading;
                ExportArrHeader = new List<string>();
                ExportArrHeader = arrHeader;
                clsCommon.ProgressBarPercentShow();
                RunExportToExcelML(FilePath, gv1, ExportVisualSettings);
                clsCommon.ProgressBarPercentHide();
                //richa 
               // ApplyWordWrapInExcel(FilePath);
                ApplyWordWrapInExcel(FilePath,gv1 );
                System.Diagnostics.Process.Start(FilePath);
            }
            catch (Exception ex)
            {
                clsCommon.ProgressBarPercentHide();
                RadMessageBox.Show(ex.Message);
            }
            finally
            {
                clsCommon.ProgressBarPercentHide();
            }
            return true;
        }
        //<summary>
        /// /////////////////Code Commented By Pankaj Jha to Apply New Export
        /// </summary>
        /// <param name="savepath"></param>
        /// <returns></returns>
        private static bool ApplyWordWrapInExcel(string savepath,RadGridView gv1)
        {
            object m = Type.Missing;
            Microsoft.Office.Interop.Excel.Application objApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook objBook = null;
            Microsoft.Office.Interop.Excel.Sheets objSheets;
            Microsoft.Office.Interop.Excel.Worksheet objworkSheet;
            Microsoft.Office.Interop.Excel.Range range;
            objApp.DisplayAlerts = false;
            try
            {
                objApp = new Microsoft.Office.Interop.Excel.Application();
                objApp.DisplayAlerts = false;
                objBook = objApp.Workbooks.Open(savepath, m, m, m, m, m, m, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", m, m, m, m, m, m);
                objSheets = objBook.Worksheets;
                objApp.DisplayAlerts = false;
                objworkSheet = (Microsoft.Office.Interop.Excel.Worksheet)objSheets.get_Item(1);
                {
                    objworkSheet.Columns.WrapText = true;
                    objworkSheet.Rows.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    //for (int cc = 1; cc < objworkSheet.Columns.Count  ; cc++)
                    //{
                    //    objworkSheet.Columns.WrapText = true

                    //    //range = workSheet.get_Range(pColNameToGeneral + "1", pColNameToGeneral + cc.ToString());
                    //    //range.NumberFormat = "General";
                    //}


                    //richa 
                    int  jk  = 0;
                    for (int i = 0; i <= gv1.Columns.Count - 1; i++) 
                    {
                        jk += 1;

                        if (gv1.Columns[i] is GridViewTextBoxColumn)
                        {

                            objworkSheet.Range[jk].Cells.NumberFormat = "General";
                        }
                        else if (gv1.Columns[i] is GridViewDecimalColumn && gv1.Columns[i].FormatString == "{0:n2}")
                        {
                             objworkSheet.Range[jk].Cells.NumberFormat = "0.00";
                        }
                        else if (gv1.Columns[i] is GridViewDecimalColumn)
                        {
                                objworkSheet.Range[jk].Cells.NumberFormat = "0";
                        }
                    }
                               

                }
            }
            catch { }
            finally
            {
                objBook.Save();
                objApp.Quit();
                objApp = null;
            }

            System.IO.FileInfo tempInfo = new System.IO.FileInfo(savepath);
            System.IO.FileInfo[] arrInfo = tempInfo.Directory.GetFiles("*.tmp");
            foreach (System.IO.FileInfo aaInfo in arrInfo)
            {
                try
                {
                    aaInfo.Delete();
                }
                catch { }
            }
            return true;
        }

        private static bool ApplyWordWrapInExcel(string savepath)
        {
            object m = Type.Missing;
            Microsoft.Office.Interop.Excel.Application objApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook objBook = null;
            Microsoft.Office.Interop.Excel.Sheets objSheets;
            Microsoft.Office.Interop.Excel.Worksheet objworkSheet;
            Microsoft.Office.Interop.Excel.Range range;
            objApp.DisplayAlerts = false;
            try
            {
                objApp = new Microsoft.Office.Interop.Excel.Application();
                objApp.DisplayAlerts = false;
                objBook = objApp.Workbooks.Open(savepath, m, m, m, m, m, m, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", m, m, m, m, m, m);
                objSheets = objBook.Worksheets;
                objApp.DisplayAlerts = false;
                objworkSheet = (Microsoft.Office.Interop.Excel.Worksheet)objSheets.get_Item(1);
                {
                    objworkSheet.Columns.WrapText = true;
                    objworkSheet.Rows.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    //for (int cc = 1; cc < objworkSheet.Columns.Count  ; cc++)
                    //{
                    //    objworkSheet.Columns.WrapText = true

                    //    //range = workSheet.get_Range(pColNameToGeneral + "1", pColNameToGeneral + cc.ToString());
                    //    //range.NumberFormat = "General";
                    //}
                                       
                }
            }
            catch { }
            finally
            {
                objBook.Save();
                objApp.Quit();
                objApp = null;
            }

            System.IO.FileInfo tempInfo = new System.IO.FileInfo(savepath);
            System.IO.FileInfo[] arrInfo = tempInfo.Directory.GetFiles("*.tmp");
            foreach (System.IO.FileInfo aaInfo in arrInfo)
            {
                try
                {
                    aaInfo.Delete();
                }
                catch { }
            }
            return true;
        }

        public static bool MyExportToExcel(string ReportHeading, RadGridView gv1, List<String> arrHeader, string strReportNameInSaveDialog)
        {
            string subPath = "";
            return MyExportToExcel(ReportHeading, gv1, arrHeader, strReportNameInSaveDialog, out subPath);
        }
        public static bool MyExportToExcel(string ReportHeading, RadGridView gv1, List<String> arrHeader, string strReportNameInSaveDialog, out string subPath)
        {
            subPath = "C:\\ERPTempFolder";
            try
            {
                clsCommon.ProgressBarShow();
                const string strTab = "\t";
                const string strNewLine = "\r\n";

                string strs = string.Empty;
                //DataRow dRow = default(DataRow);

                // your code goes here

                bool IsExists = System.IO.Directory.Exists(subPath);

                if (!IsExists)
                {
                    System.IO.Directory.CreateDirectory(subPath);
                }
                strReportNameInSaveDialog += clsCommon.GetPrintDate(DateTime.Now, "yyyyMMddhhmmss");
                string FilePath = "C:\\ERPTempFolder\\" + strReportNameInSaveDialog.Replace("/", "_").Replace("\\", "_") + ".xls";
                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.File.Delete(FilePath);
                }


                StreamWriter writer = new System.IO.StreamWriter(System.IO.File.Create(FilePath));
                if (clsCommon.myLen(ReportHeading) > 0)
                {
                    int visibleColumns = 0;
                    for (int i = 0; i < gv1.Columns.Count; i++)
                    {
                        if (gv1.Columns[i].IsVisible)
                        {
                            visibleColumns += 1;
                        }
                    }
                    for (int i = 0; i < (int)visibleColumns / 2; i++)
                    {
                        strs += strTab;
                    }
                    strs = ReportHeading + strNewLine;
                    writer.Write(strs);
                    writer.Flush();
                }

                if (clsCommon.myLen(arrHeader) > 0)
                {
                    foreach (string strHead in arrHeader)
                    {
                        writer.Write(strHead + strNewLine);
                        writer.Flush();
                    }
                }


                strs = strNewLine + "";
                for (int i = 0; i <= gv1.Columns.Count - 1; i++)
                {
                    if (gv1.Columns[i].IsVisible)
                    {
                        strs += gv1.Columns[i].HeaderText + strTab;
                    }
                }
                writer.Write(strs + strNewLine);
                writer.Flush();


                ///'' to export data
                for (int ii = 0; ii <= gv1.Rows.Count - 1; ii++)
                {
                    strs = "";
                    for (int col = 0; col <= gv1.Columns.Count - 1; col++)
                    {
                        if (gv1.Columns[col].IsVisible)
                        {

                            strs += clsCommon.myCstr(gv1.Rows[ii].Cells[col].Value) + strTab;
                                                       
                        }
                    }
                    strs += strNewLine;
                    writer.Write(strs);
                    writer.Flush();
                }
                strs = "";


                          ///' to export grid footer
                for (int col = 0; col <= gv1.Columns.Count - 1; col++)
                {
                    object summary = null;
                    if (gv1.Columns[col].IsVisible)
                    {
                        if (gv1.MasterTemplate.SummaryRowsBottom.Count > 0)
                        {
                            for (int ii = 0; ii <= gv1.MasterTemplate.SummaryRowsBottom[0].Count - 1; ii++)
                            {
                                if (clsCommon.CompairString(gv1.Columns[col].Name, gv1.MasterTemplate.SummaryRowsBottom[0][ii].Name) == CompairStringResult.Equal)
                                {
                                    GridViewSummaryItem summaryItem = gv1.SummaryRowsBottom[0][ii];
                                    summary = summaryItem.Evaluate(gv1.MasterTemplate);
                                    break;
                                }
                            }
                            strs += summary + strTab;
                            summary = "";
                        }

                    }
                }
                strs += strNewLine;
                writer.Write(strs);
                writer.Flush();


                //Close the stream writer object
                writer.Close();
                clsCommon.ProgressBarHide();
                Microsoft.Office.Interop.Excel.ApplicationClass xlsApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                xlsApp.Visible = true;
                ApplyWordWrapInExcel(FilePath,gv1 );
                Microsoft.Office.Interop.Excel.Workbook xlsWB = xlsApp.Workbooks.Open(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                //xlsWB = (Microsoft.Office.Interop.Excel.WorkbookClass)xlsApp.Workbooks.Open(FilePath, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                //System.Diagnostics.Process.Start(FilePath);
            }
            catch (Exception ex)
            {
                clsCommon.ProgressBarHide();
                common.clsCommon.MyMessageBoxShow(ex.Message, strReportNameInSaveDialog, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                clsCommon.ProgressBarHide();
            }
            return true;
        }

        private static long intExportRows = 0;
        private static void RunExportToExcelML(string fileName, RadGridView gv1, bool ExportVisualSettings)
        {
            ExportToExcelML exporter;
            try
            {
                
                intExportRows = gv1.ChildRows.Count;
                exporter = new ExportToExcelML(gv1);
                exporter.ExportVisualSettings = ExportVisualSettings;
                exporter.SummariesExportOption = SummariesOption.ExportAll ;
                exporter.HiddenColumnOption = HiddenOption.DoNotExport;
                exporter.SheetMaxRows = ExcelMaxRows._1048576;
                exporter.ExcelRowFormatting += new ExcelRowFormattingEventHandler(exporter_ExcelRowFormatting);
                exporter.ExcelTableCreated += exporter_ExcelTableCreated;
                exporter.ChildViewExportMode = ChildViewExportMode.ExportCurrentlyActiveView;
                 exporter.RunExport(fileName.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exporter = null;
            }
        }

        static void exporter_ExcelRowFormatting(object sender, ExcelRowFormattingEventArgs e)
        {
            try
            {
                if (intExportRows > 0)
                {
                    //update progress bar
                    int position = (int)(100 * (double)e.GridViewRowInfo.Index / intExportRows);
                    if (position > 0)
                    {
                        clsCommon.ProgressBarPercentUpdate(position, "Exporting Record(s) " + clsCommon.myCstr(e.GridViewRowInfo.Index) + " out of " + clsCommon.myCstr(intExportRows));
                    }
                }
            }
            catch (Exception)
            {
            }
        }

       private static void exporter_ExcelCellFormatting(object sender, Telerik.WinControls.UI.Export.ExcelML.ExcelCellFormattingEventArgs e)
        {
            if (object.ReferenceEquals(e.GridRowInfoType, typeof(GridViewTableHeaderRowInfo)))
            {
                e.ExcelStyleElement.FontStyle.Bold = false;
                e.ExcelStyleElement.FontStyle.Size = 8;
            }
            e.ExcelStyleElement.FontStyle.Bold = false;
            e.ExcelStyleElement.FontStyle.Size = 8;

                       try
            {
                if (e.GridRowInfoType == typeof(GridViewDataRowInfo) && intExportRows > 0)
                {
                    //update progress bar
                    int position = (int)(100 * (double)e.GridRowIndex / intExportRows);
                    clsCommon.ProgressBarPercentUpdate(position, "Exporting Record(s) " + clsCommon.myCstr(e.GridRowIndex) + " out of " + clsCommon.myCstr(intExportRows));
                }
                           
                       }
            catch (Exception)
            {
            }
        }

    //richa 
       private static void exporter_ExcelCellFormatting_ForDecimal(object sender, Telerik.WinControls.UI.Export.ExcelML.ExcelCellFormattingEventArgs e)
       {
           if (object.ReferenceEquals(e.GridRowInfoType, typeof(GridViewTableHeaderRowInfo)))
           {
               if (e.GridCellInfo.Value is Decimal)
               {
                   e.ExcelStyleElement.NumberFormat.FormatType = DisplayFormatType.Standard;

               }
               else
               {
                   e.ExcelStyleElement.NumberFormat.FormatType = DisplayFormatType.Text;
               }
                       
           }
                  
       }

       private static void exporter_ExcelCellFormatting_ForColumnText(object sender, Telerik.WinControls.UI.Export.ExcelML.ExcelCellFormattingEventArgs e)
       {
           if (object.ReferenceEquals(e.GridRowInfoType, typeof(GridViewTableHeaderRowInfo)))
           {
               if (e.GridCellInfo.Value is DateTime )
               {
                   e.ExcelStyleElement.NumberFormat.FormatType = DisplayFormatType.ShortDate ;
               }
               if (e.GridCellInfo.Value is Decimal  )
               {
                   e.ExcelStyleElement.NumberFormat.FormatType = DisplayFormatType.Standard;
               }
               if (e.GridCellInfo.Value is String )
               {
                   e.ExcelStyleElement.NumberFormat.FormatType = DisplayFormatType.Text;

               }
              
           }

       }

        //
            private static void exporter_ExcelTableCreated(object sender, ExcelTableCreatedEventArgs e)
        {
            //add header row only for the first excel sheet                
            if (e.SheetIndex == 0)
            {
                if (clsCommon.myLen(ExportReportHeading) > 0)
                {
                    SingleStyleElement style = ((ExportToExcelML)sender).AddCustomExcelRow(e.ExcelTableElement, 30, ExportReportHeading);
                    style.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center;
                    style.AlignmentElement.VerticalAlignment = VerticalAlignmentType.Center;
                    style.InteriorStyle.Pattern = InteriorPatternType.Solid;
                    style.FontStyle.Color = Color.Black;
                    style.FontStyle.Bold = true;
                    style.FontStyle.Size = 18;
                }

                if (ExportArrHeader != null && ExportArrHeader.Count > 0)
                {
                    foreach (string str in ExportArrHeader)
                    {
                        SingleStyleElement style2 = ((ExportToExcelML)sender).AddCustomExcelRow(e.ExcelTableElement, 20, str);
                    }
                }

                //richa

                //if (exportreportf != null && ExportArrHeader.Count > 0)
                //{
                //    foreach (string str in ExportArrHeader)
                //    {
                //        SingleStyleElement style2 = ((ExportToExcelML)sender).AddCustomExcelRow(e.ExcelTableElement, 20, str);
                //    }
                //}
            }
        }

        public static bool IsNumber(object value)
        {
            if (value is sbyte) return true;
            if (value is byte) return true;
            if (value is short) return true;
            if (value is ushort) return true;
            if (value is int) return true;
            if (value is uint) return true;
            if (value is long) return true;
            if (value is ulong) return true;
            if (value is float) return true;
            if (value is double) return true;
            if (value is decimal) return true;
            return false;
        }

        public static bool IsDecimalNumber(object value)
        {
            if (value is float) return true;
            if (value is double) return true;
            if (value is decimal) return true;
            return false;
        }




        /*Export to PDF*/
        //public static bool MyExportToPDF(string ReportHeading, RadGridView gv1, List<String> arrHeader, string strReportNameInSaveDialog)
        //{
        //    return MyExportToPDF(ReportHeading, gv1, arrHeader, strReportNameInSaveDialog, false);
        //}
        //public static bool MyExportToPDF(string ReportHeading, RadGridView gv1, List<String> arrHeader, string strReportNameInSaveDialog, bool ExportVisualSettings)
        //{
        //    try
        //    {
        //        string subPath = "C:\\ERPTempFolder"; // your code goes here

        //        bool IsExists = System.IO.Directory.Exists(subPath);

        //        if (!IsExists)
        //        {
        //            System.IO.Directory.CreateDirectory(subPath);
        //        }

        //        string FilePath = "C:\\ERPTempFolder\\" + strReportNameInSaveDialog + ".pdf";
        //        if (System.IO.File.Exists(FilePath))
        //        {
        //            System.IO.File.Delete(FilePath);
        //        }

        //        int i = 0;
        //        for (i = 0; i <= gv1.ColumnCount - 1; i++)
        //        {
        //            GridViewRowInfo grow = gv1.Rows[0] as GridViewRowInfo;
        //            if (grow.Cells[i].Value is DateTime)
        //            {
        //                GridViewDateTimeColumn datecol = gv1.Columns[i] as GridViewDateTimeColumn;
        //                datecol.ExcelExportType = DisplayFormatType.ShortDate;
        //            }
        //        }


        //        ExportReportHeading = ReportHeading;
        //        ExportArrHeader = new List<string>();
        //        ExportArrHeader = arrHeader;
        //        clsCommon.ProgressBarShow();
        //        RunExportToPDFML(ReportHeading, FilePath, gv1, ExportVisualSettings);
        //        clsCommon.ProgressBarHide();
        //        System.Diagnostics.Process.Start(FilePath);

        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.ProgressBarHide();
        //        RadMessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        clsCommon.ProgressBarHide();
        //    }
        //    return true;
        //}

        //private static void RunExportToPDFML(string ReportHeading, string fileName, RadGridView gv1, bool ExportVisualSettings)
        //{
        //    try
        //    {
        //        ExportToPDF exporter = new ExportToPDF(gv1);
        //        exporter.PageTitle = ReportHeading;
        //        exporter.TableBorderThickness = 0;
        //        // exporter.
        //        //exporter.PdfExportSettings.Title = ReportHeading;
        //        exporter.ExportVisualSettings = ExportVisualSettings;
        //        exporter.ExportHierarchy = true;
        //        exporter.HiddenColumnOption = HiddenOption.DoNotExport;

        //        //exporter.SheetMaxRows = ExcelMaxRows._1048576;
        //        exporter.HTMLCellFormatting += new Telerik.WinControls.UI.Export.HTML.HTMLCellFormattingEventHandler(exporter_HTMLCellFormatting);
        //        //exporter.
        //        //exporter.htmlTableCreated += exporter_ExcelTableCreated;

        //        exporter.RunExport(fileName.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //static void exporter_HTMLCellFormatting(object sender, Telerik.WinControls.UI.Export.HTML.HTMLCellFormattingEventArgs e)
        //{
        //if (ExportArrHeader != null && ExportArrHeader.Count > 0)
        //{
        //    foreach (string str in ExportArrHeader)
        //    {
        //        SingleStyleElement style2 = ((ExportToPDF)sender).AddCustomExcelRow(e.ExcelTableElement, 20, str);
        //    }
        //}

        //    e.Styles.Append("table @page {" +
        //@"mso-header-data:'&CSAMPLE HEADER\000APage &P'; " +
        //@"mso-footer-data:'Date\: &D' }"); 

        //if (e.GridRowIndex == 1 && e.GridRowInfoType == typeof(GridViewDataRowInfo))
        //{
        //    e.HTMLCellElement.Value = "Test value";
        //    e.HTMLCellElement.Styles.Add("background-color", ColorTranslator.ToHtml(Color.Orange));
        //}

        //if (object.ReferenceEquals(e.GridRowInfoType, typeof(GridViewTableHeaderRowInfo)))
        //{
        //    e.HTMLCellElement.FontStyle.Bold = false;
        //    e.HTMLCellElement.FontStyle.Size = 8;
        //}
        //e.HTMLCellElement.FontStyle.Bold = false;
        //e.HTMLCellElement.FontStyle.Size = 8;
        //}
        /*Export to PDF*/


        private static string myExceptions(string strException)
        {
            if (strException.Contains("deadlocked"))
            {
                return ("Network is very busy." + Environment.NewLine + "Please try again....");
            }
            string subString = strException.Replace("System.Exception: ", "");
            if (subString.Length > 46)
            {
                subString = subString.Substring(0, 46);
                if (strException.Contains("Violation of PRIMARY KEY constraint") || clsCommon.CompairString(subString, "System.Data.SqlClient.SqlException: Violation ") == CompairStringResult.Equal)
                {
                    return ("Record already exist");
                }
                else if (strException.Contains("The INSERT statement conflicted with the FOREIGN KEY constraint") || clsCommon.CompairString(subString, "System.Data.SqlClient.SqlException: The INSERT") == CompairStringResult.Equal)
                {
                    return ("Invalid Value");
                }
                else if (strException.Contains("The DELETE statement conflicted with the REFERENCE constraint") || (clsCommon.CompairString(subString, "System.Data.SqlClient.SqlException: The DELETE") == CompairStringResult.Equal) || (clsCommon.CompairString(subString, "The DELETE statement conflicted with the REFER") == CompairStringResult.Equal))
                {
                    return ("Record is in use. Can Not be deleted.");
                }
                else if (strException.Contains("incorrect syntax near the keyword") || clsCommon.CompairString(subString, "System.Data.SqlClient.SqlException: Incorrect ") == CompairStringResult.Equal)
                {
                    return ("Incorrect syntax found.Please contact your service provider.");
                }
                else if (clsCommon.CompairString(subString, "System.Data.SqlClient.SqlException: Timeout ex") == CompairStringResult.Equal)
                {
                    return ("Request Titmeout. Please try again.");
                }
                else if (clsCommon.CompairString(subString, "System.InvalidCastException: Conversion from s") == CompairStringResult.Equal)
                {
                    return ("Data is not in correct format. Please check and try again.");
                }
            }
            return (strException);
        }

        public static DialogResult MyMessageBoxShow(string text)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(text);
        }

        public static DialogResult MyMessageBoxShow(IWin32Window parent, string text)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(parent, text);
        }

        public static DialogResult MyMessageBoxShow(string text, string caption)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(text, caption);
        }

        public static DialogResult MyMessageBoxShow(IWin32Window parent, string text, string caption)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(parent, text, caption);
        }

        public static DialogResult MyMessageBoxShow(string text, string caption, MessageBoxButtons buttons)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(text, caption, buttons);
        }

        public static DialogResult MyMessageBoxShow(IWin32Window parent, string text, string caption, MessageBoxButtons buttons)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(parent, text, caption, buttons);
        }

        public static DialogResult MyMessageBoxShow(string text, string caption, MessageBoxButtons buttons, RadMessageIcon icon)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult MyMessageBoxShow(IWin32Window parent, string text, string caption, MessageBoxButtons buttons, Bitmap icon)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(parent, text, caption, buttons, icon);
        }

        public static DialogResult MyMessageBoxShow(IWin32Window parent, string text, string caption, MessageBoxButtons buttons, RadMessageIcon icon)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(parent, text, caption, buttons, icon);
        }

        public static DialogResult MyMessageBoxShow(string text, string caption, MessageBoxButtons buttons, RadMessageIcon icon, MessageBoxDefaultButton defaultButton)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult MyMessageBoxShow(IWin32Window parent, string text, string caption, MessageBoxButtons buttons, Bitmap icon, MessageBoxDefaultButton defaultBtn)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(parent, text, caption, buttons, icon, defaultBtn);
        }

        public static DialogResult MyMessageBoxShow(IWin32Window parent, string text, string caption, MessageBoxButtons buttons, RadMessageIcon icon, MessageBoxDefaultButton defaultBtn)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(parent, text, caption, buttons, icon, defaultBtn);
        }

        public static DialogResult MyMessageBoxShow(IWin32Window parent, string text, string caption, MessageBoxButtons buttons, RadMessageIcon icon, MessageBoxDefaultButton defaultBtn, RightToLeft rtl)
        {
            text = myExceptions(text);
            return RadMessageBox.Show(parent, text, caption, buttons, icon, defaultBtn, rtl);
        }

        //private static void exporter_PDFTableCreated(object sender, ExcelTableCreatedEventArgs e)
        //{
        //    //add header row only for the first excel sheet                
        //    if (e.SheetIndex == 0)
        //    {
        //        if (clsCommon.myLen(ExportReportHeading) > 0)
        //        {
        //            SingleStyleElement style = ((ExportToExcelML)sender).AddCustomExcelRow(e.ExcelTableElement, 30, ExportReportHeading);
        //            style.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center;
        //            style.AlignmentElement.VerticalAlignment = VerticalAlignmentType.Center;
        //            style.InteriorStyle.Pattern = InteriorPatternType.Solid;
        //            style.FontStyle.Color = Color.Black;
        //            style.FontStyle.Bold = true;
        //            style.FontStyle.Size = 26;
        //        }

        //        if (ExportArrHeader != null && ExportArrHeader.Count > 0)
        //        {
        //            foreach (string str in ExportArrHeader)
        //            {
        //                SingleStyleElement style2 = ((ExportToExcelML)sender).AddCustomExcelRow(e.ExcelTableElement, 20, str);

        //            }
        //        }
        //    }
        //}
        //End of Export to PDF

        public static void MyExportToPDF(string ReportHeading, RadGridView gv1, List<String> arrHeader, string strReportNameInSaveDialog)
        {
            MyExportToPDF(ReportHeading, gv1, arrHeader, strReportNameInSaveDialog, false);
        }
        public static void MyExportToPDF(string ReportHeading, RadGridView gv1, List<String> arrHeader, string strReportNameInSaveDialog, bool isAskForPaperSize)
        {

            try
            {
                string subPath = "C:\\ERPTempFolder";

                bool IsExists = System.IO.Directory.Exists(subPath);

                if (!IsExists)
                {
                    System.IO.Directory.CreateDirectory(subPath);
                }
                strReportNameInSaveDialog += clsCommon.GetPrintDate(DateTime.Now, "yyyyMMddhhmmss");
                string FilePath = "C:\\ERPTempFolder\\" + strReportNameInSaveDialog + ".pdf";
                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.File.Delete(FilePath);
                }



                double dblDocWidth = 8.3;
                double dblDocHight = 11.7;
                MyPDFSize objPS = null;
                if (isAskForPaperSize)
                {
                    frmPDFPageSize frm = new frmPDFPageSize();
                    frm.ShowDialog();
                    objPS = frm.obj;

                    if (objPS != null)
                    {
                        switch (objPS.Page_Size)
                        {
                            case EnumPageSize.A0:
                                dblDocWidth = 33.1;
                                dblDocHight = 46.8;
                                break;
                            case EnumPageSize.A1:
                                dblDocWidth = 23.4;
                                dblDocHight = 33.1;
                                break;
                            case EnumPageSize.A2:
                                dblDocWidth = 16.5;
                                dblDocHight = 23.4;
                                break;
                            case EnumPageSize.A3:
                                dblDocWidth = 11.7;
                                dblDocHight = 16.5;
                                break;
                            case EnumPageSize.A4:
                                dblDocWidth = 8.3;
                                dblDocHight = 11.7;
                                break;
                            case EnumPageSize.A5:
                                dblDocWidth = 5.8;
                                dblDocHight = 8.3;
                                break;
                            case EnumPageSize.A6:
                                dblDocWidth = 4.1;
                                dblDocHight = 5.8;
                                break;
                            case EnumPageSize.A7:
                                dblDocWidth = 2.9;
                                dblDocHight = 4.1;
                                break;
                            case EnumPageSize.A8:
                                dblDocWidth = 2.0;
                                dblDocHight = 2.9;
                                break;
                            case EnumPageSize.Custom:
                                dblDocWidth = objPS.Width;
                                dblDocHight = objPS.Height;
                                break;
                        }

                        switch (objPS.Page_Style)
                        {
                            case EnumPageStyle.LandScape:
                                double temp = dblDocWidth;
                                dblDocWidth = dblDocHight;
                                dblDocHight = temp;
                                break;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                clsCommon.ProgressBarShow();



                double xPadding = 20;
                int dblTotalWidth = 0;
                DataTable dt = new DataTable();

                for (int i = 0; i < gv1.Columns.Count; i++)
                {
                    if (gv1.Columns[i].IsVisible)
                    {
                        dt.Columns.Add(gv1.Columns[i].Name, gv1.Columns[i].DataType);
                        dt.Columns[gv1.Columns[i].Name].Caption = gv1.Columns[i].HeaderText;
                        dblTotalWidth += gv1.Columns[i].Width;
                    }
                }

                int index = 0;
                int[] arr1 = new int[dt.Columns.Count];
                for (int i = 0; i < gv1.Columns.Count; i++)
                {
                    if (gv1.Columns[i].IsVisible)
                    {
                        arr1[index] = (105 * gv1.Columns[i].Width) / dblTotalWidth;
                        index++;
                    }
                }


                for (int ii = 0; ii < gv1.ChildRows.Count; ii++)
                {
                    DataRow dr = dt.NewRow();
                    for (int jj = 0; jj < gv1.Columns.Count; jj++)
                    {
                        if (gv1.Columns[jj].IsVisible)
                        {
                            if (gv1.ChildRows[ii].Cells[jj].Value == null)
                            {
                                dr[gv1.Columns[jj].Name] = DBNull.Value;
                            }
                            else
                            {
                                dr[gv1.Columns[jj].Name] = gv1.ChildRows[ii].Cells[jj].Value;
                            }
                        }
                    }
                    dt.Rows.Add(dr);
                }

                //int sada = gv1.MasterTemplate.SummaryRowsBottom.Count;
                //GridViewSummaryRowItem summaryRowItem = gv1.SummaryRowsBottom[0];
                //GridViewSummaryItem summaryItem = summaryRowItem["TotalFee"][0];
                //object summary = summaryItem.Evaluate(gv1.MasterTemplate);

                if (gv1.MasterTemplate.SummaryRowsBottom.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    for (int ii = 0; ii < gv1.MasterTemplate.SummaryRowsBottom[0].Count; ii++)
                    {
                        string colName = gv1.MasterTemplate.SummaryRowsBottom[0][ii].Name;
                        if (gv1.Columns[colName].IsVisible)
                        {
                            GridViewSummaryItem summaryItem = gv1.SummaryRowsBottom[0][ii];
                            object summary = summaryItem.Evaluate(gv1.MasterTemplate);
                            dr[colName] = summary;
                        }
                    }
                    dt.Rows.Add(dr);

                    //int sada = gv1.MasterTemplate.SummaryRowsBottom.Count;
                    //GridViewSummaryRowItem summaryRowItem = gv1.SummaryRowsBottom[0];
                    //GridViewSummaryItem summaryItem = summaryRowItem["TotalFee"][0];
                    //object summary = summaryItem.Evaluate(gv1.MasterTemplate);
                    //dt.Rows.Add(dr);
                }

                // Starting instantiate the document.
                // Remember to set the Docuement Format. In this case, we specify width and height.
                PdfDocument myPdfDocument = new PdfDocument(PdfDocumentFormat.InInches(dblDocWidth, dblDocHight));

                // Now we create a Table of 100 lines, 6 columns and 4 points of Padding.
                PdfTable myPdfTable = myPdfDocument.NewTable(new Font("Verdana", 8), dt.Rows.Count, dt.Columns.Count, 1);

                // Importing datas from the datatables... (also column names for the headers!)
                //myPdfTable.ImportDataTable((DataTable)gv1.DataSource);
                myPdfTable.ImportDataTable(dt);
                // Sets the format for correct date-time representation
                //myPdfTable.Columns[2].SetContentFormat("{0:dd/MM/yyyy}");

                // Now we set our Graphic Design: Colors and Borders...
                myPdfTable.HeadersRow.SetColors(Color.Black, Color.LightGray);
                myPdfTable.SetColors(Color.Black, Color.White, Color.White);
                myPdfTable.SetBorders(Color.Black, 1, BorderType.CompleteGrid);

                // With just one method we can set the proportional width of the columns.
                // It's a "percentage like" assignment, but the sum can be different from 100.

                myPdfTable.SetColumnsWidth(arr1);

                // You can also set colors for a range of cells, in this case, a row:
                //myPdfTable.Rows[7].SetColors(Color.Black, Color.LightGreen);

                // Now we set some alignment... for the whole table and then, for a column.
                //myPdfTable.SetContentAlignment(ContentAlignment.MiddleLeft);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (CompairString(dt.Columns[i].DataType.Name, "Double") == CompairStringResult.Equal || CompairString(dt.Columns[i].DataType.Name, "Decimal") == CompairStringResult.Equal || CompairString(dt.Columns[i].DataType.Name, "int32") == CompairStringResult.Equal || CompairString(dt.Columns[i].DataType.Name, "int64") == CompairStringResult.Equal)
                    {
                        myPdfTable.Columns[i].SetContentAlignment(ContentAlignment.TopRight);
                    }
                    else
                    {
                        myPdfTable.Columns[i].SetContentAlignment(ContentAlignment.TopLeft);
                    }
                }




                // Here we start the loop to generate the table...
                while (!myPdfTable.AllTablePagesCreated)
                {
                    // we create a new page to put the generation of the new TablePage:
                    PdfPage newPdfPage = myPdfDocument.NewPage();
                    PdfTablePage newPdfTablePage = myPdfTable.CreateTablePage(new PdfArea(myPdfDocument, xPadding, 40 + (arrHeader.Count * 15), dblDocWidth * 68, dblDocHight * 55));

                    // we also put a Label 
                    PdfTextArea pta = new PdfTextArea(new Font("Verdana", 13, FontStyle.Bold), Color.Black, new PdfArea(myPdfDocument, xPadding, 10, dblDocWidth * 68, 20), ContentAlignment.TopCenter, ReportHeading);
                    newPdfPage.Add(pta);
                    double PosY = 15;
                    foreach (string strFilter in arrHeader)
                    {
                        PosY += 15;
                        PdfTextArea pta1 = new PdfTextArea(new Font("Verdana", 10, FontStyle.Regular), Color.Black, new PdfArea(myPdfDocument, xPadding, PosY, dblDocWidth * 68, 20), ContentAlignment.TopLeft, strFilter);
                        newPdfPage.Add(pta1);
                    }

                    // nice thing: we can put all the objects in the following lines, so we can have
                    // a great control of layer sequence... 
                    newPdfPage.Add(newPdfTablePage);


                    // Now we create a loop for serching for people born in 1968. If we find
                    // one, we will draw a circle over the number. This is possible using the
                    // the CellArea, that is the Area occupied by a rasterized Cell.
                    //for (int index = newPdfTablePage.FirstRow; index <= newPdfTablePage.LastRow; index++)
                    //    if (((DateTime)myPdfTable.Rows[index][2].Content).Year == 1968)
                    //    {
                    //        PdfCircle pc = newPdfTablePage.CellArea(index, 2).InnerCircle(Color.Blue, 2);
                    //        pc.StrokeWidth = 3.5;
                    //        newPdfPage.Add(pc);
                    //    }
                    // we save each generated page before start rendering the next.
                    newPdfPage.SaveToDocument();
                }
                // Finally we save the docuement...
                myPdfDocument.SaveToFile(FilePath);
                System.Diagnostics.Process.Start(FilePath);
            }
            catch (Exception ex)
            {
                clsCommon.ProgressBarHide();
                MyMessageBoxShow(ex.Message);
            }
            finally
            {
                clsCommon.ProgressBarHide();
            }
        }

        public static Image MyBarcodeImage(string InputData, int BarWeight, bool AddQuietZone)
        {
            return Code128Rendering.MakeBarcodeImage(InputData, BarWeight, AddQuietZone);
        }

        //public static bool myInternetWork()
        //{
        //    try
        //    {
        //        return My.Computer.Network.Ping("www.google.com");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return false;
        //}
        public static bool myInternetWork()
        {
            Ping ping = new Ping();
            PingReply reply;
            try
            {
                reply = ping.Send("www.google.com");
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }


        public static bool MyExportToExcelPivotGrid(string ReportHeading, RadPivotGrid gv1, List<String> arrHeader, string strReportNameInSaveDialog)
        {
            return MyExportToExcelPivotGrid(ReportHeading, gv1, arrHeader, strReportNameInSaveDialog, false);
        }
        public static bool MyExportToExcelPivotGrid(string ReportHeading, RadPivotGrid gv1, List<String> arrHeader, string strReportNameInSaveDialog, bool ExportVisualSettings)
        {
            string subPath = "";
            return MyExportToExcelPivotGrid(ReportHeading, gv1, arrHeader, strReportNameInSaveDialog, ExportVisualSettings, out subPath);
        }
        public static bool MyExportToExcelPivotGrid(string ReportHeading, RadPivotGrid gv1, List<String> arrHeader, string strReportNameInSaveDialog, bool ExportVisualSettings, out string subPath)
        {
            subPath = "C:\\ERPTempFolder"; // your code goes here
            try
            {
                bool IsExists = System.IO.Directory.Exists(subPath);

                if (!IsExists)
                {
                    System.IO.Directory.CreateDirectory(subPath);
                }
                strReportNameInSaveDialog += clsCommon.GetPrintDate(DateTime.Now, "yyyyMMddhhmmss");
                string FilePath = "C:\\ERPTempFolder\\" + strReportNameInSaveDialog.Replace("/", "_").Replace("\\", "_") + ".xls";
                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.File.Delete(FilePath);
                }
                subPath = FilePath;
                ExportReportHeading = ReportHeading;
                ExportArrHeader = new List<string>();
                ExportArrHeader = arrHeader;
                clsCommon.ProgressBarShow();
                RunPivotExportToExcelML(ReportHeading, FilePath, gv1, ExportVisualSettings);
                clsCommon.ProgressBarHide();
                //RadMessageBox.Show("Export finished successfully", ReportHeading, MessageBoxButtons.OK, RadMessageIcon.Info);
                ApplyWordWrapInExcel(FilePath );
                System.Diagnostics.Process.Start(FilePath);


            }
            catch (Exception ex)
            {
                clsCommon.ProgressBarHide();
                RadMessageBox.Show(ex.Message);
            }
            finally
            {
                clsCommon.ProgressBarHide();
            }
            return true;
        }

        private static void RunPivotExportToExcelML(string ReportHeading, string fileName, RadPivotGrid gv1, bool ExportVisualSettings)
        {
            PivotExportToExcelML exporter;
            try
            {

                exporter = new PivotExportToExcelML(gv1);
                exporter.ExportVisualSettings = ExportVisualSettings;

                //exporter.SummariesExportOption = SummariesOption.ExportAll;
                //exporter.HiddenColumnOption = HiddenOption.DoNotExport;
                //exporter.SheetMaxRows = ExcelMaxRows._1048576;
                //exporter.ExcelCellFormatting += exporter_ExcelCellFormatting;
                //exporter.ExcelTableCreated += exporter_ExcelTableCreated;
                //exporter.ChildViewExportMode = ChildViewExportMode.ExportCurrentlyActiveView;
                exporter.RunExport(fileName.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exporter = null;
            }
        }

        public static string ImageConvertDataRowToHexa(DataRow dr, string strColumnName)
        {
            string strHexa = null;
            try
            {
                if (dr[strColumnName] != DBNull.Value)
                {
                    byte[] byArr = (byte[])dr[strColumnName];
                    System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary shb = new System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary(byArr);
                    strHexa = clsCommon.myCstr(shb);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return strHexa;
        }



        public static byte[] ImageConvertHexaToByteArr(string strHexa)
        {
            byte[] byArr = null;
            try
            {
                if (clsCommon.myLen(strHexa) > 0)
                {
                    System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary shb1 = System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary.Parse(strHexa);
                    byArr = shb1.Value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return byArr;
        }

        public static DataTable ExcelToDatatable( )
        {
            DataTable dtReturn = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            bool rvalue = false;
            OpenFileDialog ofd = new OpenFileDialog();
            string filePath = null;
            ofd.Filter = "Excel 97-2003 (*.xls) |*.xls;|Excel 2007 (*.xlsx)|*.xlsx;|CSV Files (*.csv) |*.csv";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return dtReturn;
            }
            string Extension = System.IO.Path.GetExtension(filePath);
            string conStr = "";
            string selectedFormat = Extension;
            dtReturn = new DataTable();
            int colCount = 0;
            if (true)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application oApp = default(Microsoft.Office.Interop.Excel.Application);
                    oApp = new Microsoft.Office.Interop.Excel.Application();
                    oApp.Visible = false;
                    oApp.DisplayAlerts = false;
                    workbook = oApp.Workbooks.Open(filePath);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
                    clsCommon.ProgressBarPercentShow();
                    Microsoft.Office.Interop.Excel.Range r = worksheet.UsedRange;


                    object[,] array = (object[,])r.get_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault);
                    int bound0 = array.GetUpperBound(0);
                    int bound1 = array.GetUpperBound(1);
                    for (int i = 1; i <= bound1; i++)
                    {
                        clsCommon.ProgressBarPercentUpdate(((i) * 100 / bound1), "Getting Field List " + (i) + " Of Total " + bound1 + " From Excel Sheet");
                        dtReturn.Columns.Add(clsCommon.myCstr(array[1, i]), "".GetType());
                        dtReturn.Columns[clsCommon.myCstr(array[1, i])].Caption = clsCommon.myCstr(array[1, i]);
                    }
                    for (int j = 2; j <= bound0; j++)
                    {
                        clsCommon.ProgressBarPercentUpdate(((j) * 100 / bound0), "Getting Record List " + (j) + " Of Total " + bound0 + " From Excel Sheet");
                        DataRow dr = dtReturn.NewRow();
                        for (int x = 1; x <= bound1; x++)
                        {
                            dr[clsCommon.myCstr(array[1, x])] = array[j, x];
                        }
                        dtReturn.Rows.Add(dr);
                    }
                    oApp.Workbooks.Close();
                    clsCommon.ProgressBarPercentHide();
                }
                catch (System.IO.IOException ex)
                {
                    try
                    {
                        clsCommon.ProgressBarPercentHide();
                    }
                    catch (Exception ex1)
                    {
                    }
                    throw new Exception(ex.Message);
                }

            }
            return dtReturn;
        }
    } 

    public class clsCommonFunctionality
    {
        public static int TableCounter=0;
        public static int TableTotal = 1;

        public static bool CreateOrAlterTable(string strTableName, IDictionary<string, string> lstColumnCollection)  
        {
            return CreateOrAlterTable(strTableName, lstColumnCollection, "");
        }

        public static bool CreateOrAlterTable( string strTableName, IDictionary<string, string> lstColumnCollection, string strAddConstraint)
        {
            return CreateOrAlterTable(false, strTableName, lstColumnCollection, strAddConstraint);
        }

        public static bool CreateOrAlterTable(bool isRunOnLinkedServer, string strTableName, IDictionary<string, string> lstColumnCollection, string strAddConstraint)
        {
            return CreateOrAlterTable(isRunOnLinkedServer, strTableName, lstColumnCollection, strAddConstraint, false);
        }
        public static bool CreateOrAlterTable(bool isRunOnLinkedServer, string strTableName, IDictionary<string, string> lstColumnCollection, string strAddConstraint,bool isCreateHistoryTable)
        {
            strTableName = strTableName.ToUpper();
            string qry = string.Empty;
            DataTable dt = null;
            string strColl = string.Empty;
            try
            {
                try
                {
                    TableCounter += 1;
                    clsCommon.ProgressBarPercentUpdate(((TableCounter*100) /  (TableTotal==0?1:TableTotal)), "Verifying Table Structure - " + strTableName);
                }
                catch (System.Exception)
                {
                }

                
                qry = "select table_name from INFORMATION_SCHEMA.Tables where TABLE_TYPE ='BASE TABLE' and table_name='" + strTableName + "'";
                dt = clsDBFuncationality.GetDataTable(isRunOnLinkedServer, qry);
                if (dt != null && dt.Rows.Count > 0)
                {
                    qry = "select * from " + strTableName + " where 1=2";
                    dt = new DataTable();
                    dt = clsDBFuncationality.GetDataTable(isRunOnLinkedServer,qry.ToUpper());
                    if (dt != null && dt.Columns.Count > 0)
                    {
                        foreach (string key in lstColumnCollection.Keys)
                        {
                            if (!dt.Columns.Contains(key))
                            {
                                //Table Already Exist so Adding Column Here
                                try
                                {
                                    qry = "Alter table " + strTableName + " add [" + key + "] " + lstColumnCollection[key];
                                    if (clsCommon.myCstr(lstColumnCollection[key]).ToUpper().Contains(" REFERENCES "))
                                    {
                                        qry += " ON UPDATE CASCADE ";
                                    }
                                    clsDBFuncationality.ExecuteNonQuery(qry,isRunOnLinkedServer);
                                }
                                catch (System.Exception ex)
                                {
                                    if (ex.Message.Contains("Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints"))
                                    {
                                        qry = "Alter table " + strTableName + " add [" + key + "] " + lstColumnCollection[key];
                                        clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                                    }
                                    else
                                    {
                                        throw new Exception(ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Table Not Exist so Creating Table here
                    try
                    {
                        strColl = "";
                        foreach (string key in lstColumnCollection.Keys)
                        {
                            if (clsCommon.myLen(strColl) > 0)
                            {
                                strColl += ",";
                            }
                            strColl += "[" + key + "] " + lstColumnCollection[key];
                            if (clsCommon.myCstr(lstColumnCollection[key]).ToUpper().Contains(" REFERENCES "))
                            {
                                strColl += " ON UPDATE CASCADE ";
                            }
                        }
                        qry = "Create table " + strTableName + " (" + strColl + " " + strAddConstraint + ")";
                        clsDBFuncationality.ExecuteNonQuery(qry,isRunOnLinkedServer);
                    }
                    catch (System.Exception ex)
                    {
                        if (ex.Message.Contains("Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints"))
                        {
                            strColl = "";
                            foreach (string key in lstColumnCollection.Keys)
                            {
                                if (clsCommon.myLen(strColl) > 0)
                                {
                                    strColl += ",";
                                }
                                strColl += "[" + key + "] " + lstColumnCollection[key];
                            }
                            qry = "Create table " + strTableName + " (" + strColl + " " + strAddConstraint + ")";
                            clsDBFuncationality.ExecuteNonQuery(qry,isRunOnLinkedServer);
                        }
                        else
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
                AddKey(strTableName, lstColumnCollection,isRunOnLinkedServer);

                if (clsCommon.myLen(strAddConstraint) > 0)
                {
                    try
                    {
                        qry = "alter table " + strTableName + "  add " + strAddConstraint;
                        clsDBFuncationality.ExecuteNonQuery(qry,isRunOnLinkedServer);
                    }
                    catch (System.Exception)
                    {
                    }

                }   
            }
            catch (Exception err)
            {
                clsCommon.MyMessageBoxShow(err.Message, "Error in Create Table");
                return false;
            }
            finally
            {
                qry = string.Empty;
                dt = null;
                strColl = string.Empty;
            }
           
            try
            {
                if (isCreateHistoryTable)
                {
                    try
                    {
                        TableCounter += 1;
                        clsCommon.ProgressBarPercentUpdate(((TableCounter * 100) / (TableTotal == 0 ? 1 : TableTotal)), "Verifying Table Structure - " + strTableName + clsCommon.HistTablePostFix + "");
                    }
                    catch (System.Exception)
                    {
                    }
                    CreateHistoryTable(strTableName, isRunOnLinkedServer);
                }
            }
            catch (System.Exception err)
            {
                clsCommon.MyMessageBoxShow(err.Message, "Error in Create History Table");
            }

            return true;
        }

        private static void CreateHistoryTable(string strTableName, bool isRunOnLinkedServer)
        {
            string qry = "select table_name from INFORMATION_SCHEMA.Tables where TABLE_TYPE ='BASE TABLE' and table_name='" + strTableName + clsCommon.HistTablePostFix + "'";
            DataTable dt = clsDBFuncationality.GetDataTable(isRunOnLinkedServer, qry);
            qry = "select * from ( " + Environment.NewLine +
             "select COLUMN_NAME " + Environment.NewLine +
             ",max(case when TABLE_NAME='" + strTableName + "' then DATA_TYPE else  null end ) as DATA_TYPE " + Environment.NewLine +
             " ,max(case when TABLE_NAME='" + strTableName + clsCommon.HistTablePostFix + "' then DATA_TYPE else  null end ) as DATA_TYPE_HIST " + Environment.NewLine +
             ",max(case when TABLE_NAME='" + strTableName + "' then CHARACTER_MAXIMUM_LENGTH else  null end ) as CHARACTER_MAXIMUM_LENGTH " + Environment.NewLine +
             ",max(case when TABLE_NAME='" + strTableName + clsCommon.HistTablePostFix + "' then CHARACTER_MAXIMUM_LENGTH else  null end ) as CHARACTER_MAXIMUM_LENGTH_HIST" + Environment.NewLine +
             ",max(case when TABLE_NAME='" + strTableName + "' then NUMERIC_PRECISION else  null end ) as NUMERIC_PRECISION" + Environment.NewLine +
             ",max(case when TABLE_NAME='" + strTableName + clsCommon.HistTablePostFix + "' then NUMERIC_PRECISION else  null end ) as NUMERIC_PRECISION_HIST" + Environment.NewLine +
             ",max(case when TABLE_NAME='" + strTableName + "' then NUMERIC_SCALE else  null end ) as NUMERIC_SCALE" + Environment.NewLine +
             ",max(case when TABLE_NAME='" + strTableName + clsCommon.HistTablePostFix + "' then NUMERIC_SCALE else  null end ) as NUMERIC_SCALE_HIST" + Environment.NewLine +
             "from INFORMATION_SCHEMA.COLUMNS " + Environment.NewLine +
             "where TABLE_NAME in ('" + strTableName + "','" + strTableName + clsCommon.HistTablePostFix + "')" + Environment.NewLine +
             "group by COLUMN_NAME" + Environment.NewLine +
             "having sum(case when TABLE_NAME='" + strTableName + "' then 1 else 0 end)=1" + Environment.NewLine +
             ")xx where isnull(DATA_TYPE,'')<>isnull( DATA_TYPE_HIST ,'')" + Environment.NewLine +
             "or isnull(CHARACTER_MAXIMUM_LENGTH,0)<>isnull(CHARACTER_MAXIMUM_LENGTH_HIST,0) or isnull( NUMERIC_PRECISION,0)<>isnull(NUMERIC_PRECISION_HIST,0) or isnull(NUMERIC_SCALE,0)<>isnull(NUMERIC_SCALE_HIST,0)";
            DataTable dtColumns = clsDBFuncationality.GetDataTable(isRunOnLinkedServer, qry);
            if (dtColumns != null && dtColumns.Rows.Count > 0)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtColumns.Rows)
                    {

                        //Table Already Exist so Adding Column Here
                        try
                        {
                            if (clsCommon.myLen(clsCommon.myCstr(dr["DATA_TYPE"])) > 0 && clsCommon.myLen(clsCommon.myCstr(dr["DATA_TYPE_HIST"])) <= 0)
                            {
                                qry = "Alter table " + strTableName + clsCommon.HistTablePostFix + " add [" + clsCommon.myCstr(dr["COLUMN_NAME"]) + "] " + GetHistoryColumnType(dr);
                                clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                            }
                            else if (clsCommon.myLen(clsCommon.myCstr(dr["DATA_TYPE"]))>0 && clsCommon.myLen(clsCommon.myCstr(dr["DATA_TYPE_HIST"]))>0)
                            {
                                if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), clsCommon.myCstr(dr["DATA_TYPE_HIST"])) == CompairStringResult.Equal)
                                {
                                    qry = "Alter table " + strTableName + clsCommon.HistTablePostFix + " alter column [" + clsCommon.myCstr(dr["COLUMN_NAME"]) + "] " + GetHistoryColumnType(dr);
                                    clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                                }
                                else
                                {
                                    qry = " exec sp_rename '" + strTableName + clsCommon.HistTablePostFix + "." + clsCommon.myCstr(dr["COLUMN_NAME"]) + "','" + clsCommon.myCstr(dr["COLUMN_NAME"]) + clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "yyyymmddhhmmtt") + "','column' ";
                                    clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);

                                    qry = "Alter table " + strTableName + clsCommon.HistTablePostFix + " add [" + clsCommon.myCstr(dr["COLUMN_NAME"]) + "] " + GetHistoryColumnType(dr);
                                    clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                                }
                            }
                        }
                        catch (System.Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
                else
                {
                    //Table Not Exist so Creating Table here
                    try
                    {
                        string strColl = "";
                        foreach (DataRow dr in dtColumns.Rows)
                        {
                            if (clsCommon.myLen(strColl) > 0)
                            {
                                strColl += ",";
                            }
                            strColl += "[" + clsCommon.myCstr(dr["COLUMN_NAME"]) + "] " + GetHistoryColumnType(dr);
                        }
                        qry = "Create table " + strTableName + clsCommon.HistTablePostFix + " ("+clsCommon.HistTableColHistBy+" varchar(12) null,"+clsCommon.HistTableColHistOn+" Datetime null,"+clsCommon.HistTableColHistVersion+" integer null, " + strColl + " )";
                        clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                    }
                    catch (System.Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        static string GetHistoryColumnType(DataRow dr)
        {
            string strColl="";
            if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "image") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "int") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "decimal") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + "(" + clsCommon.myCstr(dr["NUMERIC_PRECISION"]) + "," + clsCommon.myCstr(dr["NUMERIC_SCALE"]) + ") null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "varbinary") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]);
                if (clsCommon.myCdbl(dr["CHARACTER_MAXIMUM_LENGTH"]) == -1 )
                {
                    strColl += "(Max) ";
                }
                strColl += " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "text") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "varchar") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]);
                if (clsCommon.myCdbl(dr["CHARACTER_MAXIMUM_LENGTH"]) == -1)
                {
                    strColl += "(Max) ";
                }
                else
                {
                    strColl += "(" + clsCommon.myCstr(clsCommon.myCdbl(dr["CHARACTER_MAXIMUM_LENGTH"])) + ") ";
                }
                strColl += " null";
            }
            //else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "binary") == CompairStringResult.Equal)
            //{
            //    strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            //}
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "datetime") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "time") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "numeric") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + "(" + clsCommon.myCstr(dr["NUMERIC_PRECISION"]) + "," + clsCommon.myCstr(dr["NUMERIC_SCALE"]) + ") null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "tinyint") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "nchar") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " (" + clsCommon.myCstr(dr["CHARACTER_MAXIMUM_LENGTH"]) + ") null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "smalldatetime") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "float") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "date") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "char") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " (" + clsCommon.myCstr(dr["CHARACTER_MAXIMUM_LENGTH"]) + ") null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "bigint") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "nvarchar") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]);
                if (clsCommon.myCdbl(dr["CHARACTER_MAXIMUM_LENGTH"]) == -1)
                {
                    strColl += "(Max) ";
                }
                else
                {
                    strColl += "(" + clsCommon.myCstr(clsCommon.myCdbl(dr["CHARACTER_MAXIMUM_LENGTH"])) + ") ";
                }
                strColl += " null";
            }
            else if (clsCommon.CompairString(clsCommon.myCstr(dr["DATA_TYPE"]), "bit") == CompairStringResult.Equal)
            {
                strColl += " " + clsCommon.myCstr(dr["DATA_TYPE"]) + " null";
            }
            else
            {
                throw new Exception("Data type " + clsCommon.myCstr(dr["DATA_TYPE"]) + "not definded for create history table");
            }
            return strColl;
        }


        //public static bool CreateOrAlterTable(string strTableName, IDictionary<string, string> lstColumnCollection,bool is_history)
        //{
        //    return CreateOrAlterTable(strTableName, lstColumnCollection, "", is_history);
        //}

        //public static bool CreateOrAlterTable(string strTableName, IDictionary<string, string> lstColumnCollection, string strAddConstraint, bool is_History)
        //{
        //    strTableName = strTableName.ToUpper();
        //    string qry = string.Empty;
        //    DataTable dt = null;
        //    string strColl = string.Empty;
        //    try
        //    {
        //        try
                            
        //        {
        //            clsCommon.ProgressBarUpdate("Verifying Table Structure - " + strTableName);
        //        }
        //        catch (System.Exception)
        //        {
        //        }


        //        qry = "select table_name from INFORMATION_SCHEMA.Tables where TABLE_TYPE ='BASE TABLE' and table_name='" + strTableName + "'";
        //        dt = clsDBFuncationality.GetDataTable(qry);
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            qry = "select * from " + strTableName + " where 1=2";
        //            dt = new DataTable();
        //            dt = clsDBFuncationality.GetDataTable(qry.ToUpper());
        //            if (dt != null && dt.Columns.Count > 0)
        //            {
        //                foreach (string key in lstColumnCollection.Keys)
        //                {
        //                    if (!dt.Columns.Contains(key))
        //                    {
        //                        //Table Already Exist so Adding Column Here
        //                        qry = "Alter table " + strTableName + " add [" + key + "] " + lstColumnCollection[key];

        //                        if (clsCommon.myCstr(lstColumnCollection[key]).ToUpper().Contains(" REFERENCES "))
        //                        {
        //                            qry += " ON UPDATE CASCADE";
        //                        }  

        //                        clsDBFuncationality.ExecuteNonQuery(qry);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //Table Not Exist so Creating Table here
        //            strColl = "";
        //            foreach (string key in lstColumnCollection.Keys)
        //            {
        //                if (clsCommon.myLen(strColl) > 0)
        //                {
        //                    strColl += ",";
        //                }
        //                strColl += "[" + key + "] " + lstColumnCollection[key];
        //            }
        //            qry = "Create table " + strTableName + " (" + strColl + " " + strAddConstraint + ")";
        //            clsDBFuncationality.ExecuteNonQuery(qry);
        //        }
        //        AddKey(strTableName, lstColumnCollection);
        //        if (clsCommon.myLen(strAddConstraint) > 0)
        //        {
        //            try
        //            {
        //                qry = "alter table " + strTableName + "  add " + strAddConstraint;
        //                clsDBFuncationality.ExecuteNonQuery(qry);
        //            }
        //            catch (System.Exception)
        //            {
        //            }

        //        }
        //        if (is_History)
        //        {
        //            CreateOrAlterHistoryTable(strTableName.Replace(" ", "") + "_History_Data", lstColumnCollection, "", true);
        //            CreateOrAlterHistoryTrigger(strTableName);
        //        }
        //        //else
        //        //{
        //        //    CreateOrAlterHistoryTable(strTableName.Replace(" ", "") + "_History_Data", lstColumnCollection, "", false);
        //        //    CreateOrAlterHistoryTrigger(strTableName);
        //        //}

        //    }
        //    catch (Exception err)
        //    {

        //        clsCommon.MyMessageBoxShow(err.Message, "Error in Create Table");
        //        return false;
        //    }
        //    finally
        //    {
                
        //        qry = string.Empty;
        //        dt = null;
        //        strColl = string.Empty;
        //   }
        //    return true;
        //}


        //public static bool CheckTableExist(string strTableName)
        //{
        //    try
        //    {
        //        string  sql = string.Format(
        //            "SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{0}'",
        //             strTableName);
        //        double  cnt = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(sql));
        //        if (cnt > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return false;
        //        throw new Exception (ex.Message);
        //    }
        //            }
        //public static bool CreateOrAlterHistoryTrigger(string strTableName)
        //{
        //    try
        //    {
        //        if (clsCommonFunctionality.CheckTableExist(strTableName) && clsCommonFunctionality.CheckTableExist(strTableName+ "_History_Data"))
        //        {
        //            try
        //            {
        //                string sql ="drop trigger "+strTableName + "_Update_History_Trigger ";
        //                clsDBFuncationality.getSingleValue(sql);
        //               }
        //            catch (System.Exception ex1)
        //            {
        //                                     }
                    
        //            string fieldList = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select dbo.fnColList('" + strTableName + "')"));
        //            string qry = "CREATE TRIGGER " + strTableName + "_Update_History_Trigger ";
        //            qry += "ON " + strTableName;
        //            qry += " FOR UPDATE,DELETE ";
        //            qry += "AS ";
        //            qry += "INSERT INTO " + strTableName + "_History_Data ( " + fieldList + ",history_date) SELECT " + fieldList  + ",convert(varchar,getdate(),103) FROM deleted  ";
        //            clsDBFuncationality.ExecuteNonQuery(qry);
        //        }
        //       }
        //    catch (System.Exception ex)
        //    {
        //        return false;
        //        throw new Exception (ex.Message );
        //    }
        //    return true;
        //}

        //public static bool CreateOrAlterHistoryTable(string strTableName, IDictionary<string, string> lstColumnCollection, string strAddConstraint, bool addHistoryColumns)
        //{
           
            

        //    //string New_Key;
        //    var lstColumnCollection_New = new Dictionary<string, string> ();
            
        //    foreach ( KeyValuePair<string, string> key in lstColumnCollection)
        //    {
        //        //lstColumnCollection.Remove(key.Key);
        //        //lstColumnCollection.Add(key.Key.ToLower(),key.Value);
        //        if (key.Value.ToLower().Contains("reference"))
        //        {
        //            lstColumnCollection_New.Add(key.Key.ToLower(), key.Value.ToLower().Replace(key.Value.Substring(key.Value.ToLower().IndexOf("reference"), key.Value.Length - key.Value.ToLower().IndexOf("reference")).ToLower(), "").Replace("primary", "").Replace("key", "").Replace("not", "").Replace("identity", ""));
        //        }
        //        else
        //        {
        //            lstColumnCollection_New.Add(key.Key.ToLower(), key.Value.ToLower().Replace("primary", "").Replace("key", "").Replace("not", "").Replace("identity", ""));
        //        }
        //        //key.Key.ToLower();
        //       //lstColumnCollection[key.Key][key.Value].ToLower().Replace("primary", "");
        //       //lstColumnCollection[key.key].ToLower().Replace("key", "");
        //       //lstColumnCollection[key.Value].ToLower().Replace("not", "");
        //       //if (lstColumnCollection[key.Value].ToLower().Contains("reference"))
        //       // {
        //       //     lstColumnCollection[key.Value].ToLower().Replace(lstColumnCollection[key.Value].Substring(key.Value.ToLower().IndexOf("reference"), lstColumnCollection[key.Value].Length - 1), "");
        //       // }
        //        //New_Key = lstColumnCollection[key];
        //        //lstColumnCollection.Remove(key);
        //        //lstColumnCollection.Add(New_Key, key.GetType);
                   
        //    }
        //    lstColumnCollection.Clear();
        //    foreach (KeyValuePair<string, string> key in lstColumnCollection_New)
        //    {
        //        if (key.Value.ToUpper().Contains("REPLICATION"))
        //        {
        //            lstColumnCollection.Add(key.Key.ToLower(), key.Value.ToLower().Replace(key.Value.Substring(key.Value.ToLower().IndexOf("(1,1)"), key.Value.ToUpper().LastIndexOf("REPLICATION") - key.Value.ToLower().IndexOf("(1,1)")).ToLower(), "").ToUpper().Replace("REPLICATION", ""));
        //        }
        //        if (!key.Value.ToUpper().Contains("REPLICATION"))
        //        {
        //            if (key.Value.ToUpper().Contains("(1,1)") )
        //            {
        //                lstColumnCollection.Add(key.Key.ToLower(), key.Value.ToLower().Replace(key.Value.Substring(key.Value.ToLower().IndexOf("(1,1)"), 5), ""));
        //            }
        //            else
        //            {
        //                lstColumnCollection.Add(key.Key.ToLower(), key.Value);
        //            }
        //        }
        //        }
        //    if (true == addHistoryColumns)
        //    {
        //        if (!lstColumnCollection.Keys.Contains("history_by"))
        //        {
        //            lstColumnCollection.Add("History_By", "varchar(30) NUll");
        //        }
        //        if (!lstColumnCollection.Keys.Contains("history_date"))
        //        {
        //            lstColumnCollection.Add("History_Date", "varchar(30) Null");
        //        }
        //        if (!lstColumnCollection.Keys.Contains("version_id"))
        //        {
        //            lstColumnCollection.Add("Version_Id", "integer Null");
        //        }
        //        if (!lstColumnCollection.Keys.Contains("Cancel_Remark"))
        //        {
        //            lstColumnCollection.Add("Cancel_Remark", "Varchar(200) Null");
        //        }
        //    }
        //    else
        //    {
        //        if (!lstColumnCollection.Keys.Contains("version_id"))
        //        {
        //            lstColumnCollection.Add("Version_Id", "integer Null");
        //        }
        //    } 
           
        //    strTableName = strTableName.ToUpper();
        //    string qry = string.Empty;
        //    DataTable dt = null;
        //    string strColl = string.Empty;
        //    try
        //    {
        //        try
        //        {
        //            clsCommon.ProgressBarUpdate("Verifying Table Structure - " + strTableName);
        //        }
        //        catch (System.Exception)
        //        {
        //        }


        //        qry = "select table_name from INFORMATION_SCHEMA.Tables where TABLE_TYPE ='BASE TABLE' and table_name='" + strTableName + "'";
        //        dt = clsDBFuncationality.GetDataTable(qry);
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            qry = "select * from " + strTableName + " where 1=2";
        //            dt = new DataTable();
        //            dt = clsDBFuncationality.GetDataTable(qry.ToUpper());
        //            if (dt != null && dt.Columns.Count > 0)
        //            {
        //                foreach (string key in lstColumnCollection.Keys)
        //                {
        //                    if (!dt.Columns.Contains(key))
        //                    {
        //                        //Table Already Exist so Adding Column Here
        //                        qry = "Alter table " + strTableName + " add [" + key + "] " + lstColumnCollection[key];
        //                        clsDBFuncationality.ExecuteNonQuery(qry);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //Table Not Exist so Creating Table here
        //            strColl = "";
        //            foreach (string key in lstColumnCollection.Keys)
        //            {
        //                if (clsCommon.myLen(strColl) > 0)
        //                {
        //                    strColl += ",";
        //                }
        //                strColl += "[" + key + "] " + lstColumnCollection[key];
        //            }
        //            qry = "Create table " + strTableName + " (" + strColl + " " + strAddConstraint + ")";
        //            clsDBFuncationality.ExecuteNonQuery(qry);
        //        }
        //        AddKey(strTableName, lstColumnCollection);
        //    }
        //    catch (Exception err)
        //    {
        //        clsCommon.MyMessageBoxShow(err.Message, "Error in Create Table");
        //        return false;
        //    }
        //    finally
        //    {
        //        qry = string.Empty;
        //        dt = null;
        //        strColl = string.Empty;
        //    }
        //    return true;
        //}

        private static void AddKey(string strTableName, IDictionary<string, string> lstColumnCollection)
        {
            AddKey(strTableName, lstColumnCollection, false);
        }
        private static void AddKey(string strTableName, IDictionary<string, string> lstColumnCollection, bool isRunOnLinkedServer)
        {
            string qry = string.Empty;
            DataTable dt = null;
            string[] subString;
            string strVal = string.Empty;
            try
            {
                qry = "select TABLE_NAME,COLUMN_NAME,CONSTRAINT_NAME, left(CONSTRAINT_NAME,2) as KeyType from INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where TABLE_NAME='" + strTableName + "'";
                dt = clsDBFuncationality.GetDataTable(isRunOnLinkedServer,qry);

                if (dt != null && dt.Columns.Count > 0)
                {
                    foreach (string key in lstColumnCollection.Keys)
                    {
                        bool isFound = false;
                        strVal = clsCommon.myCstr(lstColumnCollection[key]).ToUpper();
                        if (strVal.Contains(" PRIMARY "))
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if ((clsCommon.CompairString(clsCommon.myCstr(dr["COLUMN_NAME"]), key) == CompairStringResult.Equal) && (clsCommon.CompairString(clsCommon.myCstr(dr["KeyType"]), "PK") == CompairStringResult.Equal))
                                {
                                    isFound = true;
                                }
                            }
                            if (!isFound)
                            {
                                subString = strVal.Split(new string[] { " PRIMARY " }, StringSplitOptions.None);
                                qry = "select IS_NULLABLE  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + strTableName + "' and COLUMN_NAME='" + key + "'";
                                if (clsCommon.CompairString(clsCommon.myCstr(clsDBFuncationality.getSingleValue(isRunOnLinkedServer,qry)), "YES") == CompairStringResult.Equal)
                                {
                                    subString = strVal.Split(new string[] { "PRIMARY" }, StringSplitOptions.None);

                                    qry = "Alter table " + strTableName + " alter column " + key + " " + subString[0];
                                    clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                                }


                                qry = "Alter table " + strTableName + " add PRIMARY KEY (" + key + ")";
                                clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                            }
                        }
                        else if (strVal.Contains(" REFERENCES "))
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if ((clsCommon.CompairString(clsCommon.myCstr(dr["COLUMN_NAME"]), key) == CompairStringResult.Equal) && (clsCommon.CompairString(clsCommon.myCstr(dr["KeyType"]), "FK") == CompairStringResult.Equal))
                                {
                                    isFound = true;
                                }
                            }
                            if (!isFound)
                            {
                                subString = strVal.Split(new string[] { " REFERENCES " }, StringSplitOptions.None);
                                try
                                {
                                    qry = "Alter table " + strTableName + " alter column " + key + " " + subString[0];
                                    clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                                }
                                catch (Exception)
                                {
                                }

                                try
                                {
                                    qry = "Alter table " + strTableName + " add FOREIGN KEY(" + key + ") REFERENCES " + subString[1] + " ON UPDATE CASCADE";
                                    clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                                }
                                catch (System.Exception ex)
                                {
                                    if (ex.Message.Contains("Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints"))
                                    {
                                        qry = "Alter table " + strTableName + " add FOREIGN KEY(" + key + ") REFERENCES " + subString[1];
                                        clsDBFuncationality.ExecuteNonQuery(qry, isRunOnLinkedServer);
                                    }
                                    else
                                    {
                                        throw new Exception(ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                qry = string.Empty;
                dt = null;
                subString = null;
                strVal = string.Empty;
            }
        }
        
        public static bool UpdateDataTable(Hashtable CollectinOfFields, string strTableName, OMInsertOrUpdate InsertOrUpdate, string strWhrCls)
        {
            return UpdateDataTable(CollectinOfFields, strTableName, InsertOrUpdate, strWhrCls, null);
        }

        public static bool UpdateDataTable(Hashtable CollectinOfFields, string strTableName, OMInsertOrUpdate InsertOrUpdate, string strWhrCls, SqlTransaction trans)
        {
            string FinalQry = string.Empty;
            string strCols = string.Empty;
            string strValues = string.Empty;
            string strUpdate = string.Empty;
            bool isUseComma = false;
            try
            {
                foreach (string key in CollectinOfFields.Keys)
                {
                    if (isUseComma)
                    {
                        strCols += ',';
                        strValues += ",";
                        strUpdate += ",";
                    }
                    strCols += key;
                    strValues += clsCommon.myCstr(CollectinOfFields[key]);
                    strUpdate += key + " = " + clsCommon.myCstr(CollectinOfFields[key]);
                    isUseComma = true;
                }

                if (InsertOrUpdate == OMInsertOrUpdate.Insert)
                {
                    FinalQry = "Insert into " + strTableName + " (" + strCols + ") Values (" + strValues + ")";
                }
                else if (InsertOrUpdate == OMInsertOrUpdate.Update)
                {
                    FinalQry = "update " + strTableName + " set " + strUpdate + " where 2=2 ";
                    if (clsCommon.myLen(strWhrCls) > 0)
                    {
                        FinalQry += " and " + strWhrCls;
                    }
                }
                clsDBFuncationality.ExecuteNonQuery(FinalQry, trans);
            }
            catch (Exception err)
            {
                if (err.Message.Contains("String or binary data would be truncated"))
                {
                    FinalQry = "select COLUMN_NAME,CHARACTER_MAXIMUM_LENGTH  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + strTableName + "' and CHARACTER_MAXIMUM_LENGTH is not null";
                    DataTable dt = clsDBFuncationality.GetDataTable(FinalQry, trans);

                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            dictionary.Add(clsCommon.myCstr(dr["COLUMN_NAME"]).ToUpper(), (int)clsCommon.myCdbl(dr["CHARACTER_MAXIMUM_LENGTH"]));
                        }
                    }
                    foreach (string key in CollectinOfFields.Keys)
                    {
                        if (dictionary.ContainsKey(key.ToUpper()))
                        {
                            string orgValue = clsCommon.myCstr(CollectinOfFields[key]);
                            orgValue = orgValue.Replace("''", "'");
                            if (clsCommon.myLen(orgValue) >= 2)
                            {
                                orgValue = orgValue.Substring(1, orgValue.Length - 2);

                            }
                            if (clsCommon.myLen(orgValue) > dictionary[key.ToUpper()])
                            {
                                throw new Exception("Table - " + strTableName + Environment.NewLine + "Columns - " + key + Environment.NewLine + "Value - " + orgValue + Environment.NewLine + "Value Length - " + clsCommon.myLen(orgValue) + " Characters" + Environment.NewLine + "DataBase Length - " + clsCommon.myCstr(dictionary[key.ToUpper()]) + " Characters");
                            }
                        }
                    }
                }
                throw new Exception(err.Message);
            }
            finally
            {
                FinalQry = null;
                strCols = null;
                strValues = null;
                strUpdate = null;
            }
            return true;
        }

        public static bool UpdateDataTableInSelectedDatabase(Hashtable CollectinOfFields, List<string> arrDBName, string strTableName, OMInsertOrUpdate InsertOrUpdate, string strWhrCls)
        {
            SqlTransaction trans = clsDBFuncationality.GetTransactin();
            try
            {
                if (UpdateDataTableInSelectedDatabase(CollectinOfFields, arrDBName, strTableName, InsertOrUpdate, strWhrCls, trans))
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw new Exception(err.Message);
            }
            finally
            {
                trans = null;
            }
            return true;
        }

        public static bool UpdateDataTableInSelectedDatabase(Hashtable CollectinOfFields, List<string> arrDBName, string strTableName, OMInsertOrUpdate InsertOrUpdate, string strWhrCls, SqlTransaction trans)
        {
            try
            {
                if ((arrDBName != null && arrDBName.Count > 0))
                {
                    foreach (string strDatabase in arrDBName)
                    {
                        if ((clsCommon.myLen(strDatabase) > 0))
                        {
                            string strNewTableName = strDatabase.Trim() + ".dbo." + strTableName.Trim();
                            UpdateDataTable(CollectinOfFields, strNewTableName, InsertOrUpdate, strWhrCls, trans);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                // db.Close();
            }
            return true;
        }

        public static string GetNxtSerialNo(string strTableName)
        {
            return GetNxtSerialNo(strTableName, null);
        }

        public static string GetNxtSerialNo(string strTableName, SqlTransaction trans)
        {
            string strRetVal = "";
            try
            {
                string qry = "Select dbo.getSno('" + strTableName + "')";
                strRetVal = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, trans));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return strRetVal;
        }

        public static void createIndexNew(string tblName, string fldName1)
        {
            createIndexNew(tblName, fldName1, "");
        }
      
        public static void createIndexNew(string tblName, string fldName1, string fldName2)
        {
            createIndexNew(tblName, fldName1, fldName2, "");
        }
       
        public static void createIndexNew(string tblName, string fldName1, string fldName2, string fldname3)
        {
            createIndexNew(tblName, fldName1, fldName2, fldname3, "");
        }
       
        public static void createIndexNew(string tblName, string fldName1, string fldName2, string fldname3, string fldname4)
        {
            createIndexNew(tblName, fldName1, fldName2, fldname3, fldname4, "");
        }
       
        public static void createIndexNew(string tblName, string fldName1, string fldName2, string fldname3, string fldname4, string fldname5)
        {
            string indxname = tblName.Trim() + "_" + fldName1.Trim();
            string strindexflds = "";
            strindexflds = "( " + fldName1.Trim();
            if (clsCommon.myLen(fldName2) > 0)
            {
                indxname = indxname + "_" + fldName2.Trim();
                strindexflds = strindexflds + "," + fldName2.Trim();
            }
            if (clsCommon.myLen(fldname3) > 0)
            {
                indxname = indxname + "_" + fldname3.Trim();
                strindexflds = strindexflds + "," + fldname3.Trim();
            }
            if (clsCommon.myLen(fldname4) > 0)
            {
                indxname = indxname + "_" + fldname4.Trim();
                strindexflds = strindexflds + "," + fldname4.Trim();
            }
            if (clsCommon.myLen(fldname5) > 0)
            {
                indxname = indxname + "_" + fldname5.Trim();
                strindexflds = strindexflds + "," + fldname5.Trim();
            }
            strindexflds = strindexflds + ")";
            string qryDrop = "Drop index " + tblName.Trim() + "." + indxname;
            string qryCreate = "Create index " + indxname + " on " + tblName + " " + strindexflds;
            try
            {
                clsCommon.ProgressBarUpdate("Verifying Index - " + indxname);
            }
            catch (System.Exception)
            {
            }
            try
            {
                clsDBFuncationality.ExecuteNonQuery(qryDrop);

            }
            catch
            {
            }
            finally
            {

                try
                {
                    clsDBFuncationality.ExecuteNonQuery(qryCreate);
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show("Unable to create index " + indxname + " on " + tblName + " " + strindexflds + Environment.NewLine + ex.Message);
                }
                finally
                {
                    qryCreate = null;
                    indxname = null;
                    strindexflds = null;
                    qryDrop = null;
                    qryCreate = null;
                }
            }
        }

        public static bool CreateStoreProcedure(string strProcedureName, string strProcdureBody)
        {
            string qry = string.Empty;
            try
            {
                try
                {
                    clsCommon.ProgressBarUpdate("Verifying Store Procedure - " + strProcedureName);
                }
                catch (System.Exception)
                {
                }
                qry = " IF EXISTS ( SELECT 1 FROM sys.objects WHERE type = 'P' AND name = '" + strProcedureName + "') drop PROCEDURE " + strProcedureName;
                clsDBFuncationality.ExecuteNonQuery(qry);

                qry = "create PROCEDURE  " + strProcedureName + " " + strProcdureBody;
                clsDBFuncationality.ExecuteNonQuery(qry);
            }
            catch (Exception err)
            {
                clsCommon.MyMessageBoxShow(err.Message, "Error in Store Procedure");
                return false;
            }
            finally
            {
                qry = string.Empty;
            }
            return true;
        }

        public static bool CreateSQLFunctioin(string strFunctionName, string strFunctionBody)
        {
            string qry = string.Empty;
            try
            {
                try
                {
                    clsCommon.ProgressBarUpdate("Verifying SQL Function - " + strFunctionName);
                }
                catch (System.Exception)
                {
                }
                qry = " IF EXISTS ( SELECT 1 FROM sys.objects WHERE type_desc LIKE '%FUNCTION%' and name = '" + strFunctionName + "') drop function " + strFunctionName;
                clsDBFuncationality.ExecuteNonQuery(qry);


                clsDBFuncationality.ExecuteNonQuery(strFunctionBody);
            }
            catch (Exception err)
            {
                clsCommon.MyMessageBoxShow(err.Message, "Error in SQL Function");
                return false;
            }
            finally
            {
                qry = string.Empty;
            }
            return true;
        }

        public static bool CreateSQLView(string strViewName, string strViewSelectQuery)
        {
            string qry = string.Empty;
            try
            {
                try
                {
                    clsCommon.ProgressBarUpdate("Verifying SQL View - " + strViewName);
                }
                catch (System.Exception)
                {
                }
                qry = " IF EXISTS ( select 1 FROM sys.views where name = '" + strViewName + "') drop view [" + strViewName + "]";
                clsDBFuncationality.ExecuteNonQuery(qry);

                qry = "CREATE VIEW [" + strViewName + "] AS " + strViewSelectQuery;
                clsDBFuncationality.ExecuteNonQuery(qry);
            }
            catch (Exception err)
            {
                clsCommon.MyMessageBoxShow(err.Message, "Error in SQL View");
                return false;
            }
            finally
            {
                qry = string.Empty;
            }
            return true;
        }

        public static bool SaveHistoryData(string strCurrenctUserCode, string strDocNoValue, string strTableName1, string strDocNoColumnForTable1, SqlTransaction trans)
        {
            return SaveHistoryData(strCurrenctUserCode, strDocNoValue, strTableName1, strDocNoColumnForTable1, "", "", trans);
        }

        public static bool SaveHistoryData(string strCurrenctUserCode, string strDocNoValue, string strTableName1, string strDocNoColumnForTable1, string strTableName2, string strDocNoColumnForTable2,  SqlTransaction trans)
        {
            return SaveHistoryData(strCurrenctUserCode, strDocNoValue, strTableName1, strDocNoColumnForTable1, strTableName2, strDocNoColumnForTable2, "", "", trans);
        }
        public static bool SaveHistoryData(string strCurrenctUserCode, string strDocNoValue, string strTableName1, string strDocNoColumnForTable1, string strTableName2, string strDocNoColumnForTable2, string strTableName3, string strDocNoColumnForTable3, SqlTransaction trans)
        {
            return SaveHistoryData(strCurrenctUserCode, strDocNoValue, strTableName1, strDocNoColumnForTable1, strTableName2, strDocNoColumnForTable2, strTableName3, strDocNoColumnForTable3, "", "", trans);
        }

        public static bool SaveHistoryData(string strCurrenctUserCode, string strDocNoValue, string strTableName1, string strDocNoColumnForTable1, string strTableName2, string strDocNoColumnForTable2, string strTableName3, string strDocNoColumnForTable3, string strTableName4, string strDocNoColumnForTable4, SqlTransaction trans)
        {
            strTableName1 = strTableName1.Trim();
            strTableName2 = strTableName2.Trim();
            strTableName3 = strTableName3.Trim();
            strTableName4 = strTableName4.Trim();

            string qry = "select max(" + clsCommon.HistTableColHistVersion + ") from " + strTableName1 + clsCommon.HistTablePostFix + " where " + strDocNoColumnForTable1 + "='" + strDocNoValue+"'";
            DataTable dt = clsDBFuncationality.GetDataTable(qry, trans);
            double ver = 1;
            DateTime dtCurrent = clsCommon.GETSERVERDATE(trans);
            string strColumn = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                ver = clsCommon.myCdbl(dt.Rows[0][0]) + 1;
            }
            if (clsCommon.myLen(strTableName1) > 0)
            {
                strColumn = GetTableColumnNameofTable(strTableName1, trans);
                qry = "INSERT INTO " + strTableName1 + clsCommon.HistTablePostFix + "(" + strColumn + "," + clsCommon.HistTableColHistBy + "," + clsCommon.HistTableColHistOn + "," + clsCommon.HistTableColHistVersion + ") SELECT " + strColumn + ",'" + strCurrenctUserCode + "','" + clsCommon.GetPrintDate(dtCurrent, "dd/MMM/yyyy hh:mm:ss tt") + "','" + clsCommon.myCstr(ver) + "' FROM " + strTableName1 + " WHERE " + strDocNoColumnForTable1 + "='" + strDocNoValue + "'";
                clsDBFuncationality.ExecuteNonQuery(qry, trans);
            }
            if (clsCommon.myLen(strTableName2) > 0)
            {
                strColumn = GetTableColumnNameofTable(strTableName2, trans);
                qry = "INSERT INTO " + strTableName2 + clsCommon.HistTablePostFix + "(" + strColumn + "," + clsCommon.HistTableColHistBy + "," + clsCommon.HistTableColHistOn + "," + clsCommon.HistTableColHistVersion + ") SELECT " + strColumn + ",'" + strCurrenctUserCode + "','" + clsCommon.GetPrintDate(dtCurrent, "dd/MMM/yyyy hh:mm:ss tt") + "','" + clsCommon.myCstr(ver) + "' FROM " + strTableName2 + " WHERE " + strDocNoColumnForTable2 + "='" + strDocNoValue + "'";
                clsDBFuncationality.ExecuteNonQuery(qry, trans);
            }
            if (clsCommon.myLen(strTableName3) > 0)
            {
                strColumn = GetTableColumnNameofTable(strTableName3, trans);
                qry = "INSERT INTO " + strTableName3 + clsCommon.HistTablePostFix + "(" + strColumn + "," + clsCommon.HistTableColHistBy + "," + clsCommon.HistTableColHistOn + "," + clsCommon.HistTableColHistVersion + ") SELECT " + strColumn + ",'" + strCurrenctUserCode + "','" + clsCommon.GetPrintDate(dtCurrent, "dd/MMM/yyyy hh:mm:ss tt") + "','" + clsCommon.myCstr(ver) + "' FROM " + strTableName3 + " WHERE " + strDocNoColumnForTable3 + "='" + strDocNoValue + "'";
                clsDBFuncationality.ExecuteNonQuery(qry, trans);
            }
            if (clsCommon.myLen(strTableName4) > 0)
            {
                strColumn = GetTableColumnNameofTable(strTableName4, trans);
                qry = "INSERT INTO " + strTableName4 + clsCommon.HistTablePostFix + "(" + strColumn + "," + clsCommon.HistTableColHistBy + "," + clsCommon.HistTableColHistOn + "," + clsCommon.HistTableColHistVersion + ") SELECT " + strColumn + ",'" + strCurrenctUserCode + "','" + clsCommon.GetPrintDate(dtCurrent, "dd/MMM/yyyy hh:mm:ss tt") + "','" + clsCommon.myCstr(ver) + "' FROM " + strTableName4 + " WHERE " + strDocNoColumnForTable4 + "='" + strDocNoValue + "'";
                clsDBFuncationality.ExecuteNonQuery(qry, trans);
            }
            return true;
        }

        public static string GetTableColumnNameofTable(string strTableName, SqlTransaction trans)
        {
            string qry = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + strTableName + "'";
            DataTable dt = clsDBFuncationality.GetDataTable(qry, trans);
            string strInvColumns = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                bool isFirstTime = true;
                foreach (DataRow dr in dt.Rows)
                {
                    if (!isFirstTime)
                    {
                        strInvColumns += ",";
                    }
                    strInvColumns += clsCommon.myCstr(dr["COLUMN_NAME"]);
                    isFirstTime = false;
                }
            }
            return strInvColumns;

        }

    }
}
