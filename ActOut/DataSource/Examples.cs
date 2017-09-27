using SQLite;
using System;
using System.Collections.Generic;
using ActOut.Interfaces;
using ActOut.Models;
using Xamarin.Forms;

//using XamarinForms.SQLite.SQLite;

namespace ActOut.Services
{
    public class Examples
    {
        private readonly SQLiteConnection _sqLiteConnection;

        public Examples()
        {
            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
        }

        public void CrearUsuarios()
        {

            _sqLiteConnection.Insert(new User
            {
                Username = "Daniellix",
                Password = "Danielix2017",
                EstadoActual = "Pensando en que hacer en mi futuro",
                Type = 1
            });

            _sqLiteConnection.Insert(new User
            {
                Username = "JuanetMGZ",
                Password = "JuanetMGZ2017",
                EstadoActual = "Mejorando cada día mas",
                Type = 1
            });

            _sqLiteConnection.Insert(new User
            {
                Username = "ManelKher",
                Password = "ManelKher2017",
                EstadoActual = "Contento por todo!",
                Type = 9
            });

            _sqLiteConnection.Insert(new User()
            {
                Username = "Rodriducs",
                Password = "Rodriducs",
                EstadoActual = "Muy contento con mi familia",
                Type = 4
            });

            _sqLiteConnection.Insert(new User()
            {
                Username = "SkyLine_7",
                Password = "SkyLine2017",
                EstadoActual = "Molesta",
                Type = 3
            });

            _sqLiteConnection.Insert(new User()
            {
                Username = "Gogilga",
                Password = "Gogilga2017",
                EstadoActual = "Muy Cabreado",
                Type = 4
            });

            _sqLiteConnection.Insert(new User()
            {
                Username = "Perelot",
                Password = "Perelot2017",
                EstadoActual = "Mi casi muerte",
                Type = 5
            });

            _sqLiteConnection.Insert(new User()
            {
                Username = "Harin",
                Password = "Harin2017",
                EstadoActual = "Fastidiado",
                Type = 3
            });

            _sqLiteConnection.Insert(new User()
            {
                Username = "Stna",
                Password = "Stna2017",
                EstadoActual = "Intentando estar animada",
                Type = 4
            });

            _sqLiteConnection.Insert(new User()
            {
                Username = "Picco",
                Password = "Picco2017",
                EstadoActual = "Haciendo todo lo posible",
                Type = 4
            });

            _sqLiteConnection.Insert(new User()
            {
                Username = "DanSK",
                Password = "DanSK2017",
                EstadoActual = "Asustado",
                Type = 5
            });

        }

