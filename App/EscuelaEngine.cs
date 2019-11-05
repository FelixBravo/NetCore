using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
                    ciudad: "Bogotá", pais: "Colombia"
                    );

            CargarCursos();
            CargarAsignaturas();

            CargarEvaluaciones();

        }

        private void CargarEvaluacionesFinal(){
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación
                            {
                                Asignatura  = asignatura,
                                Nombre = $"{asignatura.Nombre} Evaluación #{i + 1}",
                                Nota = (float)(rnd.NextDouble() * 5),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                        
                    }
                    
                }

            }
        
        }

        private void CargarEvaluaciones()
        {
            List<Evaluación> ListEva = new List<Evaluación>();
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        string TituloEvaluacion = $"Evaluación de {asignatura.Nombre}";
                        string[] tiposEvaluacion = {"Escrita 1", "Escrita 2", "Oral 1", "Oral 2", "Final"};

                        var listaEvaluaciones = from tie in TituloEvaluacion
                                                from tye in tiposEvaluacion
                                                select new Evaluación { Nombre = $"{tie} : {tye}", Asignatura = asignatura};

                        foreach (var evaluaciones in listaEvaluaciones)
                        {
                            Random ran = new Random();
                            float cantRandom = (float)(ran.NextDouble() * 5.00);
                            evaluaciones.Alumno = alumno;
                            evaluaciones.Nota = cantRandom;
                            ListEva.Add(evaluaciones);
                        }
                        
                    }
                    asignatura.Evaluaciones.AddRange(ListEva);
                }

            }
        }

        private void GenerarNotasAlAzar(Asignatura asignatura)
        {

        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{ Nombre = "Matemáticas" },
                    new Asignatura{ Nombre = "Educación Física" },
                    new Asignatura{ Nombre = "Castellano" },
                    new Asignatura{ Nombre = "Ciencias Naturales" }
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alonso", "Franck", "Claudia", "Felix", "Marco", "Jose", "Camilo" };
            string[] apellido1 = { "Bravo", "Cornejo", "Jara", "Sanchez", "Vega", "Vergara", "Pinto" };
            string[] nombre2 = { "Andres", "Jorge", "Antonio", "Abel", "Simon", "Emiliano", "Pedro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy( (al) => al.UniqueId ).Take(cantidad).ToList();

        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                            new Curso(){ Nombre = "101" , Jornada = TiposJornada.Mañana},
                            new Curso() {Nombre = "201" , Jornada = TiposJornada.Mañana },
                            new Curso{ Nombre = "301", Jornada = TiposJornada.Mañana },
                            new Curso(){ Nombre = "401" , Jornada = TiposJornada.Tarde},
                            new Curso() {Nombre = "501" , Jornada = TiposJornada.Tarde }

                };

            Random rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                int CantRandom = rnd.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(CantRandom);
            }
        }
    }
}