using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Judo.ViewTemplates
{
    public static class Helper
    {
        public static IEnumerable<SelectListItem> ToSelectListItem(this IDictionary<int, string> dictionary)
        {
            return dictionary.Select(d => new SelectListItem() { Value = d.Key.ToString(), Text = d.Value });
        }

        //public static object[] GetTrueParameters(object[] parameters, string requestTypeId)
        //{
        //    var result = new object[parameters != null ? parameters.Length + 1 : 1];
        //    if (parameters != null)
        //    {
        //        for (var i = 0; i < parameters.Length; i++)
        //        {
        //            result[i] = parameters[i];
        //        }
        //    }
        //    result[result.Length - 1] = requestTypeId;

        //    return result;
        //}

        //public static object[] GetTrueParameters(object[] parameters, object parentValue)
        //{
        //    var result = new object[parameters != null ? parameters.Length + 1 : 1];
        //    if (parameters != null)
        //    {
        //        for (var i = 0; i < parameters.Length; i++)
        //        {
        //            result[i + 1] = parameters[i];
        //        }
        //    }
        //    result[0] = parentValue;

        //    return result;
        //}

        //public static object[] GetTrueParameters(object[] parameters, object parentValue, string requestTypeId)
        //{
        //    var result = new object[parameters != null ? parameters.Length + 2 : 2];
        //    if (parameters != null)
        //    {
        //        for (var i = 0; i < parameters.Length; i++)
        //        {
        //            result[i + 1] = parameters[i];
        //        }
        //    }
        //    result[0] = parentValue;
        //    result[result.Length - 1] = requestTypeId;

        //    return result;
        //}
    }
}
