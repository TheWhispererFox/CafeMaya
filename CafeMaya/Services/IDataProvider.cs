using CafeMaya.Models;

namespace CafeMaya.Services;

public interface IDataProvider<T> where T : class
{
    /// <summary>
    /// Возвращает все объекты T из провайдера
    /// </summary>
    /// <returns>Список объектов T</returns>
    public IEnumerable<T>? Get();
    /// <summary>
    /// Возвращает объект T из провайдера, который соответвует ID
    /// </summary>
    /// <param name="id">ID объекта T, который нужно вернуть</param>
    /// <returns>Объект T</returns>
    public T? Get(int id);
    /// <summary>
    /// Возвращает все объекты T, удовлетворяющее предикату
    /// </summary>
    /// <param name="predicate">Предикат, который будет использован для проверки</param>
    /// <returns>Список объектов T, удовлетворяющее предикату</returns>
    public IEnumerable<T>? Get(Predicate<T> predicate);
    /// <summary>
    /// Добавляет объект T в провайдер
    /// </summary>
    /// <param name="obj">Объект T, который необходимо добавить</param>
    public void Add(T obj);
    /// <summary>
    /// Добавляет несколько объектов T в провайдер
    /// </summary>
    /// <param name="list">Список объектов T</param>
    public void AddRange(IEnumerable<T> list);
    /// <summary>
    /// Удаляет объект T из провайдера
    /// </summary>
    /// <param name="obj">Объект T, который нужно удалить</param>
    public void Remove(T obj);
    /// <summary>
    /// Удаляет объект T из провайдера
    /// </summary>
    /// <param name="id">ID объекта T, который нужно удалить</param>
    public void Remove(int id);
    /// <summary>
    /// Удаляет множество объектов T из провайдера, удовлетворяющие предикату
    /// </summary>
    /// <param name="predicate">Предикат, использующийся для проверки</param>
    public void RemoveRange(Predicate<T> predicate);
}