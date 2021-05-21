#include<SPI.h>  
int LED1 = 2;
int LED2 = 3;
int LED3 = 4;
int LED4 = 5;
int LED5 = 6;
int LED6 = 7;
int LED7 = 8;
int LED8 = 9;

char ledC = 0;

char check[15];
char mode = 0;
bool state = 0;

int reading;
float voltage;
float temp;
//SM1LM data data data data E
char commandfrommaster[10];
char dataLM[11] = "*A1LM0000#";
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
  if(commandfrommaster[0] == '*' && commandfrommaster[9] == '#')
  {
    strncpy(check, commandfrommaster + 1, 6);
    check[6] = '\0';
    if(strcmp(check, "A1LSWL") == 0)
    {
      ledC = commandfrommaster[7];
      mode = commandfrommaster[8];
      Serial.println(mode);
    }
  }
  if(mode == '1')
  {
    switch (ledC)
    {
      case '1':
        digitalWrite(LED1, HIGH);
        break;
      case '2':
        digitalWrite(LED2, HIGH);
        break;
      case '3':
        digitalWrite(LED3, HIGH);
        break;
      case '4':
        digitalWrite(LED4, HIGH);
        break;
      case '5':
        digitalWrite(LED5, HIGH);
        break;
      case '6':
        digitalWrite(LED6, HIGH);
        break;
      case '7':
        digitalWrite(LED7, HIGH);
        break;
      case '8':
        digitalWrite(LED8, HIGH);
        break;
    }
  }
  else
  {
    switch (ledC)
    {
      case '1':
        digitalWrite(LED1, LOW);
        break;
      case '2':
        digitalWrite(LED2, LOW);
        break;
      case '3':
        digitalWrite(LED3, LOW);
        break;
      case '4':
        digitalWrite(LED4, LOW);
        break;
      case '5':
        digitalWrite(LED5, LOW);
        break;
      case '6':
        digitalWrite(LED6, LOW);
        break;
      case '7':
        digitalWrite(LED7, LOW);
        break;
      case '8':
        digitalWrite(LED8, LOW);
        break;
    }
  }
}
void loop() {
  // put your main code here, to run repeatedly:
  delay(500);
}
