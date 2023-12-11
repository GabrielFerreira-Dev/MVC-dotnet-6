using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Models;
using SalesWebMVC.Services;
using NuGet.Protocol.Plugins;

namespace SalesWebMVC.Controllers {
    public class SalesRecordsController : Controller {
        private readonly SalesRecordService _salesRecordService;
        private readonly SellerService _sellerService;
        public SalesRecordsController(SalesRecordService salesRecordService, SellerService sellerService) {
            _salesRecordService = salesRecordService;
            _sellerService = sellerService;
        }
        public ActionResult Index() {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate) {
            if (!minDate.HasValue) {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue) {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateGroupAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> Create() {
            var sellers = await _sellerService.FindAllAsync();
            var viewModel = new SalesFormViewModel { Sellers = sellers };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesRecord, SalesStatus")] SalesFormViewModel salesFormView) {
            salesFormView.SalesRecord.Date = DateTime.Now;
            if (!ModelState.IsValid) {
                var sellers = await _sellerService.FindAllAsync();
                var viewModel = new SalesFormViewModel { Sellers = sellers, SalesRecord = salesFormView.SalesRecord };
                return View(viewModel);
            }
            await _salesRecordService.InsertAsync(salesFormView.SalesRecord);
            return RedirectToAction(nameof(Index));
        }
    }
}
