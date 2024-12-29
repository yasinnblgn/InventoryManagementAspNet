using InventoryManagementAspNet;
using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    // Razor View'de ürünleri listelemek için
    [HttpGet]
    public IActionResult Index()
    {
        var products = _repository.GetAll();
        return View(products);
    }

    // Ürün ekleme veya güncelleme işlemi için
    [HttpPost]
    public IActionResult Save(Product product)
    {
        if (product.Id == 0)
        {
            _repository.Add(product);
        }
        else
        {
            _repository.Update(product);
        }
        return RedirectToAction("Index");
    }

    // Ürün silme işlemi için
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _repository.Delete(id);
        return RedirectToAction("Index");
    }

    // API Endpointleri
    [HttpGet("api/products")]
    public IEnumerable<Product> GetAll() => _repository.GetAll();

    [HttpGet("api/products/{id}")]
    public IActionResult GetById(int id)
    {
        var product = _repository.GetById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost("api/products")]
    public IActionResult Add([FromBody] Product product)
    {
        _repository.Add(product);
        return Ok(product);
    }

    [HttpPut("api/products")]
    public IActionResult Update([FromBody] Product product)
    {
        _repository.Update(product);
        return Ok(product);
    }

    [HttpDelete("api/products/{id}")]
    public IActionResult DeleteApi(int id)
    {
        _repository.Delete(id);
        return Ok();
    }
}
