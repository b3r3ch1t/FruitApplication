using FruitApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitApplication;

public interface IFruitContextFaker
{
    List<Fruit> FindAll();
    Fruit FindById(long id);
    Fruit Save(Fruit fruit);
    Fruit Update(long id, Fruit fruit);
    void Delete(long id);
}

public class FruitContextFaker : IFruitContextFaker
{
    private readonly List<Fruit> _list;
    public FruitContextFaker()
    {
        _list = new List<Fruit>();
    }

    public List<Fruit> FindAll()
    {
        return _list;
    }

    public Fruit FindById(long id)
    {
        return _list.First(x => x.Id == id);
    }

    public Fruit Save(Fruit fruit)
    {
        _list.Add(fruit);

        return fruit;
    }

    public Fruit Update(long id, Fruit fruitNew)
    {
        var fruit = FindAll().First(x => x.Id == id);

        if (fruit == null) throw new Exception("invalid fruit");


        Delete(id);
        fruit.Description = fruitNew.Description;
        fruit.Id = id;
        fruit.Name = fruitNew.Name;
        fruit.Type = fruitNew.Type;



        return fruit;
    }

    public void Delete(long id)
    {
        var fruit =  _list.First(x => x.Id == id);
        if (fruit == null) throw new Exception("invalid fruit");

        _list.Remove(fruit);

    }
}