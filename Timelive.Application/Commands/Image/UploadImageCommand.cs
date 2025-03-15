using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Image;

public record class UploadImageCommand(string File) : ICommand<int>
{

}
