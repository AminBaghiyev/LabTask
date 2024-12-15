using GameStore.BL.Services.Abstractions;

namespace GameStore.BL.Services.Concretes;

public class CartManager : ICartManager
{
    private Dictionary<int, int> _items = [];
    public Dictionary<int, int> Items => _items;
    public int Count => _items.Count;
    public int Quantity => _items.Values.Sum();

    public void Add(int id, int quantity = 1)
    {
        _items[id] =
            _items.TryGetValue(id, out int value) ?
                value + quantity :
                quantity;
    }

    public void Remove(int id, int quantity = 1)
    {
        _items[id] =
            _items.TryGetValue(id, out int value) ?
                value - quantity :
                quantity;

        if (_items[id] == 0) _items.Remove(id);
    }

    public void RemoveAll() => _items.Clear();

    public int this[int i]
    {
        get => _items[i];
    }
}
