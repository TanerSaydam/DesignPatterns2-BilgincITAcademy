Console.WriteLine("Facade Pattern");

var shopService = new ShopFacade();
shopService.PlaceOrder("Bilgisayar", "Taner Saydam", "4444", "Kayseri");

Console.ReadLine();

class ProductService
{
    public bool HaveStock(string productName)
    {
        Console.WriteLine("[Inventory] Checking stock for product {0}", productName);
        return true;
    }
}

class PaymentService
{
    public bool ProcessingPayment(string customer, string cardNumber)
    {
        Console.WriteLine("[Payment] Processing payment for customer {0} - card number {1}", customer, cardNumber);
        return true;
    }
}

class DeliveryService
{
    public void ScheduleDelivery(string productName, string address)
    {
        Console.WriteLine("[Delivery] Schedule delivery for {0} to {1}", productName, address);
    }
}

class ShopFacade
{
    ProductService productService = new();
    PaymentService paymentService = new();
    DeliveryService deliveryService = new();
    public void PlaceOrder(string productName, string customer, string cardNumber, string address)
    {
        var haveStock = productService.HaveStock(productName);
        if (!haveStock)
        {
            Console.WriteLine("Product {0} is out of stock", productName);
            return;
        }

        var payResult = paymentService.ProcessingPayment(customer, cardNumber);
        if (!payResult)
        {
            Console.WriteLine("Payment failed for {0}", customer);
            return;
        }

        deliveryService.ScheduleDelivery(productName, address);
        Console.WriteLine("Order completed successfully");
    }
}