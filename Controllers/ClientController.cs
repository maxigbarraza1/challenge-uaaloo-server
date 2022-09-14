using Microsoft.AspNetCore.Mvc;

namespace _NET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ILogger<ClientesController> _logger;

    public ClientesController(ILogger<ClientesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        ClientesRepository repClientes = new ClientesRepository();
        return Ok(repClientes.GetClientes());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        ClientesRepository repClientes = new ClientesRepository();

        if (id >= repClientes.GetCantidadClientes())
        {
            var notFound = NotFound("El cliente con el id: " + id.ToString() + " no existe.");
            return notFound;
        }
        var cliente = repClientes.GetCliente(id);
        if (cliente == null)
        {
            var notFound = NotFound("El cliente con el id: " + id.ToString() + " no existe.");
            return notFound;
        }
        return Ok(cliente);
    }

    [HttpPost("agregar")]
    public IActionResult AgregarCliente(Cliente nuevoCliente)
    {
        ClientesRepository repClientes = new ClientesRepository();
        repClientes.AddCliente(nuevoCliente);
        return CreatedAtAction(nameof(AgregarCliente), nuevoCliente);
    }

    [HttpPatch("actualizar/{id}")]
    public IActionResult ActualizarCliente(int id, Cliente cliente)
    {
        ClientesRepository repClientes = new ClientesRepository();
        if (id >= repClientes.GetCantidadClientes())
        {
            var notFound = NotFound("El cliente con el id: " + id.ToString() + " no existe.");
            return notFound;
        }
        var clientDB = repClientes.GetCliente(id);
        if (clientDB == null)
        {
            var notFound = NotFound("El cliente con el id: " + id.ToString() + " no existe.");
            return notFound;
        }

        var clientModified = repClientes.ModifyCliente(id, cliente);
        return Ok(cliente);
    }

    [HttpDelete("eliminar/{id}")]
    public IActionResult EliminarCliente(int id)
    {
        ClientesRepository repClientes = new ClientesRepository();
        if (id >= repClientes.GetCantidadClientes())
        {
            var notFound = NotFound("El cliente con el id: " + id.ToString() + " no existe.");
            return notFound;
        }
        var clientDB = repClientes.GetCliente(id);
        if (clientDB == null)
        {
            var notFound = NotFound("El cliente con el id: " + id.ToString() + " no existe.");
            return notFound;
        }

        repClientes.DeleteCliente(id);
        return Ok();
    }


}
