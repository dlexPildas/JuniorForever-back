using FluentValidation;
using JuniorForever.Domain.Models;

namespace JuniorForever.Api.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.AvatarUrl)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Bio)
                .NotEmpty()
                .NotNull();
        }
    }
}
