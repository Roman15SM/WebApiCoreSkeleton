namespace WebApiCore.Business.Interfaces
{
    public interface IBusiness<TModel> where TModel : new()
    {
        void Create(TModel model);

        TModel Read(int id);

        void Update(TModel model);

        void Delete(int id);
    }
}
