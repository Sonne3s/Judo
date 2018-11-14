using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judo.WebUI.Helpers
{
    public static class ViewTemplateHelper
    {
        public static Dictionary<string, object> ToDictionary(this object o)
        {
            var dictionary = new Dictionary<string, object>();

            foreach (var propertyInfo in o.GetType().GetProperties())
            {
                if (propertyInfo.GetIndexParameters().Length == 0)
                {
                    dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(o, null));
                }
            }

            return dictionary;
        }

        public static ModelStateDictionary ToModelStateDictionary(this Dictionary<string, object> dictionary)
        {
            ModelStateDictionary output = new ModelStateDictionary();
            return output.AddRange(dictionary as IEnumerable<KeyValuePair<string, ModelStateEntry>>) as ModelStateDictionary;
        }

        public static IEnumerable<KeyValuePair<string, ModelStateEntry>> Add(this IEnumerable<KeyValuePair<string, ModelStateEntry>> e, KeyValuePair<string, ModelStateEntry> value)
        {
            foreach (var cur in e)
            {
                yield return cur;
            }
            yield return value;
        }

        public static IEnumerable<KeyValuePair<string, ModelStateEntry>> AddRange(this IEnumerable<KeyValuePair<string, ModelStateEntry>> main, IEnumerable<KeyValuePair<string, ModelStateEntry>> add)
        {
            foreach (var cur in main)
            {
                yield return cur;
            }
            foreach (var cur in add)
            {
                yield return cur;
            }
        }

        public static ViewDataDictionary ToViewDataDictionary(this Dictionary<string, object> dictionary)
        {
            return new ViewDataDictionary(new EmptyModelMetadataProvider(), dictionary.ToModelStateDictionary());
        }

        public static ViewDataDictionary ToViewDataDictionary(this object obj)
        {
            return obj.ToDictionary().ToViewDataDictionary();
        }
    }
}
