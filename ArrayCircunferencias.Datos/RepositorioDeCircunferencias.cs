using circunferencias.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCircunferencias.Datos
{
    public class RepositorioDeCircunferencias
    {
        private List<Circunferencia> ListaCircunferencias;
 private readonly  string _archivo= Environment.CurrentDirectory + "\\Circunferencia.txt";
    private readonly string _archivoCopia = Environment.CurrentDirectory + "\\Circunferencia.bak";

        public RepositorioDeCircunferencias(List<Circunferencia> listaCircunferencias)
        {
            ListaCircunferencias = new List<Circunferencia>();
        }
       
    
        public RepositorioDeCircunferencias()
        {
            ListaCircunferencias = new List<Circunferencia>();
            leerDatos();

        }

        public RepositorioDeCircunferencias(string archivo)
        {
            _archivo = archivo;
        }

        private void leerDatos()
        {
            if (File.Exists(_archivo))
            {
                        var lector = new StreamReader(_archivo);
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        Circunferencia circunferencia = ConstruirCircunferencia(lineaLeida);
                        ListaCircunferencias.Add(circunferencia);

                    }
                lector.Close();

            }

        }

        private Circunferencia ConstruirCircunferencia(string lineaLeida)
        {
          var campos=lineaLeida.Split('|');

            double radio = double.Parse(campos [0]);
            Circunferencia c = new Circunferencia(radio);
            return c;

        }

        public void agregar(Circunferencia circunferencia)
        {
          //  if (File.Exists(_archivo))
           // {

                using (var escritor = new StreamWriter(_archivo, true))
                {
                    string lineaEscribir = ConstruirLinea(circunferencia);

                    escritor.WriteLine(lineaEscribir);

                }
                ListaCircunferencias.Add(circunferencia);

         //    }
           

         }

        private string ConstruirLinea(Circunferencia circunferencia)
        {
            return$"{circunferencia.GetRadio}";



        }

        /// <summary>
        /// Metodo para informar la cantidad de datos del repo
        /// </summary>
        /// <returns></returns>

        public int GetCantidad(int? valorfiltro=null) 
        {

            if (valorfiltro!=null)
            {
                return ListaCircunferencias.Count(c => c.GetRadio >= valorfiltro);
            }



            return ListaCircunferencias.Count;
        }
        public void BorrarCircunferencia(Circunferencia circunferenciaBorrar) 
        {
            using (var lector = new StreamReader(_archivo)) 
            {
                using (var escritor = new StreamWriter(_archivoCopia)) 
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida=lector.ReadLine();
                        Circunferencia circunferenciaLeida = ConstruirCircunferencia(lineaLeida);
                        if (circunferenciaBorrar.GetRadio!=circunferenciaLeida.GetRadio)
                        {
                            escritor.WriteLine(lineaLeida);
                        }

                    }

                } 
            
            }

            File.Delete(_archivo);
            ListaCircunferencias.Remove(circunferenciaBorrar);
            File.Move(_archivoCopia,_archivo);




        }

        public List<Circunferencia> GetLista() { return ListaCircunferencias; }


        public void Editar(double radioAnterior, Circunferencia circunferenciaEditar)
        {
            using (var lector=new StreamReader(_archivo))
            {
                using (var escritor=new StreamWriter(_archivoCopia)) 
               {

                    while (!lector.EndOfStream)
                    {
                        string lineaLeida=lector.ReadLine();

                        Circunferencia circunferencia = ConstruirCircunferencia(lineaLeida);
                        if (radioAnterior!=circunferencia.GetRadio)
                        {
                            escritor.WriteLine(lineaLeida);
                        }
                        else
                        {
                            lineaLeida = ConstruirLinea (circunferenciaEditar);
                            escritor.WriteLine(lineaLeida);

                        }

                    }
                
                
               }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);

        }

        public List<Circunferencia> Filtrar(int intValor)
        {
            return ListaCircunferencias.Where(c=>c.GetRadio>=intValor).ToList();

            ///agregar el metodo para mostrar en la grilla
            ///MostrarDatosEnGrilla;
        }

        public List<Circunferencia> OrdenarAss()
        {
            return ListaCircunferencias.OrderBy(c=>c.GetRadio).ToList();
        }

        public List<Circunferencia> OrdenarDess()
        {
            return ListaCircunferencias.OrderByDescending(c=>c.GetRadio).ToList();  
        }

        public bool Existe(Circunferencia circunferencia)
        {
          ListaCircunferencias.Clear();
            leerDatos();
            foreach (var itemCircunferencia in ListaCircunferencias)
            {
                if (itemCircunferencia.GetRadio == circunferencia.GetRadio)
                {
                    return true;
                }
            }
            return false;


        }
    }

}