        public void CrearHistorias()
        {
            var ejemplos = new List<Historia>
            {
                new Historia()
                {
                    User = "Daniellix",
                    Title = "Problemas económicos en mi familia",
                    Text = "Desde que a mi padre le despidió su empresa hace años. No nos podemos permitir gran cosa y recibimos la ayuda de familiares. Pero aún así se nota que no estamos en buena situación. Hay días que no puedo llevar la merienda para la hora del patio y mi material escolar se nota que es de segunda mano.Los de clase me hacen la vida imposible. ",
                    Estado = "Con problemas familiares",
                    Sentimiento = 0.2f,
                    Type = 1,
                    Color = 3,
                    Visitas = 304,
                    Date = DateTime.Now
                },
                new Historia()
                {
                    User = "Daniellix",
                    Title = "Mis compañeros de clase",
                    Text = "Desde todos los problemas económicos que tenemos en casa, en clase suelo recibir muchas burlas por parte de mis compañeros. Falto mucho a clase por miedo a sus palabras. Los profesores creen que falto porque no me intereso. Estoy empezando a replantearme dejar los estudios y ponerme a trabajar. Así me alejare del colegio y ayudare a mi familia.",
                    Estado = "Pensando en que hacer en mi futuro",
                    Sentimiento = 0.3f,
                    Type = 1,
                    Color = 4,
                    Visitas = 152,
                    Date = DateTime.Now
                },
                new Historia()
                {
                    User = "JuanetMGZ",
                    Title = "Mi problema con mi físico",
                    Text = "Hola soy una chica que en estos momentos esta cursando el bachiller. Pero mi paso por la ESO fue duro debido a que recibí bullying por parte de mis compañeros de clase. En especial de los chicos. Ellos se metian con mi físico porque digamos que no cumplía con los canones de belleza en lo que respecta al cuerpo. Llegaron a ser extremadamente crueles conmigo. Incluso suspendía gimnasia porque no quería participar. Hasta que un dia quise decir basta y empecé a vomitar todo lo que comía. Cada comida a los cinco minutos ya estaba fuera de mi. Al cabo de unos meses me veía más delgada y más satisfecha porque la gente dejó de meterse conmigo. Así que seguí con el plan. Pero esta no es la solución, ya que antes de acabar cuarto de la ESO caí gravemente enferma y acabe en el hospital. Allí aprendí que en la vida no hay que dejarse llevar por lo que diga la gente y que hay que querer a tu cuerpo si está sano. Ellos casi me hundieron la vida aunque fuera una chica sana y feliz",
                    Estado = "Aprendiendo a avanzar",
                    Sentimiento = 0.7f,
                    Type = 1,
                    Color = 6,
                    Visitas = 32,
                    Date = DateTime.Now
                },
                new Historia()
                {
                    User = "ManelKher",
                    Title = "Mi superación en las drogas",
                    Text = "Hola la historia que os voy a contar ahora afortunadamente acaba bien y escribo este mensaje para que la gente se de cuenta que de esto se puede salir con mucho esfuerzo.Yo empecé con el mundo de las drogas con 16 años. Era una tonteria porque mis amigos y yo nos fumabamos el típico porro cuando salíamos de fiesta. Pero fue empeorando cuando llegue a la uni, debido a mi y a mis compañeros de clase, empecé a probar cosas más duras.Pensé que sería divertido y que me ayudaría a relajarme porque tenía mucha presión por la uni. Cuando me di cuenta, gastaba más dinero en eso que en comida. Mis padres me mantenían económicamente y cuando vieron que las cuenta no encajaban. El verano que volví a mi casa me entró el bajón por el mono y mis padres  ya se dieron cuenta de lo que pasaba. Me ingresaron en un centro de rehabilitación y después de unos largos meses horrorosos ya estoy en perfecto estado. Creo que es una experiencia que no se lo recomiendo a nadie aunque mucha gente se toma esto como una broma.",
                    Estado = "Contento por todo!",
                    Sentimiento = 0.9f,
                    Color = 5,
                    Type = 9,
                    Visitas = 7504,
                    Date = DateTime.Now
                },

                new Historia()
                {
                    User = "SkyLine_7",
                    Title = "Mi novia y mis padres",
                    Text = "Hola soy una chica de 16 años y hace unos meses me empezo a atraer una chica que conocí en una fiesta. Hemos quedado mucho y hemos hablado casi todos los días. Y hace un par de meses empezamos a salir. Yo la quiero muchísimo. Pero el problema son mis padres. Ellos no miran con buenos ojos a los homosexuales y no entienden el amor que puede surgir entre dos personas del mismo sexo. Quiero presentarles a mi novia y no ir escondiendo nuestro amor como si fuera algo malo. ",
                    Estado = "Molesta",
                    Sentimiento = 0.4f,
                    Color = 4,
                    Type = 3,
                    Visitas = 320,
                    Date = DateTime.Now
                },

                new Historia()
                {
                    User = "Rodriducs",
                    Title = "Un final feliz",
                    Text = "Hola quiero compartir la experiencia que viví cuando me sentí rechazado por mi hermana por estar saliendo con un chico. Yo toda mi vida he sido homosexual, pero que lo he ocultado un poco porque no decía nada de las relaciones que tenia. Pero conoci al hombre que es ahora mi marido y me hizo tener el valor que me faltaba para poder contarle a mi familia que salía con un chico. Con mis padres fue bien porque ellos ya sospechaban algo pero mi hermana se negaba a verlo. Estuvimos años distanciados pero con el paso del tiempo ha ido poco a poco asimilandolo. Hace unas semanas fue mi boda y fue el día más feliz de mi vida porque todos éramos felices y mi hermana se lleva estupendamente con mi marido. ",
                    Estado = "Muy contento con mi familia",
                    Sentimiento = 1f,
                    Color = 4,
                    Type = 3,
                    Visitas = 643,
                    Date = DateTime.Now
                },

                new Historia()
                {
                    User = "Harin",
                    Title = "Mi trabajo",
                    Text = "Hola estoy escribiendo este mensaje para hablar sobre un problema que tengo. Yo trabajo en una empresa de publicidad y hace unos meses han cambiado al director. Desde el momento en que me vio con mi pareja después de salir del trabajo me trata diferente. Al principio no quise pensar que era homofobo pero había algunas cosas que eran evidentes. Algunos ejemplos son que ni ni me dirigia la palabra, los trabajos presentados no me los valoraba... La gota que colmo el vaso fue que me ha descendido de puesto de trabajo sin motivo alguno. Insistí en conocer sus razones y me contestó que gente como yo debería estar encerradas, que estamos enfermos y que diera gracias porque no me ha despedido. ",
                    Estado = "Fastidiado",
                    Sentimiento = 0.3f,
                    Color = 1,
                    Type = 3,
                    Visitas = 125,
                    Date = DateTime.Now
                },

                new Historia()
                {
                    User = "Picco",
                    Title = "Esclavitud",
                    Text = "Hola soy un chico de procedencia china que hace unos meses llegó a España para trabajar en una empresa. Pensaba que España todos eran respetuosos pero me equivoque. En mi trabajo he encontrado personas que han sido crueles por mi raza y se han dejado llevar por el topico de que los asiáticos trabajamos mucho. Durante este tiempo hemos hecho varios proyectos en los que se me ha amenazado para que yo haga todo el trabajo. Además, se dirigen a mi con el apodo del \"chinito de mierda\" o el \"asiático esclavo\". No quiero irme de este trabajo porque es la oportunidad que he estado esperando toda mi vida y tampoco quiero crear un conflicto.",
                    Estado = "Haciendo todo lo posible",
                    Sentimiento = 0.5f,
                    Color = 3,
                    Type = 4,
                    Visitas = 126,
                    Date = DateTime.Now
                },

                new Historia()
                {
                    User = "Stna",
                    Title = "Mi dia a dia",
                    Text = "Hola soy una chica árabe que trabaja como dependienta en una papelería en un barrio donde no hay gente de mi misma raza. Esto hace que muchas veces te miren de forma extraña cuando voy andando para ir a mi casa o ir al trabajo. Hay ocasiones que hasta escucho comentarios despectivos acerca de mi raza o creencia. En la tienda también noto esa situacion con los clientes que me intentan ser atendidos por mi otra compañera de trabajo. Estoy agradecida porque mi jefa y mi compañera sean buenas conmigo pero los demás son crueles conmigo. ",
                    Estado = "Intentando estar animada",
                    Sentimiento = 0.6f,
                    Color = 2,
                    Type = 4,
                    Visitas = 432,
                    Date = DateTime.Now
                },

                new Historia()
                {
                    User = "DanSK",
                    Title = "El Robo en mi casa",
                    Text = "Hace unas semanas entraron a mi casa a robar. Entraron por la ventana de la cocina y lo primero que hicieron es darme una paliza que me dejó inconsciente en el suelo. Luego me desperté en el hospital destrozada y mis familiares me explicaron que se habían llevado todo lo que tenía valor de mi casa. Hace tres días que estoy fuera del hospital. Aún tengo que regresar a que me curen heridas. Pero el problema es que ya no estoy segura en casa. Casi todas las noches me dan ataques de ansiedad y temo por mi seguridad. ",
                    Estado = "Asustado",
                    Sentimiento = 0.2f,
                    Color = 4,
                    Type = 5,
                    Visitas = 457,
                    Date = DateTime.Now
                },

                new Historia()
                {
                    User = "Perelot",
                    Title = "Mi casi muerte",
                    Text = "Hola soy un chico que pasó una historia bastante desagradable con las peleas callejeras. Yo pertenecía a una banda en la que intentábamos siempre marcar el terreno y hacernos respetar. Muchas veces nos peleamos con muchas bandas. Acabábamos con rasguños alguna que otra herida. Pero la última pelea me apuñalaron con una navaja en el abdomen. Estuve a punto de morir. Pero gracias a que fui atendido rapido pude salvarme. A partir de ese momento decidí alejarme de ese mundillo y juntarme con otras personas.",
                    Estado = "Cambiando las cosas",
                    Sentimiento = 0.63f,
                    Color = 2,
                    Type = 5,
                    Visitas = 782,
                    Date = DateTime.Now
                },

                new Historia()
                {
                    User = "Gogilga",
                    Title = "Mi jefe",
                    Text = "Buenas, soy un chico somalí que acaba de llegar a España. En mi trabajo estoy discriminado por mi raza por parte de mi jefe. El en muchas ocasiones ha mostrado una actitud de desprecio. Mis compañeros de trabajo me intentan ayudar y me apoyan. Pero el jefe está haciendo un poco difícil la convivencia de grupo y sobre todo la mía propia. La gota que colmó el vaso fue la disminución de sueldo sin motivo aparente. ",
                    Estado = "Muy Cabreado",
                    Sentimiento = 0.2f,
                    Color = 1,
                    Type = 4,
                    Visitas = 147,
                    Date = DateTime.Now
                }


            };

            foreach (var item in ejemplos)
            {
                _sqLiteConnection.Insert(item);
            }


        }

    }
}
