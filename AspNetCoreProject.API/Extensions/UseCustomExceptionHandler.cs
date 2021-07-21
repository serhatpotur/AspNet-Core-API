using AspNetCoreProject.API.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.API.Extensions
{
    public static class UseCustomExceptionHandler
    {
        //Extensions methotlar static olmalıdır
        public static void UseCustomException(this IApplicationBuilder app)
        {
            //Global düzeyde hataları ele almak
            app.UseExceptionHandler(config =>
            {
                //Herhangi bir hata fırladğı zaman Run methodunu çalıştıracak
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500; //server tarafında oluşanlar için hata kodu
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>(); // gelen hataları yakaladık

                    if (error != null)
                    {
                        var ex = error.Error;
                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });
        }
    }
}
