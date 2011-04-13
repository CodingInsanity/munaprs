using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore
{
    public class CommandRegistry : ICanFindCommandsThatCanProcessRequests
    {
        IEnumerable<ICanProcessOneUniqueRequest> all_commands;
        MissingCommandFactory missing_command_factory;

        public CommandRegistry(IEnumerable<ICanProcessOneUniqueRequest> all_commands,
                               MissingCommandFactory missingCommandFactory)
        {
            this.all_commands = all_commands;
            this.missing_command_factory = missingCommandFactory;
        }

        public ICanProcessOneUniqueRequest get_the_command_that_can_handle(IContainRequestDetails request)
        {
            return all_commands.FirstOrDefault(x => x.can_process(request)) ?? missing_command_factory();
        }
    }
}