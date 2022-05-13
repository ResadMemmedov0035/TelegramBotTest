using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Bot
{
    public static class SubscriptionPlanInMemoryDb
    {
        public static List<SubscriptionPlan> GetAll()
        {
            return new List<SubscriptionPlan>
            {
                new SubscriptionPlan
                {
                    Id = 1,
                    Title = "1 Month Subscription",
                    Details = "Some details about 1 month subscription which is not important.",
                    Price = 9.99M,
                    Currency = "AZN"
                },
                new SubscriptionPlan
                {
                    Id = 2,
                    Title = "3 Month Subscription",
                    Details = "Some details about 3 month subscription which is not important.",
                    Price = 26.99M,
                    Currency = "AZN"
                }
            };
        }
    }
}
