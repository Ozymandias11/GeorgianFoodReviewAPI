using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryReviewExtension
    {

        public static IQueryable<Review> Sort(this IQueryable<Review> reviews, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return reviews.OrderBy(r => r.Title);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Review>(orderByQueryString);

            if (string.IsNullOrEmpty(orderQuery))
                return reviews.OrderBy(r => r.Title);

            return reviews.OrderBy(orderQuery);


        }
    }
}
