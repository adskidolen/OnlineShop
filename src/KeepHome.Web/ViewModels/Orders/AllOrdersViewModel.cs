namespace KeepHome.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class AllOrdersViewModel
    {
        private const string NoOrdersMessage = "Все още нямате направени поръчки.";
        public string ShowNoOrdersMessage => NoOrdersMessage;

        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}