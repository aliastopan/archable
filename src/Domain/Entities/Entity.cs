#nullable disable

namespace Archable.Domain.Entities
{
    public abstract class Entity
    {
        public object this[string propertyName]
        {
            get => GetValue(propertyName);
            set => SetValue(propertyName, value);
        }

        public object Index => this["Id"];

        private object GetValue(string propertyName)
        {
            var propertyType = GetType();
            var propertyInfo = propertyType.GetProperty(propertyName);

            return propertyInfo.GetValue(this, null);
        }

        private void SetValue(string propertyName, object value)
        {
            var propertyType = GetType();
            var propertyInfo = propertyType.GetProperty(propertyName);
            propertyInfo.SetValue(this, value, null);
        }
    }
}