using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI.validacija
{
    class ValidacijaOznake : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (Equals(value, ""))
                return new ValidationResult(false, "   Polje ne sme biti prazno.");
            else
            {
                if (Equals(value, " "))
                {
                    return new ValidationResult(false, "   Zabranjen razmak na početku.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
        }
    }

    class ValidacijaPrihoda : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string valueS = value.ToString();

            var match = valueS.IndexOfAny("`~!@#$%^&*()_+-=qwertyuio p[]\"\\asdfghjkl;'zxcvbnm,./{}|<>?:QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray()) != -1;
            if (match)
                return new ValidationResult(false, "      Polje sme da sadrži samo cifre.");
            else
                return new ValidationResult(true, null);
        }
    }

    public class ValidacijaGradaIDrzave : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            {
                string valueS = value.ToString();
                int count = 0;
                foreach (char s in valueS)
                {
                    if (s.Equals(','))
                        count++;
                }
                var match = valueS.IndexOfAny("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMšđčćžŠĐČĆŽ,".ToCharArray()) != -1;
                if (!match)
                {
                    return new ValidationResult(false, "    Polje sme da sadrži samo.");
                }
                else
                {
                    if (count == 1)
                    {
                        return new ValidationResult(true, null);
                    }
                    else if (count == 0)
                    {
                        return new ValidationResult(false, "    Zarez(,) razdvaja grad i drzavu.");
                    }
                    else
                    {
                        return new ValidationResult(false, "    Sme da ima samo jedan zarez!");
                    }
                }
            }
        }
    }
}
