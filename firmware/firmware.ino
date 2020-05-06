// LRA motor driver pin
const int lra1_F = 2;
const int lra1_R = 4;
const int lra2_F = 7;
const int lra2_R = 8;
const int lra3_F = 10;
const int lra3_R = 11;
const int lra4_F = 12;
const int lra4_R = 13;

bool lraOn[4] = {false, false, false, false};
int lraFrequency[4] = {166, 166, 166, 166};   // lra 진동수 (Hz)
int lraPeriod[4] = {(int)(1000000.0/166), (int)(1000000.0/166), (int)(1000000.0/166), (int)(1000000.0/166) };   // lra 주기 (us)
int lraAmplitude[4] = {100, 100, 100, 100};   // 진동 파워 (%)

bool lraBurst[4] = {false, false, false, false};  // lra 잠깐 틀기
unsigned long lraBurstStartTime[4] = {0, 0, 0, 0};   // lra 잠깐 틀기 시작한 시간

int lraBumpRunMS[4] = {100, 100, 100, 100};  // bump 느낌의 진동에서 진동 시간(ms)
int lraBumpStopMS[4] = {0, 0, 0, 0};    // bump 느낌의 진동에서 쉬는 시간(ms)
unsigned long lraRunStartTime[4] = {0, 0, 0, 0};   // lra 틀기 시작한 시간

void setup() {
  pinMode (lra1_F, OUTPUT);
  pinMode (lra1_R, OUTPUT);
  pinMode (lra2_F, OUTPUT);
  pinMode (lra2_R, OUTPUT);
  pinMode (lra3_F, OUTPUT);
  pinMode (lra3_R, OUTPUT);
  pinMode (lra4_F, OUTPUT);
  pinMode (lra4_R, OUTPUT);

  
  /*
   * 
                serialPort1.WriteLine("1f250");
                serialPort1.WriteLine("2f250");
                serialPort1.WriteLine("3f150");
                serialPort1.WriteLine("4f150");

                serialPort1.WriteLine("2br060");
                serialPort1.WriteLine("2bs020");
                serialPort1.WriteLine("4br060");
                serialPort1.WriteLine("4bs020");



주파수, 파워, 모듈레이션
                
6V 넘게되는 드라이버

150Hz를 intensity를 반을 줄여서 

Voltage는 높이고.

250Hz가 파워가 낮아서 안느껴지는지, 높아도 안느껴지는지,

9

* 
   * 
   */
  Serial.begin(115200);
  while (! Serial);
}

void loop() {
  loopSerial();
  loopMotorOnOff();
  /*
  Serial.print("currenttime : ");
  Serial.print(currenttime);
  Serial.print("recordedtime : ");
  Serial.println(recordedtime);
  */

  

}


// Function: loopSerial
/*
 * Command(Serial input) convention
 * 1. LRA
 *  2v : tactor 2, run
 *  2s : tactor 2, stop
 *  2t : tactor 2, burst 500ms
 *  2f166: tactor 1, frequency 166 Hz
 *  2br050 : tactor 2, bump run 50ms
 *  2bs005 : tactor 2, bump stop 5ms
 */
