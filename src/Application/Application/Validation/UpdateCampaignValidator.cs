using Application.Messages.Command;
using FluentValidation;

namespace Application.Validation;

internal class UpdateCampaignValidator : AbstractValidator<UpdateCampaignCommand>
{
    public UpdateCampaignValidator()
    {
        RuleFor(x => x.Dto).NotNull().WithErrorCode("001")
            .WithMessage("Create Campaign Dto Boş Olamaz.");

        RuleFor(x => x.Id).NotNull()
            .WithErrorCode("006").WithMessage("Id boş olamaz.");

         
        //TODO: Error code ve mesajlar özelleştirilip kullanılmalı. 

    }
}