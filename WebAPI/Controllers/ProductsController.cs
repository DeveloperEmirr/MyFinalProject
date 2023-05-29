using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //insanlar bize nasıl ulaşssın diyor domain kısmına "localhost:44313/api/Products" gibi
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely Coupled  --- IoC Container=> Inversion Of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success == true)
            {
                return Ok(result);
                //burada dedikki ok 200 yani gönderme işlemi varsa
                //result dönder diyoruz
            }
            return BadRequest(result);
            //eğer sistem bakımda vs başka bişe varsa mesajı versin dedik
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

         [HttpGet("getall")]
        public IActionResult GetAll()
        {
            
            var result=_productService.GettAll();
            if (result.Success==true)
            {
                return Ok(result);
                //burada dedikki ok 200 yani gönderme işlemi varsa
                //result dönder diyoruz
            }
            return BadRequest(result);
            //eğer sistem bakımda vs başka bişe varsa mesajı versin dedik
        }
    }
}
