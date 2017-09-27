using System;
using Xamarin.Forms;

namespace ActOut.Models
{
    public class HistoriaColor
    {
        public int Id { get; set; }

        public string Title { get; set; }
        private string _text;

        public string Text
        {
            get
            {
                if (_text.Length >= 240)
                {
                    return _text.Substring(0, 240) + "...";
                }

                return _text;
            }
            set => _text = value;
        }

        public string User { get; set; }
        public string Estado { get; set; }
        public int Type { get; set; }
        public int Visitas { get; set; }
        public string Sentimiento { get; set; }
        public Color Color { get; set; }
        public DateTime Date { get; set; }


        public HistoriaColor(Historia param)
        {
            Id = param.Id;
            Title = param.Title;
            Text = param.Text;
            User = param.User;
            Estado = param.Estado;
            Visitas = param.Visitas;
            Type = param.Type;
            Date = param.Date;

            if (param.Sentimiento > 0.8)
            {
                Sentimiento = "muy feliz";
            }
            else if (param.Sentimiento > 0.6)
            {
                Sentimiento = "feliz";
            }
            else if (param.Sentimiento > 0.4)
            {
                Sentimiento = "serio";
            }
            else if (param.Sentimiento > 0.2)
            {
                Sentimiento = "triste";
            }
            else
            {
                Sentimiento = "muy triste";
            }

            switch (param.Color)
            {
                case 1:
                    Color = Color.FromHex("#C1272D");
                    break;

                case 2:
                    Color = Color.FromHex("#0ABE22");
                    break;

                case 3:
                    Color = Color.FromHex("#2196F3");
                    break;

                case 4:
                    Color = Color.FromHex("#D6CB2E");
                    break;

                case 5:
                    Color = Color.FromHex("#7615D8");
                    break;

                case 6:
                    Color = Color.FromHex("#717171");
                    break;

                default:
                    Color = Color.FromHex("#2196F3");
                    break;
            }
        }

        public Historia GetHistoria()
        {
            var aux = new Historia
            {
                Id = Id,
                Title = Title,
                Text = _text,
                Type = Type,
                User = User,
                Visitas = Visitas,
                Estado = Estado,
                Date = Date
            };

            if (Sentimiento == "muy feliz")
            {
                aux.Sentimiento = 1;
            }
            else if (Sentimiento == "feliz")
            {
                aux.Sentimiento = 0.7f;
            }
            else if (Sentimiento == "serio")
            {
                aux.Sentimiento = 0.5f;
            }
            else if (Sentimiento == "triste")
            {
                aux.Sentimiento = 0.3f;
            }
            else
            {
                aux.Sentimiento = 0;
            }


            if (Color == Color.FromHex("#C1272D"))
                aux.Color = 1;

            else if (Color == Color.FromHex("#0ABE22"))
                aux.Color = 2;

            else if (Color == Color.FromHex("#2196F3"))
                aux.Color = 3;

            else if (Color == Color.FromHex("#D6CB2E"))
                aux.Color = 4;

            else if (Color == Color.FromHex("#7615D8"))
                aux.Color = 5;

            else if (Color == Color.FromHex("#717171"))
                aux.Color = 6;

            else aux.Color = 3;


            return aux;
        }

    }
}
