using AMSeCommerce.API.Attribute;
using AMSeCommerce.Application.UseCases.ShoppingCart;
using AMSeCommerce.Application.UseCases.ShoppingCart.AddItem;
using AMSeCommerce.Application.UseCases.ShoppingCart.Delete;
using AMSeCommerce.Application.UseCases.ShoppingCart.Get;
using AMSeCommerce.Communication.Request.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class ShoppingCartController : AmsEcommerceBaseController
{
   [HttpPost]
   [AuthenticatedUser]
   public async Task<IActionResult> AddItemToCart([FromServices] IAddItemToCartUseCase useCase, [FromBody] RequestAddItemToCartJson request)
   {
      await useCase.Execute(request);
      return NoContent();
   }
   [HttpGet]
   [AuthenticatedUser]
   public async Task<IActionResult> GetCart([FromServices] IGetCartUseCase useCase)
   {
      var products = await useCase.Execute();
      return Ok(products);
   }
   [HttpDelete("{id}")]
   [AuthenticatedUser]
   public async Task<IActionResult> RemoveProductToCart([FromServices] IRemoveProductToCartUseCase useCase,[FromRoute] long id)
   {
       await useCase.Execute(id);
      return NoContent();
   }
}