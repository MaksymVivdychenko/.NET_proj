using NET_proj.Data;

namespace NET_proj.Decorator
{
    class GiftWrapDecorator : ProductDecorator
    {
        public GiftWrapDecorator(Product product) : base(product) { _product.Price += 3; }
        public override string GetDetails() => _product.GetDetails() + " (Gift Wrapped +3 грн)";
    }
}
