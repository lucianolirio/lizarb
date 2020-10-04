namespace Lizarb.Validador
{
    public static partial class Valida
    {
        public static bool EhCnpj(this string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj) || ValidaUtils.DigitosIguais(cnpj))
                return false;

            int modI = 0;
            int modII = 0;
            int dv1 = -1;
            int dv2 = -1;
            byte ind = 5;
            byte ind2 = 5;
            byte tam = 0;

            foreach (byte c in cnpj)
            {
                if (c > 47 && c < 58)
                {
                    tam++;
                    var d = c - 48;
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

            return tam == 14 && dv1 == modI && dv2 == modII;
        }
    }
}
