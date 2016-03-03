using System;
using System.Windows.Forms;

namespace MetricClock // Revision 4. 2016-Mar-3 (Final)
{

    /*
	(A new concept but an old idea, A Metric Calendar Year.)
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

        For more on the figures see the 'Revision3.OriginalCode' file to understand how we got to here...
        There is no 'Revision1.OriginalCode' file because it was a simple 864ms counter, not worth "saving." 

        I hope you'll appreciate the care given to this project and please do contribute to it!
        -Jawid Hassim
        */

        static Timer timer1;
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

            MetricYear = dateTimePicker1.Value.Year - 1753 + 1;
            MetricWeek = dateTimePicker1.Value.DayOfWeek.ToString();

            decimal Leaps = MetricYear / (decimal)4.128994750808973;

            if (Leaps >= 365)
            {
                int ExtraYears = Convert.ToInt32(Leaps) / 365;
                MetricYear += ExtraYears;
            }

            int OneMinusMonth = dateTimePicker1.Value.Month - 1;
            int Days = dateTimePicker1.Value.Day + Convert.ToInt32(Leaps);

            while (OneMinusMonth != 0)
            {
                Days += DateTime.DaysInMonth(dateTimePicker1.Value.Year, OneMinusMonth);
                OneMinusMonth--;
            }

            if (Days >= 365) //Not sure it will overflow but lets be sure!
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

            MetricDay++;
            string MonthName = MetricMonths[MetricMonth];

            SDate.Text = MetricYear + "/" + MetricMonth + "/" + MetricDay + " (Y/M/D)";
            if (MetricDay == 1)
                LDateTime.Text = dateTimePicker1.Value.DayOfWeek.ToString() + ", The " + MetricDay + "st Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else if (MetricDay == 2)
                LDateTime.Text = dateTimePicker1.Value.DayOfWeek.ToString() + ", The " + MetricDay + "nd Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else if (MetricDay == 3)
                LDateTime.Text = dateTimePicker1.Value.DayOfWeek.ToString() + ", The " + MetricDay + "rd Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else LDateTime.Text = dateTimePicker1.Value.DayOfWeek.ToString() + ", The " + MetricDay + "th Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;

            int SecMins = DateTime.Now.Minute * 60;
            int SecHors = (DateTime.Now.Hour * 60) * 60;
            int Seconds = SecHors + SecMins;
            decimal MetricSeconds = Seconds * (decimal)1.156639968865873; // 1000ms / 864.5732699178082

            decimal tDec = MetricSeconds / 100;
            if (tDec > 99)
            {
                MetricHour = (int)tDec / 100;
                MetricMinute = (int)tDec - (MetricHour * 100);
            }
            else MetricMinute = (int)tDec;

            Min.Value = MetricMinute;
            Hor.Value = MetricHour;
            MetricSecond = Convert.ToInt32((decimal)1.156639968865873 * DateTime.Now.Second);

            if (DateTime.Now.Millisecond > 864)
                MetricSecond++;

            Sec.Value = MetricSecond;

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
            else Milli = true;

            if (Correction == 41)
            {
                Correction = 0;
                System.Threading.Thread.Sleep(6);
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
                dateTimePicker1.Value = DateTime.Now.AddDays(1);
                MetricHour = 0;
                Hor.Value = 0;
                TrueDay++;
                TrueDays++;
                MetricDay++;

                SDate.Text = MetricYear + "/" + MetricMonth + "/" + MetricDay + " (Y/M/D)";
            }

            if (TrueDay == 36 && Mon36Counter == true)
            {
                TrueDay = 1;
                Mon36Counter = false;
                MetricMonth++;
            }
            else if (TrueDay == 37 && Mon36Counter == false)
            {
                TrueDay = 0;
                Mon36Counter = true;
                MetricMonth++;
            }

            if (TrueDays == 365)
            {
                TrueDays = 1;
                MetricMonth = 0;
                MetricYear++;
            }

            if (MetricDay == 1)
                LDateTime.Text = dateTimePicker1.Value.DayOfWeek.ToString() + ", The " + MetricDay + "st Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else if (MetricDay == 2)
                LDateTime.Text = dateTimePicker1.Value.DayOfWeek.ToString() + ", The " + MetricDay + "nd Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else if (MetricDay == 3)
                LDateTime.Text = dateTimePicker1.Value.DayOfWeek.ToString() + ", The " + MetricDay + "rd Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
            else LDateTime.Text = dateTimePicker1.Value.DayOfWeek.ToString() + ", The " + MetricDay + "th Of " +
                    MetricMonths[MetricMonth] + " " + MetricYear + " @ " + MetricHour + ":" + MetricMinute + ":" + MetricSecond;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
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
