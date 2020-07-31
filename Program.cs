using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            Printer.Beep(cantidad: 3);
            ImprimirCursosEscuela(engine.Escuela);

        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos escuela");
            foreach (var curso in escuela.Cursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
            }
        }
    }
}
