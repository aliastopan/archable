using FluentValidation;
using Archable.Application.Interfaces.Factories;
using Archable.Application.Models.Account;

namespace Archable.Application.Validators
{
    public sealed class NewUserValidator : AbstractValidator<NewUser>
    {
        private readonly IUnitOfWorkFactory _factory;

        private int _minUsernameLength = 2;
        private int _maxUsernameLength = 16;
        private int _minPasswordLength = 8;

        public NewUserValidator(IUnitOfWorkFactory factory)
        {
            _factory = factory;

            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("username is required.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("password is required.");

            When(user => !string.IsNullOrWhiteSpace(user.Username), () => {

                RuleFor(user => user.Username)
                    .MinimumLength(_minUsernameLength).WithMessage($"username must at least {_minUsernameLength} characters.")
                    .MaximumLength(_maxUsernameLength).WithMessage($"username cannot exceed {_maxUsernameLength} characters.")
                    .Must(Available).WithMessage("username is already taken.");

            });

            When(user => !string.IsNullOrWhiteSpace(user.Password), () => {

                RuleFor(user => user.Password)
                    .MinimumLength(_minPasswordLength).WithMessage($"password must at least {_minPasswordLength} characters.");

                RuleFor(user => user.ConfirmPassword)
                    .Equal(user => user.Password).WithMessage("password doesn't match.");

            });

        }

        private bool Available(string username)
        {
            using var context = _factory.CreateUnitOfWork();

            var result = context.UserRepository.LookUp(username);
            var isAvaiable = result.Value is null;

            return isAvaiable;
        }
    }
}