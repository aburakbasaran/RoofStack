using Application.Messages.Command;
using FluentValidation;

namespace Application.Validation;

internal class CreateCampaignValidator : AbstractValidator<CreateCampaignCommand>
{
    public CreateCampaignValidator()
    {
        RuleFor(x => x.Dto).NotNull().WithErrorCode("001")
            .WithMessage("Create Campaign Dto Boş Olamaz.");

        RuleFor(x => x.Dto.Title).NotNull()
            .WithErrorCode("002").WithMessage("Title boş olamaz.");

        RuleFor(x => x.Dto.Description).NotNull()
            .WithErrorCode("003").WithMessage("Description boş olamaz.");

        RuleFor(x => x.Dto.StartDate).NotNull()
            .WithErrorCode("004").WithMessage("StartDate boş olamaz.");

        RuleFor(x => x.Dto.EndDate).NotNull()
            .WithErrorCode("005").WithMessage("EndDate boş olamaz.");
    }
}