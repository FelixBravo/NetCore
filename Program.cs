using System;
using System.Collections.Generic;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            /* var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
                        ciudad: "Bogotá", pais: "Colombia"
                        );

            escuela.Cursos = new List<Curso>(){
                        new Curso(){ Nombre = "101" , Jornada = TiposJornada.Mañana},
                        new Curso() {Nombre = "201" , Jornada = TiposJornada.Mañana },
                        new Curso{Nombre = "301", Jornada = TiposJornada.Mañana}

            };

            escuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });

            var otrColeccion = new List<Curso>(){
                        new Curso(){ Nombre = "401" , Jornada = TiposJornada.Mañana},
                        new Curso() {Nombre = "501" , Jornada = TiposJornada.Mañana },
                        new Curso{Nombre = "501", Jornada = TiposJornada.Tarde}

            };
            Curso tmp = new Curso { Nombre = "101 - Vacacional", Jornada = TiposJornada.Noche };

            //otrColeccion.Clear();
            escuela.Cursos.AddRange(otrColeccion);
            escuela.Cursos.Add(tmp);
            ImpimirCursosEscuela(escuela);
            WriteLine($"Curso.Hash: {tmp.GetHashCode()}"); */
            /* escuela.Cursos = new Curso[]{
                        new Curso(){ Nombre = "101"},
                        new Curso() {Nombre = "201"},
                        new Curso{Nombre = "301"}
            };*/
            //escuela.Cursos.Remove(tmp);
            /* Predicate<Curso> miAlgoritmo = Predicado;
            escuela.Cursos.RemoveAll(miAlgoritmo);

            escuela.Cursos.RemoveAll(delegate (Curso cur){
                return cur.Nombre == "401";
            });

            escuela.Cursos.RemoveAll( (cur) => cur.Nombre == "501");

            WriteLine("====================");
            ImpimirCursosEscuela(escuela);*/

            var escuela = new EscuelaEngine();
            escuela.Inicializar();

            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA!!!");
            ImpimirCursosEscuela(escuela.Escuela);

            // var obj = new ObjetoEscuelaBase();
        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("CURSOS DE LA ESCUELA!!!");

            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}, Jornada: {curso.Jornada}");
                }
            }
        }


        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre  }, Id  {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre  }, Id  {arregloCursos[contador].UniqueId}");
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre {arregloCursos[i].Nombre  }, Id  {arregloCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
            }
        }
    }
}
