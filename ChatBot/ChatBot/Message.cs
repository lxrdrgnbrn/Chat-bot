using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    /// <summary>
    /// Структура Вывода сообщений
    /// </summary>
    [Serializable]
    public struct Message
    {

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Дата сообщения
        /// </summary>
        public string MessageDate { get; set; }

        /// <summary>
        /// Имя отправителя сообщения
        /// </summary>
        public string MessageName { get; set; }

        /// <summary>
        /// Сообщение отпрвил пользователь (Да - true, Нет - false)
        /// </summary>
        public bool isFromUser { get; set; }

    }
}
