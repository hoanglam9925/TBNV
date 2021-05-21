#include <LiquidCrystal.h>
#include<SPI.h>  
char commandfrommaster[10];
char check[15];
String temp = "";
int mode = 15;
int LED1 = 5;
int LED2 = 6;
LiquidCrystal lcd(9,8,7,4,3,2);
void setup() {
  // put your setup code here, to run once:
  lcd.begin(16, 2);
  Serial.begin(115200);
  pinMode(LED1,OUTPUT);
  pinMode(MISO,OUTPUT);
  SPCR |= _BV(SPE);
  SPI.attachInterrupt();
}
ISR (SPI_STC_vect)
{
  for(int i = 0; i < 10; i++)
  {
    commandfrommaster[i] = SPI.transfer(' ');
  }
  Serial.println(commandfrommaster);
  if(commandfrommaster[0] == 'S' && commandfrommaster[9] == 'E')
  {
    strncpy(check, commandfrommaster + 1, 4);
    check[4] = '\0';
    if(strcmp(check, "M1LM") == 0)
    {
      temp = "Nhiet do:";
      temp += commandfrommaster[5];
      temp += commandfrommaster[6];
      temp += ".";
      temp += commandfrommaster[7];
      temp += commandfrommaster[8];
      temp += char(223);
      temp += "C";
      lcd.setCursor(0,0);
      lcd.print(temp);
      Serial.println(temp);
    }
    else
    {
      strncpy(check, commandfrommaster + 1, 7);
      check[7] = '\0';
      if(strcmp(check, "M2LEDMD") == 0)
      {
        mode = commandfrommaster[8] - 48;
        if(mode == 1)
        {
          digitalWrite(LED1, HIGH);
          digitalWrite(LED2, HIGH); 
        }
        else if(mode == 2)
        {
          digitalWrite(LED1, LOW);
          digitalWrite(LED2, LOW);
        }
      }
      else if(strcmp(check, "M2LEDPW") == 0)
      {
        mode = commandfrommaster[8] - 48;
        analogWrite(LED1, map(mode,0,9,0,255));
        analogWrite(LED2, map(mode,0,9,0,255));
      }
    }
  }
}
void loop() {
  // put your main code here, to run repeatedly:

}
