using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public interface IEncodeDecode
    {
        string Decode(string input);
        string Encode(string input);
    }
}
