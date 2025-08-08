using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IServiceProviderService _providerService;

        public ProductsController(IProductService productService, IServiceProviderService providerService)
        {
            _productService = productService;
            _providerService = providerService;
        }

        public async Task<IActionResult> Index([FromQuery] ProductFilterVm filterVm)
        {
            filterVm ??= new ProductFilterVm();
            var providers = await _providerService.GetAllAsync();
            filterVm.Providers = providers.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();

            var products = await _productService.GetFilteredAsync(new ProductFilterDto(
                filterVm.MinPrice, filterVm.MaxPrice,
                filterVm.FromDate, filterVm.ToDate,
                filterVm.ServiceProviderId
            ));

            var vm = new ProductsIndexVm { Items = products, Filter = filterVm };
            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            var providers = await _providerService.GetAllAsync();
            var vm = new ProductCreateVm
            {
                Providers = providers.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                var providers = await _providerService.GetAllAsync();
                vm.Providers = providers.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });
                return View(vm);
            }

            var dto = new CreateProductDto(vm.Name, vm.Price, vm.CreationDate, vm.ServiceProviderId);
            await _productService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }

}



