namespace Lizarb.Validador
{
    public static partial class Valida
    {
        public static bool EhPis(this string pis)
        {
            if (string.IsNullOrEmpty(pis))
                return false;

            int modI = 0;
            int dv1 = -1;
            byte ind = 0;
            int num = -1;

            foreach (byte c in pis)
            {
                if (c > 47 && c < 58)
                {
                    var d = c - 48;

                    if (num != -2 && num != d)
                        num = num == -1 ? d : -2;

                    if (ind < 10)
                        modI += d * (10 - ind);
                    else
                        dv1 = d;
                    ind++;
                }
                else if (c != 46 && c != 45)
                {
                    return false;
                }
            }

            modI = modI % 11;
            modI = modI < 2 ? 0 : 11 - modI;

            return ind == 11 && num == -2 && dv1 == modI;
        }
    }
}
