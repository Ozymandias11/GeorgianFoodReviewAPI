using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
   public static class RepositoryFoodExtensions
    {
        public static IQueryable<Food> Search(this IQueryable<Food> foods, string searchTerm) 
        {
            if(string.IsNullOrEmpty(searchTerm))
                return foods;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return foods.Where(f => f.Name.ToLower().Contains(lowerCaseTerm));

        } 


        public static IQueryable<Food> Sort(this IQueryable<Food> foods, string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
                return foods.OrderBy(f => f.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Food>(orderByQueryString);

            if (string.IsNullOrEmpty(orderQuery))
                return foods.OrderBy(f => f.Name);

            return foods.OrderBy(orderQuery);


        }



    }
}
