using Application.Messages.Dto;
using Core.Cqs;

namespace Application.Messages.Command;

public class UpdateCampaignCommand(UpdateCampaignRequestDto request, int id) : ICommand<bool>
{
    public int Id { get; set; } = id;
    public UpdateCampaignRequestDto Dto { get; set; } = request;
}