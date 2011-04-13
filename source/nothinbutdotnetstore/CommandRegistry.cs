using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore
{
    public class CommandRegistry : ICanFindCommandsThatCanProcessRequests
    {
        private IEnumerable<ICanProcessOneUniqueRequest> listOfAllCommands;

        public CommandRegistry(IEnumerable<ICanProcessOneUniqueRequest> listOfAllCommands)
        {
            this.listOfAllCommands = listOfAllCommands;
        }

        public ICanProcessOneUniqueRequest get_the_command_that_can_handle(IContainRequestDetails request)
        {
            return this.listOfAllCommands.ToList().FirstOrDefault(x => x.can_process(request));
        }
    }
}