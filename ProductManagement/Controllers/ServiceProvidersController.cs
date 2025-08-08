using Application.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    namespace WebApp.Controllers
    {
        public class ServiceProvidersController : Controller
        {
            private readonly IServiceProviderService _service;

            public ServiceProvidersController(IServiceProviderService service) => _service = service;

            // GET: /ServiceProviders
            public async Task<IActionResult> Index()
            {
                var providers = await _service.GetAllAsync();
                return View(providers);
            }

            // GET: /ServiceProviders/Create
            public IActionResult Create() => View();

            // POST: /ServiceProviders/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(ServiceProviders model)
            {
                if (!ModelState.IsValid) return View(model);
                await _service.CreateAsync(model.Name, model.ContactNumber, model.Email);
                return RedirectToAction(nameof(Index));
            }
        }
    }

    ////public class ProductsController : Controller
    ////{
    ////    private readonly IProductService _productService;
    ////    private readonly IServiceProviderService _providerService;

    ////    public ProductsController(IProductService productService, IServiceProviderService providerService)
    ////    {
    ////        _productService = productService;
    ////        _providerService = providerService;
    ////    }

    ////    public async Task<IActionResult> Index(decimal? minPrice, decimal? maxPrice, DateTime? fromDate, DateTime? toDate, int? providerId)
    ////    {
    ////        ViewBag.Providers = new SelectList(await _providerService.GetAllAsync(), "Id", "Name");
    ////        var filter = new ProductFilterDto(minPrice, maxPrice, fromDate, toDate, providerId);
    ////        var products = await _productService.GetFilteredAsync(filter);
    ////        return View(products);
    ////    }

    ////    public async Task<IActionResult> Create()
    ////    {
    ////        ViewBag.Providers = new SelectList(await _providerService.GetAllAsync(), "Id", "Name");
    ////        return View();
    ////    }

    ////    [HttpPost]
    ////    public async Task<IActionResult> Create(CreateProductDto dto)
    ////    {
    ////        if (!ModelState.IsValid)
    ////        {
    ////            ViewBag.Providers = new SelectList(await _providerService.GetAllAsync(), "Id", "Name");
    ////            return View(dto);
    ////        }

    ////        await _productService.CreateAsync(dto);
    ////        return RedirectToAction(nameof(Index));
    ////    }
    ////}

    ////    public class ProductsController : Controller
    ////    {
    ////        private readonly IProductService _productService;
    ////        private readonly IServiceProviderService _providerService;

    ////        public ProductsController(IProductService productService, IServiceProviderService providerService)
    ////        {
    ////            _productService = productService;
    ////            _providerService = providerService;
    ////        }

    ////        // GET: /Products/Create
    ////        public async Task<IActionResult> Create()
    ////        {
    ////            var providers = await _providerService.GetAllAsync();
    ////            var vm = new ProductCreateVm
    ////            {
    ////                Providers = providers.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
    ////            };
    ////            return View(vm);
    ////        }

    ////        // POST: /Products/Create
    ////        [HttpPost]
    ////        public async Task<IActionResult> Create(ProductCreateVm vm)
    ////        {
    ////            if (!ModelState.IsValid)
    ////            {
    ////                var providers = await _providerService.GetAllAsync();
    ////                vm.Providers = providers.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });
    ////                return View(vm);
    ////            }

    ////            var dto = new CreateProductDto(vm.Name, vm.Price, vm.CreationDate, vm.ServiceProviderId);
    ////            await _productService.CreateAsync(dto);
    ////            return RedirectToAction(nameof(Index));
    ////        }

    ////        // GET: /Products?MinPrice=&MaxPrice=&FromDate=&ToDate=&ServiceProviderId=
    ////        public async Task<IActionResult> Index(ProductFilterVm filterVm)
    ////        {
    ////            var providers = await _providerService.GetAllAsync();
    ////            filterVm.Providers = providers.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });

    ////            var filterDto = new ProductFilterDto(
    ////                filterVm.MinPrice, filterVm.MaxPrice, filterVm.FromDate, filterVm.ToDate, filterVm.ServiceProviderId
    ////            );

    ////            var products = await _productService.GetFilteredAsync(filterDto);

    ////            // خيارين:
    ////            // 1) مرّر المنتجات كنموذج وابعث الـfilterVm عبر ViewBag
    ////            ViewBag.FilterVm = filterVm;
    ////            return View(products);

    ////            // 2) أو أنشئ Composite VM: ProductsIndexVm { IEnumerable<ProductDto> Items; ProductFilterVm Filter; }
    ////            // وارسله للـ View بدل السطرين فوق (اختياري).
    ////        }
    ////    }
    ////}
    //public class ServiceProvidersController : Controller
    //{
    //    private readonly IServiceProviderRepository _repository;

    //    public ServiceProvidersController(IServiceProviderRepository repo) => _repository = repo;

    //    public async Task<IActionResult> Index() => View(await _repository.GetAll());

    //    public IActionResult Create() => View();

    //    [HttpPost]
    //    public async Task<IActionResult> Create(ServiceProviders provider)
    //    {
    //        if (!ModelState.IsValid) return View(provider);
    //        await _repository.Add(provider);
    //        return RedirectToAction("Index");
    //    }
    //}

}