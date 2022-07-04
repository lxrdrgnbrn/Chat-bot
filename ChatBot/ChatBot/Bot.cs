using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace ChatBot
{
    class Bot
    {

        /// <summary>
        /// Имя бота
        /// </summary>
        public string BotName = "Боб";

        /// <summary>
        /// Имя пользователя
        /// </summary>
        protected string Name;

        /// <summary>
        /// Имя файла для сохранения истории
        /// </summary>
        protected string PATH = "History.json";

        /// <summary>
        /// История диалога
        /// </summary>
        protected BindingList<Message> History;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Bot()
        {
            Name = "";
        }

        /// <summary>
        /// Сеттер имени пользователя
        /// </summary>
        /// <param name="Name">Имя пользователя</param>
        public void SetName(string Name)
        {
            this.Name = Name;
        }

        /// <summary>
        /// Геттер имени пользователя
        /// </summary>
        /// <returns>Имя пользователя</returns>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// Сохранение истории сообщений
        /// </summary>
        /// <param name="Dialog">Коллекция хранящая диалог</param>
        public void SaveHistory(BindingList<Message> Dialog)
        {
            History = Dialog;
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(History);
                writer.Write(output);
            }
        }

        /// <summary>
        /// Загрузка истории сообщений
        /// </summary>
        /// <returns>Коллекцию хранящую историю сообщений (BindingList(Message))</returns>
        public BindingList<Message> LoadHistory()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Message>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Message>>(fileText);
            }
        }

        /// <summary>
        /// Приветствие 
        /// </summary>
        /// <returns>Приветствие бота (string)</returns>
        public string Greeting()
        {
            var rand = new Random();
            var gr = new List<string>
            {
                "Здраствуй",
                "Привет",
                "Ку"
            };
            string mes = gr[rand.Next(0,gr.Count)]+ " " + Name;
            return mes;
        }

        public string Date()
        {
            return "Сейчас " + DateTime.Now.ToShortDateString();
        }

        /// <summary>
        /// Бот открывает страницу с погодой в брузере
        /// </summary>
        public void Weather()
        {
            System.Diagnostics.Process.Start("https://yandex.ru/pogoda");
        }

        /// <summary>
        /// Бот откроет браузер
        /// </summary>
        public void Browser()
        {
            System.Diagnostics.Process.Start("http://");
        }

        /// <summary>
        /// Бот откроет страницу с курсом валют в браузере
        /// </summary>
        public void Сurrency()
        {
            System.Diagnostics.Process.Start("https://cbr.ru/currency_base/daily/");
        }

        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="x">Первое число</param>
        /// <param name="y">Второе число</param>
        /// <returns>Результат умножения</returns>
        public double Multiply(double x, double y)
        {
            return x * y;
        }

        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="x">Первое число</param>
        /// <param name="y">Второе число</param>
        /// <returns>Результат сложения</returns>
        public double Sum(double x, double y)
        {
            return x + y;
        }
        
        /// <summary>
        /// Разность
        /// </summary>
        /// <param name="x">Первое число</param>
        /// <param name="y">Второе число</param>
        /// <returns>Результат разности</returns>
        public double Dec(double x, double y)
        {
            return x - y;
        }

        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="x">Первое число</param>
        /// <param name="y">Второе число</param>
        /// <returns>Результат деления</returns>
        public double Div(double x, double y)
        {
            return x / y;
        }
        
        /// <summary>
        /// Случайный факт
        /// </summary>
        /// <returns>Факт (string)</returns>
        public string Facts()
        {
            var f = new List<string>();
            string path = @"List\Facts.txt";
            f = File.ReadAllLines(path, Encoding.Default).ToList();
            var rand = new Random();
            return f[rand.Next(0, f.Count)];
        }



        /// <summary>
        /// Сеттер сообщения пользователя
        /// </summary>
        /// <param name="mes">сообщение пользователя</param>
        /// <returns>Сообщение бота (string)</returns>
        public string SetMessage(string mes)
        {
            UserMessages UM = new UserMessages();
            string[] words = mes.Split(' ');
            if (UM.Hi.Contains(mes))
                return Greeting();
            else if (UM.Time.Contains(mes))
                return Date();
            else if (UM.Weather.Contains(mes))
            {
                Weather();
                return "Cекундочку..."; 
            }
            else if (UM.Browser.Contains(mes))
            {
                Browser();
                return "Cекундочку...";
            }
            else if (UM.Currency.Contains(mes))
            {
                Сurrency();
                return "Cекундочку...";
            }
            else if (UM.Multiply.Contains(words[0]))
            {
                try
                {
                    return Convert.ToString(Multiply(Convert.ToDouble(words[1]),
                        Convert.ToDouble(words[3])));
                }
                catch (Exception e)
                {

                    return "Я тебя не понимаю";
                }
            }
            else if (UM.Sum.Contains(words[0]))
            {
                try
                {
                    return Convert.ToString(Sum(Convert.ToDouble(words[1]), 
                        Convert.ToDouble(words[3])));
                }
                catch (Exception e)
                {

                    return "Я тебя не понимаю";
                }
            }
            else if (UM.Dec.Contains(words[0]))
            {
                try
                {
                   return Convert.ToString( Dec(Convert.ToDouble(words[3]),
                       Convert.ToDouble(words[1])));
                }
                catch (Exception e)
                {

                    return "Я тебя не понимаю";
                }
            }
            else if (UM.Div.Contains(words[0]))
            {
                try
                {
                    return Convert.ToString(Div(Convert.ToDouble(words[1]), 
                        Convert.ToDouble(words[3])));
                }
                catch (Exception e)
                {

                    return "Я тебя не понимаю";
                }
            }

            else if (UM.Fact.Contains(mes))
            {
                return Facts();
            }
            else
               return "Я тебя не понимаю";

        }


    }
}
