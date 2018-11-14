using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.ViewHelpers
{
    public static class StudentsHelper
    {
        public static Dictionary<int, string> GetDans
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    { 1, "Дан не присвоен"},
                    { 2, "6-й КЮ" },
                    { 3, "5-й КЮ" },
                    { 4, "4-й КЮ" },
                    { 5, "3-й КЮ" },
                    { 6, "2-й КЮ" },
                    { 7, "1-й КЮ" },
                    { 8, "1-й ДАН" },
                    { 9, "2-й ДАН" },
                    { 10, "3-й ДАН" },
                    { 11, "4-й ДАН" },
                    { 12, "5-й ДАН" },
                    { 13, "6-й ДАН" },
                    { 14, "7-й ДАН" },
                    { 15, "8-й ДАН" },
                    { 16, "9-й ДАН" },
                    { 17, "10-й ДАН" },
                };
            }
        }

        public static string GetColor(int danId)
        {
            switch(danId)
            {               
                case 2: return "#FFFFFF";
                case 3: return "#FFD91D";
                case 4: return "#DD792F";
                case 5: return "#21932E";
                case 6: return "#2D5DE2";
                case 7: return "#934D19";
                case 8:
                case 9:
                case 10:
                case 11:
                case 12: return "#000000";
                case 13: 
                case 14: 
                case 15: return "dual";
                case 16:
                case 17: return "#C61C18";
                default: return "none";
            }
        }
    }
}
