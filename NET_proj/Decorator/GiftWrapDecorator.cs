using NET_proj.Data;

namespace NET_proj.Decorator
{
    class GiftWrapDecorator : ProductDecorator
    {
        public GiftWrapDecorator(Product product) : base(product) { Price += 20; }
        public override string GetDetails() => _product.GetDetails() + " (Gift Wrapped +20 грн)";
    }
}
