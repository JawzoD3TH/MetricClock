using System;
using System.Windows.Forms;

namespace MetricClock // Revision 3. 2016-Mar-2
{
    public partial class Form1 : Form
    {
        /*
        "In The Name Of God, Most Gracious, Most Merciful.
        By (the Token of) Time (through the ages), Verily Man is in loss..."

        The most important thing you must know about this is there is no such thing as an
        "Absolute" Metric Second. The closest I can break it down: 864 milliseconds, 573 micro-
        seconds, 269 nanoseconds, 917 picoseconds, 808 femtoseconds and 200-something attoseconds.

        That being said, Revision 3 is far more accurate "real Metric Time." The inaccuracies will
        be imperceivable for many years to come! For more on the figures see the 'Revision2.OriginalCode'
        file for how we got to here, yes mistakes were made but think of this revision as the engine.

        To deal with the error margin which sat at about 147 microseconds every 2 cycles. How we achieve that
        was simple instead of fixing differences somewhere down the line, the first cycle is 865ms we lose 426
        microseconds, the second cycle is 864ms in which we gain 573 microseconds. thus two cycles is 1729ms and
        we can then choose to correct the 'extra time' by delaying 6ms (6.008133260256) every 82 cycles.

        Revision 4 will add features.
        */

        static int MetricSecond = 0;
        static int MetricMinute = 0;
        static int MetricHour = 0;
        static int MetricDay = 0;
        static int MetricWeek = 0;
        static int MetricMonth = 0;
        static int MetricYear = 0;

        /*
        As for months, there are 10 months instead of 12 with a caveat...
        The 1st,3rd,5th,7th,9th months are 36 days.
        The 2nd,4th,6th,8th,10th months are 37 days.

        These months are:
        0 - Pascal
        1 - Archimedes
        2 - Ramanujan
        3 - Agnesi
        4 - Khwarizmi
        5 - Einstein
        6 - Pythagoras
        7 - Fibonacci
        8 - Leibniz
        9 - Jazari

        Relax.
        :P   These are just recommendations, also whether zero-based or 1, I personally
             tend towards the former, it's The Metric System we're talking about after all.
        */

        static bool Mon36Counter = true;
        static bool Milli = true;
        static int Correction = 0;
        static int TrueDay = 0;
        static int TrueDays = 1;

        static long MetricTotal = 0; //Don't trust this one! It's "Shifty" ;)

        public Form1()
        {
            InitializeComponent();
        }

        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 864;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
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

            MetricTotal++;
            MetricSecond++;
            Tot.Text = MetricTotal.ToString();
            Sec.Text = MetricSecond.ToString();

            if (MetricSecond == 100)
            {
                MetricSecond = 0;
                Sec.Text = "0";
                MetricMinute++;
                Min.Text = MetricMinute.ToString();
            }

            if (MetricMinute == 100)
            {
                MetricMinute = 0;
                Min.Text = "0";
                MetricHour++;
                Hor.Text = MetricHour.ToString();
            }

            if (MetricHour == 10)
            {
                MetricHour = 0;
                Hor.Text = "0";
                TrueDay++;
                TrueDays++;
                MetricDay++;
                Day.Text = MetricDay.ToString();
            }

            if (MetricDay == 7)
            {
                MetricDay = 0;
                Day.Text = "0";
                MetricWeek++;
                Wek.Text = MetricWeek.ToString();
            }

            if (TrueDay == 36 && Mon36Counter == true)
            {
                TrueDay = 0;
                Mon36Counter = false;
                MetricMonth++;
                Mon.Text = MetricMonth.ToString();
            }
            else if (TrueDay == 37 && Mon36Counter == false)
            {
                TrueDay = 0;
                Mon36Counter = true;
                MetricMonth++;
                Mon.Text = MetricMonth.ToString();
            }

            if (TrueDays == 365)
            {
                TrueDays = 1;
                MetricWeek = 0;
                Wek.Text = "0";
                MetricMonth = 0;
                Mon.Text = "0";
                MetricYear++;
                Yr.Text = MetricYear.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            InitTimer();
        }
    }
}
