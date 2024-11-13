using AMSeCommerce.Application.UseCases.ShoppingCart;
using AMSeCommerce.Communication.Request.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class ShoppingCartController : AmsEcommerceBaseController
{
   [HttpPost]
   public async Task<IActionResult> AddItemToCart([FromServices] IAddItemToCartUseCase useCase, [FromBody] RequestAddItemToCartJson request)
   {
      await useCase.Execute(request);
      return NoContent();
   }
}