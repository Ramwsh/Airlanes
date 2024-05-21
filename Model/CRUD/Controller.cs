using Airlanes.Model.Contexts;
using Airlanes.Model.CRUD;

public class Controller<T> : ICrudController<T> where T : class
{
    public void Create(T model)
    {
        if (model != null)
        {
            using (Context<T> context = new Context<T>())
            {
                context.DataConteiner.Add(model);
                context.SaveChanges();
            }
        }
    }
    public void Delete(T model)
    {
        if (model != null)
        {
            using (Context<T> context = new Context<T>())
            {
                context.DataConteiner.Remove(model);
                context.SaveChanges();
            }
        }
    }
    public List<T> Read()
    {
        using (Context<T> Context = new Context<T>())
        {
            return Context.DataConteiner.ToList();
        }
    }
    public void Update(int targetIdValue, T updatedModel)
    {
        if (updatedModel != null)
        {
            using (Context<T> context = new Context<T>())
            {
                var targetModel = context.DataConteiner.Find(targetIdValue);
                if (targetModel != null)
                {
                    context.DataConteiner.Remove(targetModel);
                    context.DataConteiner.Add(updatedModel);
                    context.SaveChanges();
                }
            }
        }
    }
}