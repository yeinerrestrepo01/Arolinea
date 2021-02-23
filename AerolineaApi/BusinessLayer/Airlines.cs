
using Aerolina.Domain.Commond;
using Aerolina.Domain.Entities;
using DataAccesLayer;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class Airlines<TEntity> : IServices<TEntity>
    {
        private readonly Repository<Aerolinea> Repository;

        private readonly Mappe<TEntity, Aerolinea> Mapper;

        private readonly ApiResult ResultTransaction;

        /// <summary>
        /// inicializador de class Airlines 
        /// </summary>
        public Airlines()
        {
            Repository = new Repository<Aerolinea>(new AerolineaEntities());
            Mapper = new Mappe<TEntity, Aerolinea>();
            ResultTransaction = new ApiResult();
        }

        /// <summary>
        /// inserta os registros de las aerolienas
        /// </summary>
        /// <param name="Entidad">Entidad Aerolienas</param>
        /// <returns>Resultado de la transaccion</returns>
        public ApiResult Insert(TEntity Entidad)
        {
            Repository.Insert(Mapper.MapperInformation(Entidad));
            return ResultTransaction;
        }

        /// <summary>
        /// Obtiene el listado de aeronaves
        /// </summary>
        /// <returns></returns>
        public ApiResult SelectAll()
        {
           ResultTransaction.Result = GetInformation(Repository.GetAll());
            ResultTransaction.Message = Messages.Save;
            return ResultTransaction;
        }

        /// <summary>
        /// Actualiza una aeroliena en especifico
        /// </summary>
        /// <param name="Entidad"></param>
        /// <returns></returns>
        public ApiResult Update(TEntity Entidad)
        {
            Repository.Update(Mapper.MapperInformation(Entidad));
            ResultTransaction.Message = Messages.Save;
            return ResultTransaction;
        }

        private List<AirlinesDTO> GetInformation(List<Aerolinea> Information)
        {
            var MapInformation  = Information.Select(t=> new AirlinesDTO 
            {
                Id = t.Id,
                Descripcion= t.Descripcion,
                PasiOrigen = t.PasiOrigen,
                Nombre = t.Nombre,
            }).ToList();

            return MapInformation;
        }
    }
}
