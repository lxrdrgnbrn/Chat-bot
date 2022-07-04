using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    class UserMessages
    {
        public List<string> Hi;
        public List<string> Time;
        public List<string> Weather;
        public List<string> Multiply;
        public List<string> Sum;
        public List<string> Dec;
        public List<string> Div;
        public List<string> Fact;
        public List<string> Browser;
        public List<string> Currency;
        public UserMessages()
        {
            SetHi();
            SetTime();
            SetWeather();
            SetMult();
            SetSum();
            SetDec();
            SetDiv();
            SetFact();
            SetBrowser();
            SetCurrency();
        }
        private void SetHi()
        {
            string path = @"List\Hi.txt";
            Hi = File.ReadAllLines(path).ToList();
        }

        private void SetTime()
        {
            string path = @"List\Time.txt";
            Time = File.ReadAllLines(path, Encoding.Default).ToList();
        }

        private void SetWeather()
        {
            string path = @"List\Weather.txt";
            Weather = File.ReadAllLines(path, Encoding.Default).ToList();
        }
        private void SetMult()
        {
            string path = @"List\Mult.txt";
            Multiply = File.ReadAllLines(path, Encoding.Default).ToList();
        }
        private void SetSum()
        {
            string path = @"List\Sum.txt";
            Sum = File.ReadAllLines(path, Encoding.Default).ToList();
        }
        private void SetDec()
        {
            string path = @"List\Dec.txt";
            Dec = File.ReadAllLines(path, Encoding.Default).ToList();
        }
        private void SetDiv()
        {
            string path = @"List\Div.txt";
            Div = File.ReadAllLines(path, Encoding.Default).ToList();
        }
        private void SetFact()
        {
            string path = @"List\UF.txt";
            Fact = File.ReadAllLines(path, Encoding.Default).ToList();
        }

        private void SetBrowser()
        {
            string path = @"List\Browser.txt";
            Browser = File.ReadAllLines(path, Encoding.Default).ToList();
        }
        private void SetCurrency()
        {
            string path = @"List\Currency.txt";
            Currency = File.ReadAllLines(path).ToList();
        }
    }   
}
