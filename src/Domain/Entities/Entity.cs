using System.Reflection;

namespace Archable.Domain.Entities
{
    public abstract class Entity
    {
        public object this[string propertyName]
        {
            get
            {
                Type myType = GetType();
                PropertyInfo myPropInfo = myType.GetProperty(propertyName)!;
                return myPropInfo.GetValue(this, null)!;
            }
            set
            {
                Type myType = GetType();
                PropertyInfo myPropInfo = myType.GetProperty(propertyName)!;
                myPropInfo.SetValue(this, value, null);
            }
        }

        public object Index => this["Id"];
    }
}