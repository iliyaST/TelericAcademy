using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ProjectManager.CLI.Common
{
    public class Validator
    {
        public void Validate<T>(T obj) where T : class
        {
            var errors = this.GetValidationErrors(obj);

            if (errors.Count() != 0)
            {
                throw new UserValidationException(errors.First());
            }
        }

        public IEnumerable<string> GetValidationErrors(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] propertieInfos = type.GetProperties();
            Type attributeType = typeof(ValidationAttribute);

            foreach (var propertyInfo in propertieInfos)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attributeType, inherit: true);
                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;
                    bool valid = validationAttribute.IsValid(propertyInfo.GetValue(obj, BindingFlags.GetProperty, null, null, null));

                    if (!valid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
}
