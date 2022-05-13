namespace T_Bot
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
    }
}
