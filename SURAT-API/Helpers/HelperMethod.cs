using System;
using System.Globalization;

namespace SURAT_API.Helpers
{
    public class HelperMethod
    {
        public static DateTime? stringToDate(string strDate)
        {
            try
            {
                DateTime? result = DateTime.ParseExact(strDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static DateTime? stringToDate(string strDate, string strTime)
        {
            try
            {
                DateTime? result = DateTime.ParseExact(strDate + " " + strTime, "yyyyMMdd HHmm", CultureInfo.InvariantCulture);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static decimal DateToNumeric(DateTime _prmDate)
        {
            string _day = String.Empty, _month = String.Empty, _year = String.Empty;
            string _strDate = String.Empty;

            _day = _prmDate.ToString("dd").Trim();
            _month = _prmDate.ToString("MM").Trim();
            _year = _prmDate.ToString("yyyy").Trim();

            _strDate = _year + _month + _day;

            return Convert.ToDecimal(_strDate);
        }

        public static decimal DateToNumericNullable(DateTime? _prmDate)
        {
            string _day = String.Empty, _month = String.Empty, _year = String.Empty;
            string _strDate = String.Empty;

            _day = _prmDate?.ToString("dd").Trim();
            _month = _prmDate?.ToString("MM").Trim();
            _year = _prmDate?.ToString("yyyy").Trim();

            _strDate = _year + _month + _day;

            return Convert.ToDecimal(_strDate);
        }

        public static DateTime NumericToDateTime(decimal _prmDate, decimal _prmTime)
        {
            if (_prmDate != 0)
            {
                string strDate = Convert.ToString(_prmDate);

                int iYear = Convert.ToInt32(strDate.Substring(0, 4));
                int iMonth = Convert.ToInt32(strDate.Substring(4, 2));
                int iDay = Convert.ToInt32(strDate.Substring(6, 2));

                string strTime = "000000";
                if (_prmTime != 0)
                {
                    strTime = strTime + _prmTime.ToString();
                    strTime = strTime.Substring(strTime.Length - 6, 6);
                }

                int iHour = Convert.ToInt32(strTime.Substring(0, 2));
                int iMin = Convert.ToInt32(strTime.Substring(2, 2));
                int iSec = Convert.ToInt32(strTime.Substring(4, 2));

                DateTime _date;

                _date = new DateTime(iYear, iMonth, iDay, iHour, iMin, iSec);

                return _date;
            }
            else
            {
                return DateTime.Now;
            }
        }
        public static string NumericToDateString(decimal _prmDate)
        {
            if (_prmDate != 0)
            {
                string strDate = Convert.ToString(_prmDate);

                int iYear = Convert.ToInt32(strDate.Substring(0, 4));
                int iMonth = Convert.ToInt32(strDate.Substring(4, 2));
                int iDay = Convert.ToInt32(strDate.Substring(6, 2));

                DateTime _date;

                _date = new DateTime(iYear, iMonth, iDay);

                return _date.ToString("dd/MM/yyyy").Trim();
            }
            else
            {
                return String.Empty;
            }
        }

        public static DateTime NumericToDate(decimal _prmDate)
        {
            if (_prmDate != 0)
            {
                string strDate = Convert.ToString(_prmDate);

                int iYear = Convert.ToInt32(strDate.Substring(0, 4));
                int iMonth = Convert.ToInt32(strDate.Substring(4, 2));
                int iDay = Convert.ToInt32(strDate.Substring(6, 2));

                DateTime _date;

                _date = new DateTime(iYear, iMonth, iDay);

                return _date;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime NumericToDateAndTime(decimal _prmDate, decimal _prmTime)
        {
            if (_prmDate != 0 && _prmTime != 0)
            {
                DateTime _date;
                string strDate = Convert.ToString(_prmDate);

                int iYear = Convert.ToInt32(strDate.Substring(0, 4));
                int iMonth = Convert.ToInt32(strDate.Substring(4, 2));
                int iDay = Convert.ToInt32(strDate.Substring(6, 2));

                string strTime = string.Empty;

                strTime = "000000" + _prmTime.ToString();
                strTime = strTime.Substring(strTime.Length - 6, 6);

                int iHour = Convert.ToInt32(strTime.Substring(0, 2));
                int iMinute = Convert.ToInt32(strTime.Substring(2, 2));
                int iSecond = Convert.ToInt32(strTime.Substring(4, 2));

                _date = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond);

                return _date;
            }
            else if (_prmDate != 0 && _prmTime == 0)
            {
                DateTime _date;
                string strDate = Convert.ToString(_prmDate);

                int iYear = Convert.ToInt32(strDate.Substring(0, 4));
                int iMonth = Convert.ToInt32(strDate.Substring(4, 2));
                int iDay = Convert.ToInt32(strDate.Substring(6, 2));

                string strTime = string.Empty;

                strTime = "000000";
                strTime = strTime.Substring(strTime.Length - 6, 6);

                int iHour = Convert.ToInt32(strTime.Substring(0, 2));
                int iMinute = Convert.ToInt32(strTime.Substring(2, 2));
                int iSecond = Convert.ToInt32(strTime.Substring(4, 2));

                _date = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond);

                return _date;
            }
            else
            {
                return DateTime.Today;
            }
        }


        public static decimal TimeToNumeric(DateTime _prmDate)
        {
            string _hour = String.Empty, _minute = String.Empty, _second = String.Empty;
            string _strTime = String.Empty;

            _hour = _prmDate.ToString("HH").Trim();
            _minute = _prmDate.ToString("mm").Trim();
            _second = _prmDate.ToString("ss").Trim();

            _strTime = _hour + _minute + _second;

            return Convert.ToDecimal(_strTime);
        }

        public static string NumericToTimeString(decimal _prmTime)
        {
            string strTime = string.Empty;

            strTime = "000000" + _prmTime.ToString();
            strTime = strTime.Substring(strTime.Length - 6, 6);

            string strHour = strTime.Substring(0, 2);
            string strMinute = strTime.Substring(2, 2);
            string strSecond = strTime.Substring(4, 2);

            strTime = strHour + ":" + strMinute + ":" + strSecond;

            return strTime;
        }

        public static decimal NumericTimeGetHour(decimal _prmTime)
        {
            string strTime = string.Empty;

            strTime = "000000" + _prmTime.ToString();
            strTime = strTime.Substring(strTime.Length - 6, 6);

            string strHour = strTime.Substring(0, 2);

            strTime = strHour + "0000";

            return Convert.ToDecimal(strTime);
        }

        public static string DecimalToTimeString(decimal _prmTime)
        {
            string strTime = string.Empty;

            if (_prmTime != 0)
            {
                strTime = "000000" + _prmTime.ToString();
                strTime = strTime.Substring(strTime.Length - 6, 6);

                string strHour = strTime.Substring(0, 2);
                string strMinute = strTime.Substring(2, 2);

                strTime = strHour + ":" + strMinute;
            }

            return strTime;
        }

        public static DateTime JakartaTimeZone(DateTime _prmDate)
        {
            TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime estDt = TimeZoneInfo.ConvertTimeFromUtc(_prmDate, timeInfo);
            return estDt;
        }

    }
}