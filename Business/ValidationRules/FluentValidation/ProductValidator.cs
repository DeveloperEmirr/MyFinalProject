using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(p => p.ProductName).MinimumLength(2);//bu productnamenin minimmun 2 uzunlukta olmalı dedik 
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);// 0 dan büyük olmalı fiyatı

            //RuleFor(p => p.ProductName).Must(StrartWithA).WithMessage("Ürünler A Harfi İle Başlamalı");
            //must yardımı ile istediğimiz komutu kendimiz yazabiliriz.
        }

        //private bool StrartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
