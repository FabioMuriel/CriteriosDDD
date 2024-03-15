namespace CriteriosDominio.Dominio.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateEntity<T>(T entity)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(entity);
                    if (string.IsNullOrEmpty(value as string))
                    {
                        throw new Exception($"El campo {property.Name} no puede ser nulo o vacio");
                    }
                }
                if (property.PropertyType == typeof(int))
                {
                    var value = property.GetValue(entity);
                    if ((int)value <= 0)
                    {
                        throw new Exception($"El campo {property.Name} no puede ser menor o igual a 0");
                    }
                }
            }
        }
    }
}