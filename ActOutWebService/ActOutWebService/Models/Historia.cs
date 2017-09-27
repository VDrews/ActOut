using System;

namespace ActOutWebService.Models
{
    //Tabla de Historias
    public class Historia
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public string Estado { get; set; }
        public int Type { get; set; }
        public int Visitas { get; set; }
        public float Sentimiento { get; set; }
        public int Color { get; set; }
        public DateTime Date { get; set; }

    }
}