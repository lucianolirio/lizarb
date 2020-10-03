using System;
using System.Collections.Generic;
using System.Text;

namespace Lizarb.Validador
{
    public static partial class Valida
    {
        public static bool CNPJ(this string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            int modI = 0;
            int modII = 0;
            int dv1 = -1;
            int dv2 = -1;
            int ind = 5;
            int ind2 = 5;
            int num = -1;
            int tam = 0;

            foreach (byte c in cnpj)
            {
                if (c > 47 && c < 58)
                {
                    tam++;

                    var d = c - 48;

                    if (num == -1 && num != d)
                        num = num == -1 ? d : -2;

                    if (tam < 13)
                    {
                        modI += d * (10 - ind);
                        modII += d * (11 - ind2);

                        if (++ind > 8) ind = 1;
                        if (++ind2 > 9) ind2 = 2;
                    }
                    else if (tam < 14)
                        dv1 = d;
                    else
                        dv2 = d;
                }
                else if (c != 45 && c != 46 && c != 47)
                {
                    return false;
                }
            }

            modI = modI % 11;
            modI = modI < 2 ? 0 : 11 - modI;

            modII = (modII + modI * 2) % 11;
            modII = modII < 2 ? 0 : 11 - modII;

            return tam == 14 && num != -2 && dv1 == modI && dv2 == modII;
        }
    }
}
