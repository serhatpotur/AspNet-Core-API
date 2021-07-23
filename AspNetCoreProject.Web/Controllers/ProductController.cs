using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreProject.Web.ApiService;
using AspNetCoreProject.Web.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly IMapper _mapper;

        public ProductController(ProductApiService productApiService, IMapper mapper)
        {
            _productApiService = productApiService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _productApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ProductDto>>(product));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productApiService.AddAsync(productDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _productApiService.Update(productDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
