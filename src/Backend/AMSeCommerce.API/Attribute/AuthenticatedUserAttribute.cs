using AMSeCommerce.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Attribute;

public class AuthenticatedUserAttribute() : TypeFilterAttribute(typeof(AuthenticatedUserAttributeFilter));
    
