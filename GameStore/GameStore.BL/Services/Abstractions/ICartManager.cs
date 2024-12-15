namespace GameStore.BL.Services.Abstractions;

public interface ICartManager
{
    Dictionary<int, int> Items { get; }
    int Count { get; }
    int Quantity { get; }
    void Add(int id, int quantity = 1);
    void Remove(int id, int quantity = 1);
    void RemoveAll();
    int this[int id] { get; }
}
