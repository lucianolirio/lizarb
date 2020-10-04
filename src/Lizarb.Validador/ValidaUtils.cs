using System;
using System.Collections.Generic;
using System.Text;

namespace Lizarb.Validador
{
    internal static class ValidaUtils
    {
        public static bool DigitosIguais(this string digitos)
        {
            int num = -1;
            foreach (byte d in digitos)
            {
                if (d > 47 && d < 58)
                {
                    if (num != -2 && num != d)
                    {
                        num = num == -1 ? d : -2;
                        if (num == -2)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
