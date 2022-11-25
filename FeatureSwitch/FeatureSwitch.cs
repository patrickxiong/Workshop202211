using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureSwitch
{
    public class FeatureSwitch
    {
        static Dictionary<string,bool> features=new Dictionary<string,bool>();

        public static void LoadConfig()
        {

        }

        public static bool Enabled(string FeatureCode, string Version)
        {


            return false;
        }
    }
}
