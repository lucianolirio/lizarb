namespace Lizarb.Validador
{
    public static partial class Valida
    {
        public static bool EhCpf(this string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            int modI = 0;
            int modII = 0;
            int dv1 = -1;
            int dv2 = -1;
            byte ind = 0;
            int num = -1;

            foreach (byte c in cpf)
            {
                if (c > 47 && c < 58)
                {
                    var d = c - 48;

                    if (num != -2 && num != d)
                        num = num == -1 ? d : -2;

                    if (ind < 9)
                    {
                        modI += d * (10 - ind);
                        modII += d * (11 - ind);
                    }
                    else if (ind < 10)
                        dv1 = d;
                    else
                        dv2 = d;
                    ind++;
                }
                else if (c != 46 && c != 45)
                {
                    return false;
                }
            }

            modI = modI % 11;
            modI = modI < 2 ? 0 : 11 - modI;

            modII = (modII + modI * 2) % 11;
            modII = modII < 2 ? 0 : 11 - modII;

            return ind == 11 && num == -2 && dv1 == modI && dv2 == modII;
        }
    }
}
