using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingDemo.Common
{
    public static class ObjectSerialize
    {
        public static byte[] Serialize(this object item)
        {
            var serializeString = JsonConvert.SerializeObject(item);

            return Encoding.ASCII.GetBytes(serializeString);
        }

        public static T Deserialize<T>(this byte[] bytes)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.ASCII.GetString(bytes));
        }

        public static string DeserializeToText(this byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
