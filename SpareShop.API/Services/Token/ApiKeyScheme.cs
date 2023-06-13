using Microsoft.OpenApi.Models;

namespace SpareShop.API.Services.Token;

internal class ApiKeyScheme : OpenApiSecurityScheme
{
    public new string In { get; set; } = string.Empty;
    public new string Description { get; set; } = string.Empty;
    public new string Name { get; set; } = string.Empty;
    public new string Type { get; set; } = string.Empty;
}