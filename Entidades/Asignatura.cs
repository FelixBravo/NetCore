using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Asignatura : ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluaciones { get; set; } = new List<Evaluación>();
    }
}