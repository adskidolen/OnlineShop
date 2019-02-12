namespace KeepHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using KeepHome.Services.Contracts;
    using KeepHome.Web.Controllers.Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;

    public class PaymentsController : BaseController
    {
        private const string PATH_CONFIRMATION_ORDER_EMAIL = "Views/EmailTemplates/ConfirmOrder.cshtml";
        private const string PAYMENT_STATUS_ERROR = "INVOICE={0}:STATUS=ERR\n";
        private const string PAYMENT_STATUS_OK = "INVOICE={0}:STATUS=OK\n";
        private const string PAYMENT_STATUS_NO = "INVOICE={0}:STATUS=NO\n";
        private const string REGISTERED_ORDER = "Регистрирана поръчка #{0}";
        private const string YOUR_ORDER_WAS_SUCCESSFULLY_RECEIVED = "Вашата поръчка беше получена успешно!";
        private const string YOUR_ORDER_WAS_UNSUCCESSFULLY_PAID = "Вашата поръчка не беше платена успешно!";
        private const string INVALID_ORDER = "Невалидна поръчка!";

        private const string SUBMIT_URL_DEMO = "https://devep2.datamax.bg/ep2/epay2_demo/";
        private const string SUBMIT_URL = "https://www.epay.bg/";

        private readonly IOrderService ordersService;
        private readonly IPaymentsService paymentService;
        private readonly IUserService usersService;
        private readonly IMapper mapper;

        public PaymentsController(IOrderService ordersService, IPaymentsService paymentService,
            IUserService usersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.paymentService = paymentService;
            this.usersService = usersService;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult SuccessfulPayment(int id)
        {
            var order = this.ordersService.GetOrderById(id);
            if (order == null)
            {
                this.TempData["info"] = INVALID_ORDER;

                return this.RedirectToAction("Index", "Home");
            }

            this.TempData["info"] = YOUR_ORDER_WAS_SUCCESSFULLY_RECEIVED;

            return this.RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult UnsuccessfulPayment(int id)
        {
            this.TempData["info"] = YOUR_ORDER_WAS_UNSUCCESSFULLY_PAID;

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult PaymentStatus(string encoded, string checksum)
        {
            string encodedData = this.paymentService.GetDencodedData(encoded, checksum);

            if (encodedData == null)
            {
                return Content(string.Format(PAYMENT_STATUS_ERROR, string.Empty));
            }

            var data = encodedData.Split(":");

            var invoiceKeyValue = data.FirstOrDefault(x => x.Contains("INVOICE"));
            var paymentStatusKeyValue = data.FirstOrDefault(x => x.Contains("STATUS"));

            if (invoiceKeyValue == null || paymentStatusKeyValue == null)
            {
                return Content(string.Format(PAYMENT_STATUS_ERROR, string.Empty));
            }

            var invoice = invoiceKeyValue.Split("=").Last();
            var status = paymentStatusKeyValue.Split("=").Last();

            bool isStatusSet = ordersService.SetOrderStatusByInvoice(invoice, status);
            if (!isStatusSet)
            {
                return Content(string.Format(PAYMENT_STATUS_ERROR, invoice));
            }

            return Content(string.Format(PAYMENT_STATUS_OK, invoice));
        }
    }
}