namespace LibMan.Data;
// The use of T in the IRepository<T> interface is a key feature of generics in C#.
// It allows the interface to be type-safe and reusable for any entity type (e.g., User, Product, Order) 
//without having to write separate interfaces for each entity.
public interface IRepositary<T>
{
    //Add an entity to Repositary
    T Add(T entity);
    // Update  an entity in Repositary
    T Update(T entity);
    //Delete an entity in Repositary
    T Delete(T entity);
    //Get an entity by Id
    T GetById(int id);
    //Get All entites
    List<T> GetAll();

}
