using Archable.Application.Interfaces.Factories;
using Archable.Application.Mappers;
using Archable.Application.Models.Account;

namespace Archable.Application.Controllers
{
    public sealed class UserController
    {
        private readonly IUnitOfWorkFactory _factory;

        public UserController(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public void Add(NewUser newUser)
        {
            using var context = _factory.CreateUnitOfWork();

            var user = newUser.AdaptToUser();

            context.UserRepository.Add(user);
            context.Complete();
        }
    }
}