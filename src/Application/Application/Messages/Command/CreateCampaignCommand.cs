using Application.Messages.Dto;
using Core.Cqs;

namespace Application.Messages.Command;

public class CreateCampaignCommand(CreateCampaignRequestDto request) : ICommand<bool>
{
    public CreateCampaignRequestDto Dto { get; set; } = request;
}