void loopSerial()
{
  if(Serial.available() > 0)
  {
    String inString = Serial.readStringUntil('\n');
    char c1 = inString.charAt(0);
    char c2 = inString.charAt(1);
    char c3 = inString.charAt(2);
    char c4 = inString.charAt(3);
    char c5 = inString.charAt(4);
    char c6 = inString.charAt(5);

    if(c2 == 'v')
    {
      int motorNum = (int)c1 - 49;
      if(0 <= motorNum && motorNum < 4)
      {
        lraOn[motorNum] = true;
        lraRunStartTime[motorNum] = millis();
        /*
        Serial.print("LRA motor ");
        Serial.print(motorNum+1);
        Serial.println(" : ON");
        Serial.flush();
        */
      }
    }
    else if (c2 == 's')
    {
      int motorNum = (int)c1 - 49;
      if(0 <= motorNum && motorNum < 4)
      {
        lraOn[motorNum] = false;
        /*
        Serial.print("LRA motor ");
        Serial.print(motorNum+1);
        Serial.println(" : OFF");
        Serial.flush();
        */
      }
    }
    else if (c2 == 't')
    {
      int motorNum = (int)c1 - 49;
      if(0 <= motorNum && motorNum < 4)
      {
        lraOn[motorNum] = true;
        lraBurst[motorNum] = true;
        lraRunStartTime[motorNum] = millis();
        
        Serial.print("LRA motor ");
        Serial.print(motorNum+1);
        Serial.println(" Burst On");
        Serial.print("Up time: ");
        Serial.println((int)(((float)lraPeriod[motorNum] / (float)2)*((float)lraAmplitude[motorNum]/(float)100)));
        Serial.print("Down time: ");
        Serial.print((int)(((float)lraPeriod[motorNum] / (float)2)*(1 - ((float)lraAmplitude[motorNum]/(float)100))));
        Serial.flush();
        
      }
    }
    else if (c2 == 'f')
    {
      int motorNum = (int)c1 - 49;
      int freq = ((int)c3-48)*100+((int)c4-48)*10+((int)c5-48);
      int period = (int)((float)1000000 / (float)freq); // Unit : us, microseconds
      if(0 <= motorNum && motorNum < 4)
      {
        lraFrequency[motorNum] = freq;
        lraPeriod[motorNum] = period;
        /*
        Serial.print("LRA motor ");
        Serial.print(motorNum+1);
        Serial.print(" Frequency: ");
        Serial.println(freq);
        Serial.flush();
        */
      }
    }
    else if (c2 == 'a')
    {
      int motorNum = (int)c1 - 49;
      int amplitude = ((int)c3-48)*100+((int)c4-48)*10+((int)c5-48);
      if(0 <= motorNum && motorNum < 4)
      {
        lraAmplitude[motorNum] = amplitude;
        /*
        Serial.print("LRA motor ");
        Serial.print(motorNum+1);
        Serial.print(" Amplitude: ");
        Serial.println(amplitude);
        Serial.flush();
        */
      }
    }
    else if (c2 == 'b' && c3 == 'r')
    {
      int motorNum = (int)c1 - 49;
      int runMS = ((int)c4-48)*100+((int)c5-48)*10+((int)c6-48);
      if(0 <= motorNum && motorNum < 4)
      {
        lraBumpRunMS[motorNum] = runMS;
        /*
        Serial.print("LRA motor ");
        Serial.print(motorNum+1);
        Serial.print(" BumpRunMS: ");
        Serial.println(runMS);
        Serial.flush();
        */
      }
    }
    else if (c2 == 'b' && c3 == 's')
    {
      int motorNum = (int)c1 - 49;
      int stopMS = ((int)c4-48)*100+((int)c5-48)*10+((int)c6-48);
      if(0 <= motorNum && motorNum < 4)
      {
        lraBumpStopMS[motorNum] = stopMS;
        /*
        Serial.print("LRA motor ");
        Serial.print(motorNum+1);
        Serial.print(" BumpStopMS: ");
        Serial.println(stopMS);
        Serial.flush();
        */
      }
    }
  }
}

//void colorVib(int motorNum, int dur, int)


// Function: loopMotorOnOff
// Turn on LRA if true (166Hz full-powered)
void loopMotorOnOff ()
{
  int i;
  for(i=0;i<4;i++)
  {
    if(lraBurst[i])
    {
      unsigned long passedTime = millis() - lraRunStartTime[i];

      /*
      Serial.print("millis():  ");
      Serial.print(millis());
      Serial.print(", lraRunStartTime[i]: ");
      Serial.print(lraRunStartTime[i]);
      Serial.print(", passedTime: ");
      Serial.println(passedTime);
      */
      if(passedTime > 500)
      {
        lraOn[i] = false;
        lraBurst[i] = false;  
      }  
    }
    if(lraOn[i])
    {
      unsigned long passedTime = ((millis() - lraRunStartTime[i]) %(lraBumpRunMS[i] + lraBumpStopMS[i]));
      //Serial.print("passedTime: ");
      //Serial.print(passedTime);
      if(0 <= passedTime && passedTime < lraBumpRunMS[i])
      {
        lraOnOff(i);  
        //Serial.println(" - BumpRun");    
      }
      /*
      else
      {
        lraStop(i);
        Serial.println(" - BumpStop");    
      }
      */
        
    }  
  }
}

