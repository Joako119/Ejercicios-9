using circunferencias.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios9POOyListas
{
    internal class Program 
    { 
    static void Main(string[] args)
        {
         
            List<Circunferencia> lista = new List<Circunferencia>();
            lista.Add(new Circunferencia(2));
            lista.Add(new Circunferencia(12));
            lista.Add(new Circunferencia(20));
            Console.WriteLine(lista.Count);
            foreach (var item in lista) 
            {
                Console.WriteLine(item.GetArea);
                Console.WriteLine(item.GetPerimetro);
                
            }

            var CircunferenciaEditada = lista[1];
            CircunferenciaEditada.SetRadio(123);
            foreach (var item in lista)
            {
                Console.WriteLine(item.GetArea);
            }
            lista.RemoveAt(1);
            Console.WriteLine(lista.Count);
        }

    }
            
}
