using System;
using System.Windows.Forms;

namespace MetricClock // Revision 5. 2016-Mar-5 (Final)
{

    /*
	(A new concept but an old idea, A Metric Calendar Year)
    MetricClock : A Metric Time-Keeping Device.
    Copyright (C) 2016 Jawid Hassim

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
        */

    public partial class Form2 : Form
    {
        /*
        "In The Name Of God, Most Gracious, Most Merciful.
        By (the Token of) Time (through the ages), Verily Man is in loss..."

        The most important thing you must know about this is there is no such thing as an
        "Absolute" Metric Second. The closest I can break it down: 864 milliseconds, 573 micro-
        seconds, 269 nanoseconds, 917 picoseconds, 808 femtoseconds and 200-something attoseconds.

        For more on the figures see the 'Revision2.OriginalCode' file to understand how we got to here...
        There is no 'Revision1.OriginalCode' file because it was a simple 864ms counter, not worth "saving." 

        This code in essence stems from the empirical presumption ;) that a year is 365.24218 days and there
        are 86400.000 seconds in a day, which there probably aren't.
        
        I hope you'll appreciate the care given to this project and please do contribute to it!
        -Jawid Hassim
        */

        static Timer timer1;
        static DateTime DT;
        static bool Flag = false;
        static string MetricWeek;
        static int MetricSecond;
        static int MetricMinute;
        static int MetricHour;
        static int MetricDay;
        static int TrueDay = 1;
        static int TrueDays = 1;
        static int MetricMonth;
        static int MetricYear;
        static bool Mon36Counter = true;
        static bool Milli = true;
        static int Correction = 0;
        static string DayString;

        static readonly System.Collections.Generic.Dictionary<int, string> MetricMonths = new System.Collections.Generic.Dictionary<int, string>()
        {
            { 1, "Pascal" },
            { 2, "Archimedes" },
            { 3, "Ramanujan" },
            { 4, "Agnesi" },
            { 5, "Khwarizmi" },
            { 6, "Einstein" },
            { 7, "Pythagoras" },
            { 8, "Fibonacci" },
            { 9, "Leibniz" },
            { 10, "Jazari" }
        };

        public Form2()
        {
            InitializeComponent();
            Calculate();
        }

