using NetCoders.MicroErp.Common.Attributes;
using System;
using System.Reflection;

namespace NetCoders.MicroErp.Dal.Utils
{
    public static class PropertyInfoUtil
    {
        public static string GetNameOfProperty(this PropertyInfo propertyInfo)
        {
            // Pega o Bind Attribute
            var bindAttribute = (IsBindAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(IsBindAttribute), false);

            // Define o nome que irá buscar dentro do Reader (Nome da coluna)
            if (bindAttribute != null)
            {
                return string.IsNullOrWhiteSpace(bindAttribute.Name) ? propertyInfo.Name : bindAttribute.Name;
            }

            return propertyInfo.Name;
        }

        public static bool IsBind(this PropertyInfo propertyInfo)
        {
            var bindAttribute = (IsBindAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(IsBindAttribute), false);

            return bindAttribute == null || bindAttribute.Bind;
        }

        public static bool IsId(this PropertyInfo propertyInfo)
        {
            var idAttribute = (IsIdAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(IsIdAttribute), false);

            return idAttribute != null && idAttribute.IsId;
        }
    }
}
