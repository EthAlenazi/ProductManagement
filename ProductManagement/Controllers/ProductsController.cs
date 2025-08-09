using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IServiceProviderService _providerService;
        private IMapper _mapper;

        public ProductsController(IProductService productService, IServiceProviderService providerService, IMapper mapper)
        {
            _productService = productService;
            _providerService = providerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index([FromQuery] ProductFilterVm filterVm)
        {
            filterVm ??= new ProductFilterVm();

            var providers = await _providerService.GetAllAsync();

            filterVm.Providers = _mapper.Map<List<SelectListItem>>(providers);
            var filterdata = _mapper.Map<ProductFilterDto>(filterVm);
            var products = await _productService.GetFilteredAsync(filterdata);


            var vm = _mapper.Map<ProductsIndexVm>((products, filterVm));
            
            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            var providers = await _providerService.GetAllAsync();
            var vm = new ProductCreateVm
            {
                Providers = providers.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList()
            };
            return View(vm);
        }

     
        private async Task PopulateProvidersAsync(ProductCreateVm vm)
        {
            var providers = await _providerService.GetAllAsync();
            vm.Providers = _mapper.Map<List<SelectListItem>>(providers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateProvidersAsync(vm);
                return View(vm);
            }
        

            var dto = new CreateProductDto(
                vm.Name,
                vm.Price,
                vm.CreationDate,
                vm.ServiceProviderName,
                vm.ServiceProviderId
            );

            try
            {
                await _productService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await PopulateProvidersAsync(vm);
                return View(vm);
            }
        }
    }
}







