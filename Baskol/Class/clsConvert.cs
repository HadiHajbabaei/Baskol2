using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class clsConvert
{
    public string Simicalon(string txt)
    {
        string t = "";
        string s = "";
        for (int i = 1; txt.Length - i >= 0; i++)
        {
            if (s.Length % 3 == 0 && s.Length > 1)
            {
                t += "," + txt[txt.Length - i];
                s += txt[txt.Length - i].ToString();
            }
            else
            {
                t += txt[txt.Length - i];
                s += txt[txt.Length - i].ToString();
            }
        }
        s = "";
        for (int i = 1; t.Length - i >= 0; i++)
            s += t[t.Length - i];

        return s;
    }
}

