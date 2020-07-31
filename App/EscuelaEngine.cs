using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi", 1999, TiposEscuela.Primaria,
                                    Pais: "Colombia", ciudad: "Bogotá"
                                );
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            Random rnd = new Random();
            foreach (Curso curso in Escuela.Cursos)
            {
                List<Evaluaciones> EvaluacionesLista = new List<Evaluaciones>();
                foreach (Alumno al in curso.Alumnos)
                {
                
                    foreach (Asignatura asign in curso.Asignaturas)
                    {
                        for (int j = 1; j < 6; j++)
                        {
                            float nota = (float)(rnd.Next(0, 5) + rnd.NextDouble());
                            if (nota > 5)
                            {
                                nota = nota - 1;
                            }
                            EvaluacionesLista.Add(new Evaluaciones { Nombre = "Prueba N" + j, Alumno = al, Asignatura = asign, Nota = nota });
                        }

                    }

                }
                curso.Evaluaciones = EvaluacionesLista;
            }
            
            

            
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura { Nombre = "Matemática"},
                    new Asignatura { Nombre = "Educación Física"},
                    new Asignatura { Nombre = "Castellano"},
                    new Asignatura { Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var ListaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1}{n2}{a1}" };
            return ListaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso(){ Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso(){ Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde },
                new Curso(){ Nombre = "501", Jornada = TiposJornada.Tarde },
            };
            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20); // Mínimo y máximo de num aleatorio
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }
}