using Aerolina.Domain.Entities;

namespace BusinessLayer
{
    public interface IServices<TEntity>
    {
        ApiResult Insert(TEntity Entidad);
        ApiResult Update(TEntity Entidad);
        ApiResult SelectAll();
    }
}
