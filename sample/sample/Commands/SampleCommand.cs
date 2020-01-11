using Rebar.Core.Command;

namespace sample.Commands
{
    public class SampleCommand : ICommand
    {
        public string Name { get; set; }

        public SampleCommand(string name)
        {
            this.Name = name;
        }
    }
}
