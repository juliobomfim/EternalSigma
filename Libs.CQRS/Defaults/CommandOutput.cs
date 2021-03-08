using Libs.CQRS.Interfaces;

namespace Libs.CQRS.Defaults
{
    public class CommandOutput : ICommandOutput
    {
        public CommandOutput() { }

        public CommandOutput(bool success, params string[] messages)
        {
            Success = success;
            Messages = messages;
        }

        public CommandOutput(object data, bool success, params string[] messages)
        {
            Data = data;
            Success = success;
            Messages = messages;
        }

        public object Data { get; set; }
        public bool Success { get; set; }
        public string[] Messages { get; set; }

        public static ICommandOutput Ok(params string[] messages) => new CommandOutput(true, messages);

        public static ICommandOutput Ok(object data, params string[] messages) => new CommandOutput(data, true, messages);

        public static ICommandOutput Failure(params string[] messages) => new CommandOutput(false, messages);

        public static ICommandOutput Failure(object data, params string[] messages) => new CommandOutput(data, false, messages);

    }
}
