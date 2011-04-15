using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.core;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class EnsureSecurityCommandSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            EnsureSecurityCommand>
        {
        }

        [Subject(typeof(EnsureSecurityCommand))]
        public class when_run_command_with_principal_in_authorized_role : concern
        {
            Establish c = () =>
            {
                the_request = fake.an<IContainRequestDetails>();
                role = fake.an<ICanBeAssignedARole>();
                role.setup(x => x.role).Return("admin");
                inner_command = depends.on<IEncapsulateApplicationSpecificFunctionality>();
                depends.on<ICanBeAssignedARole>(role);
                authorized_prinicpal = new GenericPrincipal(new GenericIdentity("authorized"), new string[]
                {
                    "admin"
                });
                spec.change(() => Thread.CurrentPrincipal).to(authorized_prinicpal);
                
            };

            Because of = () => sut.process(the_request);

            It executes_the_command =
                () => inner_command.received(x => x.process(the_request));
            
            static IEncapsulateApplicationSpecificFunctionality inner_command;
            static IContainRequestDetails the_request;
            private static ICanBeAssignedARole role;
            private static IPrincipal authorized_prinicpal;
        }

        [Subject(typeof(EnsureSecurityCommand))]
        public class when_run_command_with_principal_in_non_authorized_role : concern
        {
            Establish c = () =>
            {
                the_request = fake.an<IContainRequestDetails>();
                inner_command = depends.on<IEncapsulateApplicationSpecificFunctionality>();
                non_authorized_prinicpal = new GenericPrincipal(new GenericIdentity("non_authorized"), new string[]
                {
                    "bla"
                });
                spec.change(() => Thread.CurrentPrincipal).to(non_authorized_prinicpal);

            };

            Because of = () => sut.process(the_request);

            private It throws_security_exception =
                () => new SecurityException();

            static IEncapsulateApplicationSpecificFunctionality inner_command;
            static IContainRequestDetails the_request;
            private static IPrincipal non_authorized_prinicpal;
        }
    }
}
