using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using System.Text;
using VerstaTestTask.Domain.Models;
using VerstaTestTask.Models;
using VerstaTestTask.Services;

namespace VerstaTestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;

        }

       
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _orderService.GetOrders();
            if (response.StatusCode == 200)
            {
                return View("OrdersList", response.Data);
            }
            return View("Error", new ErrorViewModel { StatusCode = response.StatusCode, Message = response.Description});

        }
        [HttpGet]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var response = await _orderService.GetOrder(id);
            if (response.StatusCode == 200)
            {
                return View(response.Data);
            }
            return View("Error", new ErrorViewModel { StatusCode = response.StatusCode, Message = response.Description });
        }
        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrderPost(Order order)
        {

            var response = await _orderService.CreateOrder(order);
            if (response.StatusCode == 201)
            {
                return RedirectToAction("Index");
            }
            return View("Error", new ErrorViewModel { StatusCode = response.StatusCode, Message = response.Description });
             
        }
    }
}
