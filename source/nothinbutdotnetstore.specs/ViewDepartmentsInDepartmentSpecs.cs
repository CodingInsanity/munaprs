using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    public class ViewDepartmentsInDepartmentSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            ViewTheDepartmentsInADepartment>
        {
        }

        [Subject(typeof(ViewTheDepartmentsInADepartment))]
        public class when_run : concern
        {
            private Establish e = () =>
                                      {
                                          currentDepartment = new DepartmentModel();
                                          request_details = fake.an<IContainRequestDetails>();
                                          response_engine = depends.on<ICanDisplayReportModels>();
                                          reporting_gateway = depends.on<ICanFindInformationInTheStoreCatalog>();
                                          reporting_gateway.setup(x => x.get_child_departments).Return(childDepartments);


                                      };

            private It should_tell_the_display_engine_to_display_the_departments_of_the_given_department = () => response_engine.received(x => x.display(childDepartments));

            static ICanDisplayReportModels response_engine;
            static IContainRequestDetails request_details;
            static ICanFindInformationInTheStoreCatalog reporting_gateway;
            
            private static IEnumerable<DepartmentModel> childDepartments;
            private static DepartmentModel currentDepartment;
        }
    }
}