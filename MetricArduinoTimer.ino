static int MetricSecond = 0;
static int MetricMinute = 0;
static int MetricHour = 0;
static int MetricDay = 1;
static int MetricMonth = 1;
static int MetricYear = 1;
static bool Mon36Counter = true;
static bool Milli = true;
static int Correction = 0;
static int TrueDay = 0;
static int TrueDays = 1;
static long MetricTotal = 0;
static String Outy;

void setup() {
  Serial.begin(115200);
}

void loop() {
  if (Milli) {
    Correction++;
    delay(1);
    Milli = false;
    } else Milli = true;

  if (Correction == 41) {
    Correction = 0;
    delay(6);
    }
    
    MetricTotal++;
    MetricSecond++;
    
    if (MetricSecond == 100) {
      MetricSecond = 0;
      MetricMinute++;
      }
      
    if (MetricMinute == 100) {
      MetricMinute = 0;
      MetricHour++;
      }
      
    if (MetricHour == 10) {
      MetricHour = 0;
      TrueDay++;
      TrueDays++;
      MetricDay++;
      }
      
    if (TrueDay == 36 && Mon36Counter == true) {
      TrueDay = 1;
      Mon36Counter = false;
      MetricMonth++;
      } else if (TrueDay == 37 && Mon36Counter == false) {
        TrueDay = 1;
        Mon36Counter = true;
        MetricMonth++;
        }
    
    if (TrueDays == 365) {
      TrueDays = 1;
      MetricMonth = 1;
      MetricYear++;
      }
    
    Outy = String(MetricYear) + '/' + String(MetricMonth) + '/' +
    String(MetricDay) + " @ " + String(MetricHour) +
    String(':') + MetricMinute + String(':') +
    String(MetricSecond);
    delay(863);
    Serial.println(Outy);
    }
