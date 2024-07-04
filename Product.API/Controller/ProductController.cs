using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controller;

public class ProductController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public ProductController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet]
    public IActionResult Get()
    {
        string result = $"【产品服务】{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}——" +
                        $"{Request.HttpContext.Connection.LocalIpAddress}:{_configuration["ConsulSetting:ServicePort"]}";
        return Ok(result);
    }
}