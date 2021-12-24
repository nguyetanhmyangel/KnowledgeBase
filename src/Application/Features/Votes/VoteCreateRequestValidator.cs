using FluentValidation;
using Infrastructure.Share.Wrapper;
using KnowledgeSpace.ViewModels.Contents;

namespace Application.Features.Votes
{
    public class VoteCreateRequestValidator : AbstractValidator<VoteCreateRequest>
    {
        public VoteCreateRequestValidator()
        {
            RuleFor(x => x.KnowledgeBaseId)
                .GreaterThan(0)
                .WithMessage(string.Format(Messages.Required, "Mã bài đăng"));
        }
    }
}