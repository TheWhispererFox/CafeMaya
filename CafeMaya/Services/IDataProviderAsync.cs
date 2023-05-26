namespace CafeMaya.Services;

public interface IDataProviderAsync<T> where T : class
{
    /// <summary>
    /// Возвращает все объекты T из провайдера
    /// </summary>
    /// <returns>Список объектов T</returns>
    public Task<IEnumerable<T>?> GetAsync();
    /// <summary>
    /// Возвращает объект T из провайдера, который соответвует ID
    /// </summary>
    /// <param name="id">ID объекта T, который нужно вернуть</param>
    /// <returns>Объект T</returns>
    public Task<T?> GetAsync(int id);
    /// <summary>
    /// Возвращает все объекты T, удовлетворяющее предикату
    /// </summary>
    /// <param name="predicate">Предикат, который будет использован для проверки</param>
    /// <returns>Список объектов T, удовлетворяющее предикату</returns>
    public Task<IEnumerable<T>?> GetAsync(Predicate<T> predicate);
    /// <summary>
    /// Добавляет объект T в провайдер
    /// </summary>
    /// <param name="obj">Объект T, который необходимо добавить</param>
    public Task AddAsync(T obj);
    /// <summary>
    /// Добавляет несколько объектов T в провайдер
    /// </summary>
    /// <param name="list">Список объектов T</param>
    public Task AddRangeAsync(IEnumerable<T> list);
}