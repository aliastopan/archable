namespace Archable.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
            :base("Not Found: ENTITY exception.") { }

        public EntityNotFoundException(string message)
            :base(message) { }
    }
}