        void Calculate()
        {
            if (timer1 != null)
                timer1.Stop();

            MetricYear = dateTimePicker1.Value.Year - 1753;
            decimal LeapYears;

            if (MetricYear >= 4)
                LeapYears = MetricYear / 4;
            else LeapYears = 0;
            decimal NormalYears = MetricYear - LeapYears;
            decimal NormalDays = NormalYears * 365;
            decimal LeapDays = LeapYears * 366;
            decimal TotalDays = LeapDays + NormalDays;
            decimal TotalPreciseDays = TotalDays / (decimal)1.000663506849315; //MetricSeconds Multiplier
            decimal ExactYears = TotalPreciseDays / 365;
            MetricYear = (int)ExactYears;

            decimal Working = (TotalDays - TotalPreciseDays) * 1000;
            int NegDays = 0;
            int Hours = 0;
            int Minutes = 0;
            int Seconds = 0;
            if (Working >= 86400000)
            {
                decimal Daysecs = Working / 86400000; //Daysecs = Day Sections, not Dayseconds
                NegDays = (int)Daysecs;
                Working = Working - (NegDays * 86400000);
            }

            if (Working >= 3600000)
            {
                decimal Hoursecs = Working / 3600000;
                Hours = (int)Hoursecs;
                Working = Working - (Hours * 3600000);
            }

            if (Working >= 60000)
            {
                decimal Minsecs = Working / 60000;
                Minutes = (int)Minsecs;
                Working = Working - (Minutes * 60000);
            }

            if (Working >= 1000)
            {
                decimal Secsecs = Working / 1000;
                Seconds = (int)Secsecs;
                Working = Working - (Seconds * 1000);
            }

            MetricYear++; //Comment this to make Zero-Based.
            DT = dateTimePicker1.Value;

            DT = DT.AddMilliseconds((double)Working * -1);
            DT = DT.AddSeconds(Seconds * -1);
            DT = DT.AddMinutes(Minutes * -1);
            DT = DT.AddHours(Hours * -1);
            DT = DT.AddDays(NegDays * -1);

            MetricWeek = DT.DayOfWeek.ToString();

            int Days = DT.Day + (int)LeapYears;
            int OneMinusMonth = DT.Month - 1;

            while (OneMinusMonth != 0)
            {
                Days += DateTime.DaysInMonth(DT.Year, OneMinusMonth);
                OneMinusMonth--;
            }

            if (Days > 365)
            {
                int ExtraYears = Days / 365;
                MetricYear += ExtraYears;

                ExtraYears = 365 * ExtraYears;
                Days = Days - ExtraYears;
            }

            if (Days <= 36)
            {
                MetricMonth = 1;
                MetricDay = Days;
            }
            else if (Days <= 73)
            {
                MetricMonth = 2;
                MetricDay = Days - 36;
            }
            else if (Days <= 109)
            {
                MetricMonth = 3;
                MetricDay = Days - 73;
            }
            else if (Days <= 146)
            {
                MetricMonth = 4;
                MetricDay = Days - 109;
            }
            else if (Days <= 182)
            {
                MetricMonth = 5;
                MetricDay = Days - 146;
            }
            else if (Days <= 219)
            {
                MetricMonth = 6;
                MetricDay = Days - 182;
            }
            else if (Days <= 255)
            {
                MetricMonth = 7;
                MetricDay = Days - 219;
            }
            else if (Days <= 292)
            {
                MetricMonth = 8;
                MetricDay = Days - 255;
            }
            else if (Days <= 328)
            {
                MetricMonth = 9;
                MetricDay = Days - 292;
            }
            else
            {
                MetricMonth = 10;
                MetricDay = Days - 328;
            }

            //MetricDay--; //Uncomment this to make Zero-Based.
            //MetricMonth--; //Uncomment this to make Zero-Based.

            SDate.Text = MetricYear + "/" + MetricMonth + "/" + MetricDay + " (Y/M/D)";
            DayString = MetricDay.ToString();

            int SecMins = DT.Minute * 60;
            int SecHors = (DT.Hour * 60) * 60;
            int TotalSeconds = SecHors + SecMins;
            decimal MetricSeconds = TotalSeconds * (decimal)1.156639968865873; // 1000ms / 864.5732699178082

            decimal tDec = MetricSeconds / 100;
            if (tDec > 99)
            {
                MetricHour = (int)tDec / 100;
                MetricMinute = (int)tDec - (MetricHour * 100);
            }
            else MetricMinute = (int)tDec;

            MetricSecond += Convert.ToInt32((decimal)1.156639968865873 * DT.Second);

            if (DT.Millisecond > 864)
                MetricSecond++;

            if (MetricSecond < 100)
                Sec.Value = MetricSecond;
            else
            {
                MetricSecond = 0;
                MetricMinute++;
            }

            if (MetricMinute < 100)
                Min.Value = MetricMinute;
            else
            {
                MetricMinute = 0;
                MetricHour++;
            }

            if (MetricHour < 10)
                Hor.Value = MetricHour;
            else
            {
                MetricHour = 0;
                MetricDay++;
            }

            if (DayString.EndsWith("1"))
                LDateTime.Text = MetricWeek + ", The " + MetricDay + "st Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else if (DayString.EndsWith("2"))
                LDateTime.Text = MetricWeek + ", The " + MetricDay + "nd Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else if (DayString.EndsWith("3"))
                LDateTime.Text = MetricWeek + ", The " + MetricDay + "rd Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else LDateTime.Text = MetricWeek + ", The " + MetricDay + "th Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;

            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 864;
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (Milli)
            {
                Correction++;
                System.Threading.Thread.Sleep(1);
                Milli = false;
            }
            else
            {
                Milli = true;
                if (Correction >= 41)
                {
                    Correction = 0;
                    System.Threading.Thread.Sleep(6);
                }
            }

            MetricSecond++;

            if (MetricSecond == 100)
            {
                MetricSecond = 0;
                Sec.Value = 0;
                MetricMinute++;
                if (MetricMinute != 100)
                    Min.Value = MetricMinute;
            }

            Sec.Value = MetricSecond;

            if (MetricMinute == 100)
            {
                MetricMinute = 0;
                Min.Value = 0;
                MetricHour++;
                if (MetricHour != 10)
                    Hor.Value = MetricHour;
            }

            if (MetricHour == 10)
            {
                MetricHour = 0;
                Hor.Value = 0;
                TrueDay++;
                TrueDays++;
                MetricDay++;
                DayString = MetricDay.ToString();

                SDate.Text = MetricYear + "/" + MetricMonth + "/" + MetricDay + " (Y/M/D)";
                Flag = true;
            }

            if (TrueDay > 36 && Mon36Counter == true)
            {
                TrueDay = 1;
                Mon36Counter = false;
                MetricMonth++;
            }
            else if (TrueDay > 37 && Mon36Counter == false)
            {
                TrueDay = 1;
                Mon36Counter = true;
                MetricMonth++;
            }

            if (TrueDays > 365)
            {
                TrueDays = 1;
                MetricMonth = 0;
                MetricYear++;
            }

            if (DayString.EndsWith("1"))
                LDateTime.Text = MetricWeek + ", The " + MetricDay + "st Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else if (DayString.EndsWith("2"))
                LDateTime.Text = MetricWeek + ", The " + MetricDay + "nd Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else if (DayString.EndsWith("3"))
                LDateTime.Text = MetricWeek + ", The " + MetricDay + "rd Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else LDateTime.Text = MetricWeek + ", The " + MetricDay + "th Of " +
                   MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;

            if (Flag)
                dateTimePicker1.Value = DateTime.Now.AddDays(1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (Flag)
                Flag = false;
            else Calculate();
        }

        private void LDateTime_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(LDateTime.Text);
        }

        private void Hor_ValueChanged(object sender, EventArgs e)
        {
            MetricHour = (int)Hor.Value;
        }

        private void Min_ValueChanged(object sender, EventArgs e)
        {
            MetricMinute = (int)Min.Value;
        }

        private void Sec_ValueChanged(object sender, EventArgs e)
        {
            MetricSecond = (int)Sec.Value;
        }
    }
}
