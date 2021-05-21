#include <LiquidCrystal.h>
#include<SPI.h>  
char commandfrommaster[10];
char check[15];
String temp = "";
int mode = 15;
int LED1 = 5;
int LED2 = 6;

int level = 100;

char ledC = 0;
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
  if(commandfrommaster[0] == '*' && commandfrommaster[9] == '#')
  {
    strncpy(check, commandfrommaster + 1, 4);
    check[4] = '\0';
    if(strcmp(check, "A2LM") == 0)
    {
      temp = "Nhiet do:";
      temp += commandfrommaster[5];
      temp += commandfrommaster[6];
      temp += ".";
      temp += commandfrommaster[7];
      temp += commandfrommaster[8];
      temp += char(223);
      temp += "C";
      lcd.setCursor(0,1);
      lcd.print(temp);
      Serial.println(temp);
    }
    else
    {
      strncpy(check, commandfrommaster + 1, 6);
      check[6] = '\0';
      if(strcmp(check, "A2LSWL") == 0)
      {
        ledC = commandfrommaster[7] - 48;
        mode = commandfrommaster[8] - 48;
        if(mode == 1)
        {
          switch (ledC)
          {
            case 1:
              analogWrite(LED1, level);
              break;
            case 2:
              analogWrite(LED2, level);
              break;
          }
        }
        else
        {
          switch (ledC)
          {
            case 1:
              digitalWrite(LED1, LOW);
              break;
            case 2:
              digitalWrite(LED2, LOW);
              break;
          }
        }
      }
      else if(strcmp(check, "A2RFAT") == 0)
      {
        mode = commandfrommaster[8] - 48;
        if(mode != 0)
        {
          lcd.setCursor(0,0);
          lcd.print("Hello Hoang Lam");
        }
        else
        {
          lcd.setCursor(0,0);
          lcd.print("               ");
        }
      }
      else 
      {
        strncpy(check, commandfrommaster + 1, 5);
        check[5] = '\0';
        if(strcmp(check, "A2LPW") == 0)
        {
        level = (commandfrommaster[8] - 48) + (commandfrommaster[7] - 48)*10 + (commandfrommaster[6] - 48)*100;
        analogWrite(LED1, level);
        analogWrite(LED2, level);
        }
      }
      
    }
  }
}
void loop() {
  // put your main code here, to run repeatedly:

}
