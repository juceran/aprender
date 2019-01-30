namespace aprender.Entities.Aula196Class
{
    interface IOnlinePaymentService
    {

        double PaymentFee(double amount);
        double Interest(double amount, int months);
    }
}
