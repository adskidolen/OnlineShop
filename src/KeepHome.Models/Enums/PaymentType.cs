namespace KeepHome.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum PaymentType
    {
        [Display(Name = "ePay.bg")]
        Epay = 1,

        [Display(Name = "В брой (Изипей)")]
        EasyPay = 2,

        [Display(Name = "Наложен платеж")]
        CashОnDelivery = 3,

        [Display(Name = "Visa, MasterCard и др.")]
        Card = 4
    }
}