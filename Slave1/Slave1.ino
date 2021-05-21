#include<SPI.h>  
int LED1 = 2;
int LED2 = 3;
int LED3 = 4;
int LED4 = 5;
int LED5 = 6;
int LED6 = 7;
int LED7 = 8;
int LED8 = 9;
char check[15];
char mode = 0;
bool state = 0;

int reading;
float voltage;
float temp;
//SM1LM data data data data E
char commandfrommaster[10];
char dataLM[11] = "SM1LM0000E";
int sensorPin = A0;
void setup() {
  // put your setup code here, to run once:
  pinMode(MISO,OUTPUT);
  SPCR |= _BV(SPE);
  SPI.attachInterrupt();
  Serial.begin(115200);
}
ISR (SPI_STC_vect)
{
  reading = analogRead(sensorPin);
  voltage = reading * 5.0 / 1024.0;
  temp = voltage * 100.0;
  dataLM[5] = (int) temp / 10 + 48;
  dataLM[6] = (int) temp % 10 + 48;
  dataLM[7] = (int) (temp * 10) % 10 + 48;
  dataLM[8] = (int) (temp * 100) % 10 + 48;
  for(int i = 0; i < 10; i++)
  {
    commandfrommaster[i] = SPI.transfer(dataLM[i]);
  }  
  Serial.println(commandfrommaster);
  if(commandfrommaster[0] == 'S' && commandfrommaster[9] == 'E')
  {
    strncpy(check, commandfrommaster + 1, 7);
    check[7] = '\0';
    if(strcmp(check, "M1LEDMD") == 0)
    {
      mode = commandfrommaster[8];
      Serial.println(mode);
    }
  }
  if(mode == 'a')
  {
    digitalWrite(LED1, HIGH);
  }
  else if(mode == 'A')
  {
    digitalWrite(LED1, LOW);
  }
  else if(mode == 'b')
  {
    digitalWrite(LED2, HIGH);
  }
  else if(mode == 'B')
  {
    digitalWrite(LED2, LOW);
  }
  else if(mode == 'c')
  {
    digitalWrite(LED3, HIGH);
  }
  else if(mode == 'C')
  {
    digitalWrite(LED3, LOW);
  }
  else if(mode == 'd')
  {
    digitalWrite(LED4, HIGH);
  }
  else if(mode == 'D')
  {
    digitalWrite(LED4, LOW);
  }
  else if(mode == 'e')
  {
    digitalWrite(LED5, HIGH);
  }
  else if(mode == 'E')
  {
    digitalWrite(LED5, LOW);
  }

  else if(mode == 'f')
  {
    digitalWrite(LED6, HIGH);
  }
  else if(mode == 'F')
  {
    digitalWrite(LED6, LOW);
  }

   else if(mode == 'g')
  {
    digitalWrite(LED7, HIGH);
  }
  else if(mode == 'G')
  {
    digitalWrite(LED7, LOW);
  }

  else if(mode == 'h')
  {
    digitalWrite(LED8, HIGH);
  }
  else if(mode == 'H')
  {
    digitalWrite(LED8, LOW);
  }
}
void loop() {
  // put your main code here, to run repeatedly:
  delay(500);
}
