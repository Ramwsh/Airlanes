namespace Airlanes.Model.CRUD
{
    interface ICrudController<T>
    {
        public void Create(T model);
        public List<T> Read();
        public void Update(int targetIdValue, T updatedModel);
        public void Delete(T model);
    }
}
