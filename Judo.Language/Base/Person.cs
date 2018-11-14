using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judo.Language.Base
{
    public static class Person
    {
        public static string Male
        {
            get
            {
                return MaleDict[Setting.GetLanguage()];
            }
        }

        public static string Female
        {
            get
            {
                return FemaleDict[Setting.GetLanguage()];
            }
        }

        public static Dictionary<int, string> MaleDict => new Dictionary<int, string>()
        {
            { Setting.Russian, "Мужской"}
        };

        public static Dictionary<int, string> FemaleDict => new Dictionary<int, string>()
        {
            { Setting.Russian, "Женский"}
        };
    }
}
