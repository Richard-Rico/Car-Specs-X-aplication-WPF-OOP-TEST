using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutoOlio2021
{
    public class Car
    {
        //prop (tab tab) trae el objeto publico
        private int maxSpeed; //Tämä on kenttä (field), eikä ominaisuus
        public int MaxSpeed   //Tämä on ominaisuus (Property)
        {   
            get 
            {
                return maxSpeed; 
            }

            set 
            {
                if((value > 0 ) && (value <= 400)) 
                {
                    maxSpeed = value;
                }
                else 
                {
                    maxSpeed = 0;
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Color { get; set; }
        public Boolean Running { get; set; }
        public string Model { get; set; }

        private int horsePower;
        public int HorsePower 
        {
            get 
            {
                return horsePower;
            }
            set 
            {
                if ((value > 0) && (value <= 1800))
                {
                    horsePower = value;
                }
                else
                {
                    horsePower = 0;
                    throw new ArgumentOutOfRangeException();
                }
            }
        } 
        public string TransMission { get; set; }
        public string EngineType { get; set; }

        public int CurrentSpeed { get; set; } //accelerate,Brake


        public void StarEngine() //Tämä on metodi
        {
            Running = true;
        }

        public void StopEngine() 
        {
            Running = false;
        }

        public void Accelerate()
        {
            CurrentSpeed++;
        }

        public void Brake() 
        {
            CurrentSpeed--;
        }
    }
}
