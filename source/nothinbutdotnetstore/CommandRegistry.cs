using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore {
    public class CommandRegistry : ICanFindCommandsThatCanProcessRequests {
        
        readonly IEnumerable<ICanProcessOneUniqueRequest> all_commands;
        private MissingCommandFactory missing_command_factory;

        public CommandRegistry(IEnumerable<ICanProcessOneUniqueRequest> allCommands, MissingCommandFactory missing_command_factory) {
            this.all_commands = allCommands;
            this.missing_command_factory = missing_command_factory;
        }

        public ICanProcessOneUniqueRequest get_the_command_that_can_handle(IContainRequestDetails request) {
            var result = all_commands.FirstOrDefault(x => x.can_process(request));
            return result ?? missing_command_factory();
        }
    }
}