using System;
using System.Threading;
using System.Threading.Tasks;
using Rebar.Core.Command;

namespace sample.Commands
{
    public class SampleCommandHandler : ICommandHandler<SampleCommand>
    {

        public async Task ExecuteAsync(SampleCommand command, CancellationToken token)
        {
            await Task.Run(() =>
            {
                var name = command.Name; //name = Bob
            });
        }
    }
}
