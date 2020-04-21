using CheckApp.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckApp.Models
{
    public class Base<T>
    {

        public static T FromJson(string json) => Utilidades.DesserealizarJson<T>(json);

        public static List<T> FromJsonList(string json) => Utilidades.DesserealizarJson<List<T>>(json);

        public string ToJson() => Utilidades.SerializarJson(this);
    }
}
