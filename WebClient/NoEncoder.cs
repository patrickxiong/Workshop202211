using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public class NoEncoder : IEncodeDecode
    {
        public string Decode(string input)
        {
            return input;
        }

        public string Encode(string input)
        {
            return input;
        }
    }
}
