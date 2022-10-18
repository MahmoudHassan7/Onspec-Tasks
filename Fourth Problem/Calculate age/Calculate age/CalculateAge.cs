using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_age
{
    class CalculateAge
    {
        public String Calculateage(DateTime birthday)
        {
            Age age = new Age();
            DateTime today = DateTime.Today;
            String result = "";
            if(validateDate(birthday))
            {
                age.monthes = today.Month - birthday.Month;
                age.years = today.Year-birthday.Year;
                if (age.monthes < 0)
                {
                    age.years--;
                    age.monthes += 12;
                }
                if (today.Day < birthday.Day) age.monthes--;
                age.days = (today - birthday.AddMonths((age.years * 12)+ age.monthes)).Days;
                result = "Your Current age is "+ getYears(age)+ " and "+ getMonthes(age)
                    +" and "+ getDays(age)+".";
            }
            else
            {
                result = "Your birthday not correct";
            }
            return result;
        }
        /// <summary>
        /// Check IF number of years Singular or plural
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        private String getYears(Age age)
        {
            string s;
            if (age.years > 1)
            {
                s = age.years.ToString() + " years";
            }
            else
            {
                s = age.years.ToString() + " year";
            }
            return s;
        }
        /// <summary>
        /// Check IF number of Monthes Singular or plural
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        private String getMonthes(Age age)
        {
            string s;
            if (age.monthes > 1)
            {
                s = age.monthes.ToString() + " monthes";
            }
            else
            {
                s = age.monthes.ToString() + " month";
            }
            return s;
        }
        /// <summary>
        /// Check IF number of Days Singular or plural
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        private String getDays(Age age)
        {
            string s;
            if(age.days>1)
            {
                s = age.days.ToString()+" days";
            }
            else
            {
                s = age.days.ToString() + " day";
            }
            return s;
        }
        /// <summary>
        /// This Function is to check That User Birthday not after today
        /// </summary>
        private bool validateDate(DateTime birthday)
        {
            DateTime now = timeToday();
            if (birthday > now) return false;
            return true;
        }
        /// <summary>
        /// Get Time of today
        /// </summary>
        /// <returns></returns>
        private DateTime timeToday()
        {
            return DateTime.Today;
        }
    }
}
