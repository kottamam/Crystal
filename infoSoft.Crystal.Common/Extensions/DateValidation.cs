using tv.Crystal.Common.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tv.Crystal.Common.Extensions
{
    public class DateValidation
    {
        string format = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        DateTime CurrDate;
        
        public string DateValidationFunction(string dateValue)
        {
            string option = string.Empty;
            string[] date = new string[50];
            try
            {
                foreach (char ch in dateValue)
                {
                    if (ch == '.')
                    {
                        option = ".";
                    }
                    else if (ch == ',')
                    {
                        option = ",";
                    }
                    else if (ch == '-')
                    {
                        option = "-";
                    }
                    else if (ch == '+')
                    {
                        option = "+";
                    }
                    else if (ch == '*')
                    {
                        option = "*";
                    }
                    else if (ch == '/')
                    {
                        option = "/";
                    }
                    else if (ch == ' ')
                    {
                        option = " ";
                    }
                }
                if (option == "")
                {
                    string s = dateValue + "/";
                    date = s.Split('/');
                }
                if (option == ".")
                {
                    date = dateValue.Split('.');
                }
                else if (option == ",")
                {
                    date = dateValue.Split(',');
                }
                else if (option == "-")
                {
                    date = dateValue.Split('-');
                }
                else if (option == "+")
                {
                    date = dateValue.Split('+');
                }
                else if (option == "*")
                {
                    date = dateValue.Split('*');
                }
                else if (option == "/")
                {
                    date = dateValue.Split('/');
                }
                else if (option == " ")
                {
                    date = dateValue.Split(' ');
                }
                if (date.Length == 1)
                {
                    string formatoption = SystemFormat();
                    if (formatoption == "M")
                    {
                        CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Month + " / " + date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                    }
                    else if (formatoption == "d")
                    {
                        CurrDate = DateTime.Parse(date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Month + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                    }
                    else if (formatoption == "y")
                    {
                        CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Year + " / " + ActiveUserSession.ServerDateTime.Date.Month + " / " + date[0].ToString());
                    }
                    dateValue = CurrDate.ToString("dd-MMM-yyyy");
                }
                else if (date.Length == 2)
                {
                    if (date[1].ToString() == "")
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Month + " / " + date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Month + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Year + " / " + ActiveUserSession.ServerDateTime.Date.Month + " / " + date[0].ToString());
                        }
                    }
                    else
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Year + " / " + date[1].ToString() + " / " + date[0].ToString());
                        } 
                    }
                    dateValue = CurrDate.ToString("dd-MMM-yyyy");
                }
                else if (date.Length == 3)
                {
                    if (date[2].ToString() == "")
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Year + " / " + date[1].ToString() + " / " + date[0].ToString());
                        }
                    }
                    else
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + date[2].ToString());
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + date[2].ToString());
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(date[2].ToString() + " / " + date[1].ToString() + " / " + date[0].ToString());
                        }
                    }
                    dateValue = CurrDate.ToString("dd-MMM-yyyy");
                }
                else
                {
                    dateValue = "";
                }
            }
            catch (Exception)
            {
                dateValue = "";
            }
            return dateValue;
        }

        /// <summary>
        /// Function for system format date
        /// </summary>
        /// <returns></returns>
        public string SystemFormat()
        {
            string formatoption = string.Empty;
            foreach (char ch in format)
            {
                if (ch == 'M')
                {
                    formatoption = "M";
                    break;
                }
                else if (ch == 'd')
                {
                    formatoption = "d";
                    break;
                }
                else if (ch == 'y')
                {
                    formatoption = "y";
                    break;
                }
            }
            return formatoption;
        }

        public string DateValidationFunction(string dateValue, out bool isValid)
        {
            string option = string.Empty;
            string[] date = new string[50];
            isValid = true;
            try
            {
                foreach (char ch in dateValue)
                {
                    if (ch == '.')
                    {
                        option = ".";
                    }
                    else if (ch == ',')
                    {
                        option = ",";
                    }
                    else if (ch == '-')
                    {
                        option = "-";
                    }
                    else if (ch == '+')
                    {
                        option = "+";
                    }
                    else if (ch == '*')
                    {
                        option = "*";
                    }
                    else if (ch == '/')
                    {
                        option = "/";
                    }
                    else if (ch == ' ')
                    {
                        option = " ";
                    }
                }
                if (option == "")
                {
                    string s = dateValue + "/";
                    date = s.Split('/');
                }
                if (option == ".")
                {
                    date = dateValue.Split('.');
                }
                else if (option == ",")
                {
                    date = dateValue.Split(',');
                }
                else if (option == "-")
                {
                    date = dateValue.Split('-');
                }
                else if (option == "+")
                {
                    date = dateValue.Split('+');
                }
                else if (option == "*")
                {
                    date = dateValue.Split('*');
                }
                else if (option == "/")
                {
                    date = dateValue.Split('/');
                }
                else if (option == " ")
                {
                    date = dateValue.Split(' ');
                }
                if (date.Length == 1)
                {
                    string formatoption = SystemFormat();
                    if (formatoption == "M")
                    {
                        CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Month + " / " + date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                    }
                    else if (formatoption == "d")
                    {
                        CurrDate = DateTime.Parse(date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Month + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                    }
                    else if (formatoption == "y")
                    {
                        CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Year + " / " + ActiveUserSession.ServerDateTime.Date.Month + " / " + date[0].ToString());
                    }
                    dateValue = CurrDate.ToString("dd-MMM-yyyy");
                }
                else if (date.Length == 2)
                {
                    if (date[1].ToString() == "")
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Month + " / " + date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Month + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Year + " / " + ActiveUserSession.ServerDateTime.Date.Month + " / " + date[0].ToString());
                        }
                    }
                    else
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Year + " / " + date[1].ToString() + " / " + date[0].ToString());
                        }
                    }
                    dateValue = CurrDate.ToString("dd-MMM-yyyy");
                }
                else if (date.Length == 3)
                {
                    if (date[2].ToString() == "")
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + ActiveUserSession.ServerDateTime.Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(ActiveUserSession.ServerDateTime.Date.Year + " / " + date[1].ToString() + " / " + date[0].ToString());
                        }
                    }
                    else
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + date[2].ToString());
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + date[2].ToString());
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(date[2].ToString() + " / " + date[1].ToString() + " / " + date[0].ToString());
                        }
                    }
                    dateValue = CurrDate.ToString("dd-MMM-yyyy");
                }
                else
                {
                    isValid = false;
                    dateValue = "";
                }
            }
            catch (Exception)
            {
                isValid = false;
                dateValue = "";
            }
            return dateValue;
        }

    }
}
