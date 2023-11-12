using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circunferencias.Utilidades
{
    public class Circunferencia:ICloneable 
    {
        private  double Radio ; // public double Radio { get; } esto es publico de poca seguridad
        private ColorRelleno colorRelleno;
       

        public ColorRelleno ColorRelleno
        {
            get { return colorRelleno; }
            set { colorRelleno=value;}
        }


        private TipoDeBorde tipoDeBorde;
        public TipoDeBorde TipoDeBorde
        {
            get { return tipoDeBorde; }
            set { tipoDeBorde = value; }
        }





        public Circunferencia()
        {
            
        }
        public Circunferencia(double radio)
        {
            if (radio > 0)
            {

                Radio = radio;
            }
            else { throw new ArgumentException("Medida del radio no valida"); }
        }
        public double GetRadio => Radio;
        private double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }

        private double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }

        public void SetRadio(double v)
        {
           this.Radio=v;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public double GetArea => CalcularArea();

        public double GetPerimetro => CalcularPerimetro();


    }
}


