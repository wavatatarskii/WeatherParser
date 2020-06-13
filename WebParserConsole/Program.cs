using System;
using System.Net;
using System.IO;


namespace WebParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Запрос города и кода страны для точного прогноза в случае повторений*/
            string cityname = Console.ReadLine();
            string countrycode = Console.ReadLine();
            /*обращение к сетевому ресурсу - сайту*/
            String url = "http://api.openweathermap.org/data/2.5/weather?q="+cityname+","+countrycode+"&units=metric&appid=094fb4071c15962bb80f5a1d00659ffd";
            HttpWebRequest httpwbrqwst = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpwbrspns = (HttpWebResponse)httpwbrqwst.GetResponse();
            string response;
            using (StreamReader streamreader = new StreamReader(httpwbrspns.GetResponseStream()))
            {
                response = streamreader.ReadToEnd();
            }
            Weather_resp wthrrsp = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Weather_resp>(response);
            /*преобразование и добавление текущей даты к имени файла*/
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string filename = Date + ".txt";
            string path = "D:\\DDDIPLOM\\Parser\\WebParserConsole\\" + filename;
            using (StreamWriter file = new StreamWriter(path))
            {
                /*вывод в файл*/

                file.WriteLine("Метеообстановка в городе {0}:\n Температура {1} градусов Цельсия\n Влажность {2}" + "%\n" + " Давление {3} мм.рт.ст.\n Время восхода {4}\n Время заката {5}", wthrrsp.Name, wthrrsp.Main.temp, wthrrsp.Main.humidity, wthrrsp.Main.pressure / (1.333), (new DateTime(1970, 1, 1, 3, 0, 0, 0)).AddSeconds(wthrrsp.Sys.sunrise), (new DateTime(1970, 1, 1, 3, 0, 0, 0)).AddSeconds(wthrrsp.Sys.sunset)); //Время увеличено на 3ч с поправкой на часовой пояс, давление переведено из гПа
                file.Close();
            }
            /*вывод в консоль*/
            Console.WriteLine("Метеообстановка в городе {0}:\n Температура {1} градусов Цельсия\n Влажность {2}" + "%\n" + " Давление {3} мм.рт.ст.\n Время восхода {4}\n Время заката {5}", wthrrsp.Name, wthrrsp.Main.temp, wthrrsp.Main.humidity, wthrrsp.Main.pressure / (1.333), (new DateTime(1970, 1, 1, 3, 0, 0, 0)).AddSeconds(wthrrsp.Sys.sunrise), (new DateTime(1970, 1, 1, 3, 0, 0, 0)).AddSeconds(wthrrsp.Sys.sunset));//Время увеличено на 3ч с поправкой на часовой пояс, давление переведено из гПа
            Console.ReadLine();
        }

    }
}
