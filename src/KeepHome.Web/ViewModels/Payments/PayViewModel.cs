namespace KeepHome.Web.ViewModels.Payments
{
    using KeepHome.Models.Enums;

    public class PayViewModel
    {
        public string Encoded { get; set; }

        public string SubmitUrl { get; set; }

        public string ChechSum { get; set; }

        public PaymentType PaymentType { get; set; }

        public string UrlOk { get; set; }

        public string UrlCancel { get; set; }

        public string EasyPayNumber { get; set; }
    }
}