void turnOffAll()
{
  int i;
  for(i=0;i<4;i++)
  {
    lraOn[i] = false;
  }
}

void lraStop(int motorNum)
{
  if(motorNum == 0)
  {
    digitalWrite(lra1_F, LOW);
    digitalWrite(lra1_R, LOW);
  }
  if(motorNum == 1)
  {
    digitalWrite(lra2_F, LOW);
    digitalWrite(lra2_R, LOW);
  }
  if(motorNum == 2)
  {
    digitalWrite(lra3_F, LOW);
    digitalWrite(lra3_R, LOW);
  }
  if(motorNum == 3)
  {
    digitalWrite(lra4_F, LOW);
    digitalWrite(lra4_R, LOW);
  }  
}

void lraOnOff(int motorNum)
{
  //Forward
  if(motorNum == 0)
  {
    digitalWrite(lra1_F, HIGH);
    digitalWrite(lra1_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*((float)lraAmplitude[motorNum]/(float)100)));

    digitalWrite(lra1_F, LOW);
    digitalWrite(lra1_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*(1 - ((float)lraAmplitude[motorNum]/(float)100))));

    digitalWrite(lra1_F, LOW);
    digitalWrite(lra1_R, HIGH);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*((float)lraAmplitude[motorNum]/(float)100)));

    digitalWrite(lra1_F, LOW);
    digitalWrite(lra1_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*(1 - ((float)lraAmplitude[motorNum]/(float)100))));
  }
  else if (motorNum == 1)
  {
    digitalWrite(lra2_F, HIGH);
    digitalWrite(lra2_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*((float)lraAmplitude[motorNum]/(float)100)));

    digitalWrite(lra2_F, LOW);
    digitalWrite(lra2_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*(1 - ((float)lraAmplitude[motorNum]/(float)100))));

    digitalWrite(lra2_F, LOW);
    digitalWrite(lra2_R, HIGH);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*((float)lraAmplitude[motorNum]/(float)100)));

    digitalWrite(lra2_F, LOW);
    digitalWrite(lra2_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*(1 - ((float)lraAmplitude[motorNum]/(float)100))));
  }
  else if (motorNum == 2)
  {
    digitalWrite(lra3_F, HIGH);
    digitalWrite(lra3_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*((float)lraAmplitude[motorNum]/(float)100)));

    digitalWrite(lra3_F, LOW);
    digitalWrite(lra3_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*(1 - ((float)lraAmplitude[motorNum]/(float)100))));

    digitalWrite(lra3_F, LOW);
    digitalWrite(lra3_R, HIGH);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*((float)lraAmplitude[motorNum]/(float)100)));

    digitalWrite(lra3_F, LOW);
    digitalWrite(lra3_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*(1 - ((float)lraAmplitude[motorNum]/(float)100))));
  }
  else if (motorNum == 3)
  {
    digitalWrite(lra4_F, HIGH);
    digitalWrite(lra4_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*((float)lraAmplitude[motorNum]/(float)100)));

    digitalWrite(lra4_F, LOW);
    digitalWrite(lra4_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*(1 - ((float)lraAmplitude[motorNum]/(float)100))));

    digitalWrite(lra4_F, LOW);
    digitalWrite(lra4_R, HIGH);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*((float)lraAmplitude[motorNum]/(float)100)));

    digitalWrite(lra4_F, LOW);
    digitalWrite(lra4_R, LOW);
    delayMicroseconds((int)(((float)lraPeriod[motorNum] / (float)2)*(1 - ((float)lraAmplitude[motorNum]/(float)100))));
  }
  
}
