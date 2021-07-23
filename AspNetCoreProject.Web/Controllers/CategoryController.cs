using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreProject.Web.ApiService;
using AspNetCoreProject.Web.DTOs;
using AspNetCoreProject.Web.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        /*Api katmanı eklediğimiz için artık Service katmanı ile haberleşmiyoruz. Bu alana artık gerek yok
                 private readonly ICategoryService _categoryService; 
        */
        private readonly IMapper _mapper;
        private readonly CategoryApiService _categoryApiService;
        public CategoryController(IMapper mapper, CategoryApiService categoryApiService)
        {
            
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            // CategoryApiService sayesinde artık Api ile haberleşiyor
            var categories = await _categoryApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
