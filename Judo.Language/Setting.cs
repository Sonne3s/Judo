using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judo.Language
{
    internal static class Setting
    {
        public const int Russian = 0;

        public static int GetLanguage()
        {
            return Russian;
        }
    }
}
