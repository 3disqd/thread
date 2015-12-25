using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Thread_safety
{
    public class Client
    {
        private HttpListenerContext Context;
        private IStruct Structure;

        public Client(HttpListenerContext context, IStruct structure)
        {
            Context = context;
            Structure = structure;
        }

        public void RunClient()
        {
            HttpListenerRequest request = Context.Request;
            var word = request.QueryString["word"];
            var replace = request.QueryString["replace"];

            // Obtain a response object.
            HttpListenerResponse response = Context.Response;

            // Construct a response.
            Tuple<int, string> ans;
            try
            {
                ans = Structure.ReplaceFirst(word, replace);
            }
            catch (Exception)
            {
                Console.WriteLine("Nevernie dannie");
                return;
            }
            string responseString;
            if (ans != null)
            {
                responseString =
                    new StringBuilder().Append("<HTML><BODY> ").Append(ans.Item1 + 1).Append(" <- stroka resultat ->")
                        .Append(ans.Item2).Append("</BODY></HTML>").ToString();
            }
            else
                responseString = "Net takoy bukvi";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
        }
    }
}
