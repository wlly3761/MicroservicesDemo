namespace Web.MVC.Helper;

public class ServiceHelper : IServiceHelper
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceHelper(IHttpClientFactory httpClientFactory)
    {        
        _httpClientFactory = httpClientFactory;
    }
    public async Task<string> GetOrder()
    {
        string serviceUrl = "http://localhost:9060";//订单服务的地址，可以放在配置文件或者数据库等等...
       var client =  _httpClientFactory.CreateClient();
       client.BaseAddress = new Uri(serviceUrl);
        var response = await client.GetAsync("/orders");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetProduct()
    {
        string serviceUrl = "http://localhost:9050";//产品服务的地址，可以放在配置文件或者数据库等等...

        var client =  _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(serviceUrl);
        var response = await client.GetAsync("/products");
        return await response.Content.ReadAsStringAsync();
    }
}
