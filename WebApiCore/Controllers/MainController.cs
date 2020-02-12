using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    public class MainController<TModel> : Controller where TModel : new()
    {
        // GET api/values
        [HttpGet]
        public TModel Get()
        {
            return new TModel();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}