using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class EnsureSecurityCommand : IEncapsulateApplicationSpecificFunctionality
    {
        IEncapsulateApplicationSpecificFunctionality innerCommand;
        private ICanBeAssignedARole role;

        public EnsureSecurityCommand(
            IEncapsulateApplicationSpecificFunctionality innerCommand,
             ICanBeAssignedARole role)
        {
            this.innerCommand = innerCommand;
            this.role = role;
        }

        public void process(IContainRequestDetails request)
        {
            if (Thread.CurrentPrincipal.IsInRole(this.role.role))
            {
                innerCommand.process(request);
            }
            else
            {
                throw new SecurityException("Access denied!");
            }
            
        }
    }
}
