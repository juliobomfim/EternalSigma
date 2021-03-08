namespace Libs.CQRS.Interfaces
{
    public interface ICommandOutput
    {
        bool Success { get; set; }
        object Data { get; set; }
    }
}
