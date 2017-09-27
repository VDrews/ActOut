using System;
using Microsoft.WindowsAzure.MobileServices;

namespace ActOut.Models
{
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

        [Version]
        public string AzureVersion { get; set; }

    }
}
