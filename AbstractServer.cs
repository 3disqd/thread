using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_safety
{
    abstract public class AbstractServer
    {
        public HttpListener listener;

        protected AbstractServer(IStruct structure)
        {
            // Создаем "слушателя" для указанного порта
            listener = new HttpListener();
            listener.Prefixes.Add("http://*:8077/method/");
            listener.Start();
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                Handling(context, structure);

            }
        }

        protected abstract void Handling(HttpListenerContext context, IStruct structure);

        // Остановка сервера
        ~AbstractServer()
        {
            // Если "слушатель" был создан
            if (listener != null)
            {
                // Остановим его
                listener.Stop();
            }
        }
    }
}
