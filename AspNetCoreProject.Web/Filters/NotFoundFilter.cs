using AspNetCoreProject.Web.ApiService;
using AspNetCoreProject.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Web.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        /*Api katmanı eklediğimiz için artık Service katmanı ile haberleşmiyoruz.Bu alana artık gerek yok
              private readonly ICategoryService _categoryService; 
        */

        // Bu filter içinde bir DI(Dependency Injection) nesnesi (Interface) barındırdığı için bunu controller tarafında kullanamayız. Bu yüzden Startup.cs de tanımlayacağız
        private readonly CategoryApiService _categoryApiService;

        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        //id isteyen Actionlar için kullanacağız
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _categoryApiService.GetByIdAsync(id);
            if (product != null)
            {
                // null değilse gelen request devam etmeli
                await next(); //next ile gelen requesti bir sonra ki adıma aktarıyoruz
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Errors.Add($"id değeri {id} olan kategori veri tabanında bulunamadı");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }

    }
}
