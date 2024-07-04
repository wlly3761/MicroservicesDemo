using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controller;

public class OrderController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public OrderController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet]
    public IActionResult Get()
    {
        string result = $"【订单服务】{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}——" +
                        $"{Request.HttpContext.Connection.LocalIpAddress}:{_configuration["ConsulSetting:ServicePort"]}";
        return Ok(result);
    }

   
}