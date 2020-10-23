using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishListService.Model
{
    public class WishList
    {
        public Guid WishListId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
