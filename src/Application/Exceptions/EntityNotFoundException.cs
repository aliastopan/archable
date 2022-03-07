namespace Archable.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
            :base("Not Found: Entity.") { }

        public EntityNotFoundException(string message)
            :base(message) { }
    }
}