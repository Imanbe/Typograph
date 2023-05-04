using System.Text;


/* 

        Правила:
        
        2. Нельзя писать подряд более одного пробела.

        9. Символ «плюс-минус» задаётся так: ± ненужно использовать конструкции типа «(+,−)».
        
        13. Везде где имеется троеточие, его следует писать не тремя точками, а знаком … Например: чтобы получить «Молчат… нет ответа…» нужно писать «Молчат... нет ответа...».

        1* Замена (c) на символ копирайта ©.

        2* Все буквы с нижним регистром должны стать с верхним, и наоборот верхние должны стать нижними.
        
*/

namespace Typograph
{
    static public class Parser
    {
        static public void Pasring(ref string str)
        {
            // 2
            Check2Spaces(ref str);

            // 9
            CheckPlsMns(ref str);

            // 13
            Check3Dots(ref str);

            // 16
            CheckDashAndSpace(ref str);

            // 1*
            CheckCoopyright(ref str);

            // 2*
            CheckUpperLower(ref str);
        }

        /// <summary>
        /// 2. Нельзя писать подряд более одного пробела.
        /// </summary>
        /// <param name="str"></param>
        static public void Check2Spaces(ref string str)
        {
            str = str.Replace("  ", " ");
            if (str.Contains("  "))
            {
                Check2Spaces(ref str);
            }
        }

        /// <summary>
        /// 13. Везде где имеется троеточие, его следует писать не тремя точками, а знаком … Например: чтобы получить «Молчат… нет ответа…» нужно писать «Молчат... нет ответа...».
        /// </summary>
        /// <param name="str"></param>
        static public void Check3Dots(ref string str)
        {
            str = str.Replace("...", "…");
            if (str.Contains("..."))
            {
                Check3Dots(ref str);
            }
        }

        /// <summary>
        /// 16. Между тире и предыдущим словом желательно всегда ставить непереносимый пробел, чтобы не было ситуаций, когда новая строка начинается с тире.
        /// </summary>
        /// <param name="str"></param>
        static public void CheckDashAndSpace(ref string str)
        {
            if (str.Contains(" -"))
            {
                int i = str.IndexOf(" -");

                char[] str_ = str.ToCharArray();

                str_[i] = (char)160;

                str = new string(str_);
            }

            if (str.Contains(" -"))
            {
                CheckDashAndSpace(ref str);
            }
        }

        /// <summary>
        /// 9. Символ «плюс-минус» задаётся так: ± ненужно использовать конструкции типа «(+,−)».
        /// </summary>
        /// <param name="str"></param>
        static public void CheckPlsMns(ref string str)
        {
            if (str.Contains("+-"))
            {
                str = str.Replace("+-", "±");
            }

            if (str.Contains("(+,-)"))
            {
                str = str.Replace("(+,-)", "±");
            }

            if (str.Contains("+,-"))
            {
                str = str.Replace("+,-", "±");
            }

            if (str.Contains("+-") || str.Contains("(+,-)") || str.Contains("+,-"))
            {
                CheckPlsMns(ref str);
            }
        }

        /// <summary>
        /// 1* Замена (c) на символ копирайта ©.
        /// </summary>
        /// <param name="str"></param>
        static public void CheckCoopyright(ref string str)
        {
            str = str.Replace("(c)", "©");
            str = str.Replace("(с)", "©");

            if (str.Contains("(c)") || str.Contains("(с)"))
            {
                CheckCoopyright(ref str);
            }
        }

        /// <summary>
        /// 2* Все буквы с нижним регистром должны стать с верхним, и наоборот верхние должны стать нижними.
        /// </summary>
        /// <param name="str"></param>
        static public void CheckUpperLower(ref string str)
        {
            StringBuilder sb = new StringBuilder(str);

            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsUpper(sb[i]))
                {
                    sb[i] = sb[i].ToString().ToLower().ToCharArray()[0];
                }
                else if (char.IsLower(sb[i]))
                {
                    sb[i] = sb[i].ToString().ToUpper().ToCharArray()[0];
                }
            }

            str = sb.ToString();
        }

    }
}
