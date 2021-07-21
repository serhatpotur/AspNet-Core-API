using AspNetCoreProject.API.DTOs;
using AspNetCoreProject.Core.Entities;
using AspNetCoreProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        // Bu filter içinde bir DI(Dependency Injection) nesnesi (Interface) barındırdığı için bunu controller tarafında kullanamayız. Bu yüzden Startup.cs de tanımlayacağız
        private readonly IService<Product> _productService;
        public NotFoundFilter(IService<Product> service)
        {
            _productService = service;
        }

        //id isteyen Actionlar için kullanacağız
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                // null değilse gelen request devam etmeli
                await next(); //next ile gelen requesti bir sonra ki adıma aktarıyoruz
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;
                errorDto.Errors.Add($"id değeri {id} olan ürün veri tabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }

    }
}
