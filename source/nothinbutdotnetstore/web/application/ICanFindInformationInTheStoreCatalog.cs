using System.Collections.Generic;
using nothinbutdotnetstore.web.application.models;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public interface ICanFindInformationInTheStoreCatalog
    {
        IEnumerable<DepartmentModel> get_the_main_departments_in_the_store();
        IEnumerable<DepartmentModel> get_the_sub_departments_in(DepartmentModel parent_department);
        IEnumerable<ProductModel> get_the_products_in_department(DepartmentModel department);
    }
}