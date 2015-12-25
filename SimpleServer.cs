using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Thread_safety
{
    public class SimpleServer : AbstractServer
    {
        protected override void Handling(HttpListenerContext context, IStruct structure)
        {
            var client = new Client(context, structure);
            client.RunClient();
        }

        public SimpleServer(IStruct structure) : base(structure)
        {
        }
    }
}
