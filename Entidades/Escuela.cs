using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        string nombre; // atributo privado
        public string Nombre // propiedad mediadora del atributo privado 
        {
            get { return "Copia: " + nombre; }
            set { nombre = value.ToUpper(); }
        }
        public int AnioCreacion { get; set; } // propiedad con atributo "oculto" interno creado automáticamente
                                              // por C#
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }
        
        // Constructor forma tradicional
        // public Escuela(string nombre, int AnioCreacion)
        // {
        //     this.nombre = nombre; // Lo seteo a través del atributo directamente
        //     //Se usa this para referirse al nombre de la clase (porque la propiedad 
        //     //y el parámetro se llaman igual)
        //     this.AnioCreacion = AnioCreacion; // Lo seteo a través de la propiedad 
        // }

        public Escuela(string nombr, int anioCre) => (Nombre, AnioCreacion) = (nombr, anioCre);
        // Forma simplificada del constructor

        public Escuela(string nombr, int anioCre, TiposEscuela Tipo,
                      string Pais="", string ciudad="")// Pais y Ciudad son opcionales
        {
            (Nombre, AnioCreacion) = (nombr, anioCre);
            this.Pais = Pais; // Como la propiedad y el parámetro son con mayus necesito dif con el this
            Ciudad = ciudad; // Como la prop es en mayus y el parámetro no no es necesario el this
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela}, \nPais: {Pais}, Ciudad: {Ciudad}";
        }
    }

}