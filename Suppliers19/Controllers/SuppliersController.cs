using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Suppliers19;

[ApiController]
[Route("api/suppliers")]
public class SuppliersController : ControllerBase
{
    private readonly SupplierStore store;
    private readonly IMapper mapper;

    public SuppliersController(SupplierStore store, IMapper mapper)
    {
        this.store = store;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<List<SupplierDto>> GetAll()
    {
        lock (store.SyncRoot)
        {
            return Ok(mapper.Map<List<SupplierDto>>(store.Suppliers));
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<SupplierDto> GetById(int id)
    {
        lock (store.SyncRoot)
        {
            Supplier? supplier = store.Suppliers.Find(s => s.Id == id);
            if (supplier == null)
                return NotFound();

            return Ok(mapper.Map<SupplierDto>(supplier));
        }
    }

    [HttpPost]
    public ActionResult<SupplierDto> Create(SupplierDto dto)
    {
        if (dto.StartDate == default)
            return BadRequest("Вкажіть дату початку співпраці.");

        lock (store.SyncRoot)
        {
            Supplier supplier = mapper.Map<Supplier>(dto);
            supplier.Id = store.NextId++;
            store.Suppliers.Add(supplier);
            return CreatedAtAction(nameof(GetById), new { id = supplier.Id },
                mapper.Map<SupplierDto>(supplier));
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, SupplierDto dto)
    {
        if (dto.StartDate == default)
            return BadRequest("Вкажіть дату початку співпраці.");

        lock (store.SyncRoot)
        {
            Supplier? supplier = store.Suppliers.Find(s => s.Id == id);
            if (supplier == null)
                return NotFound();

            mapper.Map(dto, supplier);
            return NoContent();
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        lock (store.SyncRoot)
        {
            Supplier? supplier = store.Suppliers.Find(s => s.Id == id);
            if (supplier == null)
                return NotFound();

            store.Suppliers.Remove(supplier);
            return NoContent();
        }
    }
}
