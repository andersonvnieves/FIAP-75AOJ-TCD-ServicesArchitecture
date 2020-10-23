using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WishListService.Model;
using WishListService.Persistence.Repositories;

namespace WishListService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly WishListRepository _wishListRepository;

        public WishListController(WishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        [HttpPost]
        public IActionResult Post(WishList data)
        {
            try
            {
                _wishListRepository.Insert(data);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]

        public IActionResult WishListByUserId(Guid userId)
        {
            try
            {
                return Ok(_wishListRepository.ListByUserId(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}
