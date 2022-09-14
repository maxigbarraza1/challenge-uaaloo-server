using _NET;

public class ClientesRepository
{
    public static List<Cliente> _listaClientes = new List<Cliente>(){};

    public IEnumerable<Cliente> GetClientes()
    {
        if(_listaClientes.Count == 0)
            return Enumerable.Empty<Cliente>();
        return _listaClientes;
    }

    public Cliente GetCliente(int id)
    {
        var cliente = _listaClientes[id];
        return cliente;
    }

    public void AddCliente(Cliente cliente)
    {
        _listaClientes.Add(cliente);
    }

    public int GetCantidadClientes()
    {
        return _listaClientes.Count;
    }

    public Cliente ModifyCliente(int id, Cliente cliente)
    {
        _listaClientes[id] = cliente;
        return _listaClientes[id];
    }

    public void DeleteCliente(int id)
    {
        _listaClientes.RemoveAt(id);
    }
}