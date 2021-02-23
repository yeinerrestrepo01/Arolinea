using Aerolina.Domain.Entities;
using DataAccesLayer;
using System.Linq;
using System.Collections.Generic;
using Aerolina.Domain.Commond;

namespace BusinessLayer
{
    public class Aircraft<TEntity> : IServices<TEntity>
    {
        private readonly Repository<Aeronaves> Repository;

        private readonly Mappe<TEntity, Aeronaves> Mapper;

        private readonly ApiResult ResultTransaction;

        /// <summary>
        /// Inicialziador de class Pilots
        /// </summary>
        public Aircraft()
        {
            Repository = new Repository<Aeronaves>(new AerolineaEntities());
            Mapper = new Mappe<TEntity, Aeronaves>();
            ResultTransaction = new ApiResult();
        }


        /// <summary>
        /// Realiza la insercion de las aerolineas
        /// </summary>
        /// <param name="Entidad">Entidad Pilotos</param>
        /// <returns>Resultado de la transacion</returns>
        public ApiResult Insert(TEntity Entidad)
        {
            Repository.Insert(Mapper.MapperInformation(Entidad));
            Repository.SaveChanges();
            return ResultTransaction;
        }

        /// <summary>
        /// Obtiene el listado de todo los aerolineas registradas en el sistema
        /// </summary>
        /// <returns></returns>

        public ApiResult SelectAll()
        {
            ResultTransaction.Result = GetInformation(Repository.GetAll());
            ResultTransaction.Message = Messages.Save;
            return ResultTransaction;
        }

        /// <summary>
        /// realiza la actualizacion de un aerolinea especifico
        /// </summary>
        /// <param name="Entidad">Entidad Piloto</param>
        /// <returns>Resultado de la Transaccion</returns>
        public ApiResult Update(TEntity Entidad)
        {
            Repository.Update(Mapper.MapperInformation(Entidad));
            ResultTransaction.Message = Messages.Save;
            return ResultTransaction;
        }

        private List<AircarftDTO> GetInformation(List<Aeronaves> Information) 
        {
           var MapInformation = Information.Select(t => new AircarftDTO
           {
               Nombre = t.Nombre,
               Capacidad = t.Capacidad,
               Modelo = t.Modelo,
               Piloto = t.Pilotos.Nombres +" " + t.Pilotos.Apellidos,
               ArolineaNombre = t.Aerolinea.Nombre,
               Descripcion = t.Descripcion,
               Id = t.Id
            }).ToList();

            return MapInformation;
        }
    }
}
