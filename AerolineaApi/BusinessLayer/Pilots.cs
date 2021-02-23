using Aerolina.Domain.Entities;
using DataAccesLayer;
using System.Linq;
using System.Collections.Generic;
using Aerolina.Domain.Commond;

namespace BusinessLayer
{
    public class Pilots <TEntity> : IServices<TEntity>
    {
        private readonly Repository<Pilotos> Repository;

        private readonly Mappe<TEntity, Pilotos> Mapper;

        private readonly ApiResult ResultTransaction;

        /// <summary>
        /// Inicialziador de class Pilots
        /// </summary>
        public Pilots()
        {
            Repository = new Repository<Pilotos>(new AerolineaEntities());
            Mapper = new Mappe<TEntity, Pilotos>();
            ResultTransaction = new ApiResult();
        }


        /// <summary>
        /// Realiza la insercion de los pilotos en la tabla Pilotos
        /// </summary>
        /// <param name="Entidad">Entidad Pilotos</param>
        /// <returns>Resultado de la transacion</returns>
        public ApiResult Insert(TEntity Entidad)
        {
            Repository.Insert(Mapper.MapperInformation(Entidad));
            ResultTransaction.Message = Messages.Save;
            return ResultTransaction;
        }

        /// <summary>
        /// Obtiene el listadode todo los piltos registrados en el sistema
        /// </summary>
        /// <returns></returns>

        public ApiResult SelectAll()
        {
            ResultTransaction.Result = GetInformation(Repository.GetAll());
            return ResultTransaction;
        }

        /// <summary>
        /// realiza la actualizacion de un piloto especifico
        /// </summary>
        /// <param name="Entidad">Entidad Piloto</param>
        /// <returns>Resultado de la Transaccion</returns>
        public ApiResult Update(TEntity Entidad)
        {
            Repository.Update(Mapper.MapperInformation(Entidad));
            ResultTransaction.Message = Messages.Save;
            return ResultTransaction;
        }

        private List<PilotsDTO> GetInformation(List<Pilotos> Information) 
        {
           var MapInformation = Information.Select(t => new PilotsDTO
           {
               Identificacion = t.Identificacion,
               Nombres = t.Nombres,
               Apellidos = t.Apellidos,
               Direccion = t.Direccion,
               AerolineaNombre = t.Aerolinea1.Nombre,
               Telefono = t.Telefono
            }).ToList();

            return MapInformation;
        }
    }
}
