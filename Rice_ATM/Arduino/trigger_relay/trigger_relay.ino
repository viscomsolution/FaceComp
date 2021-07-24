#include <SPI.h>
const byte pinOK = A0;


String inputString = "";         // a String to hold incoming data
boolean isStringComplete = false;

byte state = 0;
byte lastState = 0;
  
void setup() {
  pinMode(pinOK, OUTPUT);
  
  Serial.begin(9600);
}

void loop() 
{
  if(isStringComplete)
  {                    
  	if (inputString == "O") 
  	{
  	  Serial.println("Got OK");              
  	  state = 21;
  	}  
  	else
  	{
  	  state = 0;    
  	}
  	inputString = "";
  	isStringComplete = false;
  }

  switch (state) 
  {          
    case 21:
      digitalWrite(pinOK, HIGH);
      digitalWrite(13, HIGH);
      delay(1000);
      digitalWrite(pinOK, LOW);
      digitalWrite(13, LOW);
      Serial.println("OK->Relay");
      state = 0;
      break;   

  }
  delay(100);
}
 
void serialEvent() 
{
  while (Serial.available()) 
  {
    // get the new byte:
    char c = (char)Serial.read();
    
    if (c != '\n') 
    {
      inputString += c;      
    }
    else
    {
      isStringComplete = true;
    }
  }
}
