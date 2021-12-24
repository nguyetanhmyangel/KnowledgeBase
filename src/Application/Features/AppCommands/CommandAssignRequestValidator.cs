using FluentValidation;
using Infrastructure.Share.Wrapper;

namespace Application.Features.AppCommands
{
    public class CommandAssignRequestValidator : AbstractValidator<CommandAssignRequest>
    {
        public CommandAssignRequestValidator()
        {
            RuleFor(x => x.CommandIds).NotNull()
                .WithMessage(string.Format(Messages.Required, "Command"));

            RuleFor(x => x.CommandIds).Must(x => x.Length > 0)
                .When(x => true)
                .WithMessage("Danh sách Command phải có ít nhất 1 phần tử");

            RuleForEach(x => x.CommandIds).NotEmpty()
                .WithMessage("Danh sách Command không được chứa phần tử rỗng");
        }
    }
}