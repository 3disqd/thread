using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Thread_safety
{
    public class FactoryServer : AbstractServer
    {
        protected override void Handling(HttpListenerContext context, IStruct structure)
        {
            new TaskFactory().StartNew(() =>
            {
                var newClient = new Client(context, structure);
                newClient.RunClient();
            });
        }

        public FactoryServer(IStruct structure) : base(structure)
        {
        }
    }
}
