using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{

    public class ServiceProvidersController : Controller
    {
        private readonly IServiceProviderService _service;
        private readonly IMapper _mapper;

        public ServiceProvidersController(IServiceProviderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync(); // يفضّل أن يرجع AsNoTracking من داخل الخدمة
            var vms = _mapper.Map<List<ServiceProviderVm>>(list);
            return View(vms);
        }

        [HttpGet]
        public IActionResult Create() => View(new ServiceProviderCreateVm());

        [HttpPost]
        public async Task<IActionResult> Create(ServiceProviderCreateVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            try
            {
                var dto = _mapper.Map<CreateServiceProviderDto>(vm);
                await _service.CreateAsync(dto);

                TempData["Success"] = "Added Successfuly";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
        }
    }

}

