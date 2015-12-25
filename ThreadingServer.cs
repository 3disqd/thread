using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_safety
{
    public class ThreadingServer : AbstractServer
    {
        protected override void Handling(HttpListenerContext context, IStruct structure)
        {
            var client = new Client(context, structure);
            new Thread(client.RunClient).Start();
        }

        public ThreadingServer(IStruct structure) : base(structure)
        {
        }
    }
}
