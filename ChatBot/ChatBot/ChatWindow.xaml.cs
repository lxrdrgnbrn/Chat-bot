using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ChatBot
{



    /// <summary>
    /// Логика взаимодействия для ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        BindingList<Message> _Message = new BindingList<Message>();
        Bot Bot = new Bot();

        public ChatWindow()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _Message.Add(new Message{ MessageText = TextMessage.Text, MessageName = Bot.GetName(), MessageDate = DateTime.Now.ToShortTimeString(), isFromUser = true });
            _Message.Add(new Message() { MessageText = Bot.SetMessage(TextMessage.Text.ToLower()), MessageName = Bot.BotName, MessageDate = DateTime.Now.ToShortTimeString(), isFromUser= false });
            MessageBox.ScrollIntoView(MessageBox.Items[_Message.Count - 1]);
           TextMessage.Text = "";
            
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Bot.SetName(MainWindow.UserName);
            MessageBox.ItemsSource = _Message;
            for (int i=0; i<Bot.LoadHistory().Count; i++)
            {
                _Message.Add(Bot.LoadHistory()[i]);
            }
            _Message.Add(new Message() { MessageText = Bot.Greeting(), MessageName = Bot.BotName, MessageDate = DateTime.Now.ToShortTimeString(), isFromUser = false });
            MessageBox.ScrollIntoView(MessageBox.Items[_Message.Count - 1]);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _Message.Clear();

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Button_Click(SendMessage,null);
            if (MessageBox.Items.Count>1)
                MessageBox.ScrollIntoView(MessageBox.Items[_Message.Count - 1]);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Bot.SaveHistory(_Message);
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow HW = new HelpWindow();
            HW.Show();
        }
    }
}
