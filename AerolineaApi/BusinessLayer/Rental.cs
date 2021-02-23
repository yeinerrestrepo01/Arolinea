using Aerolina.Domain.Commond;
using Aerolina.Domain.Entities;
using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Rental<TEntity> : IServices<TEntity>
    {
        private readonly Repository<Alquiler> Repository;

        private readonly Mappe<TEntity, Alquiler> Mapper;

        private readonly ApiResult ResultTransaction;

        /// <summary>
        /// Inicialziador de class Pilots
        /// </summary>
        public Rental()
        {
            Repository = new Repository<Alquiler>(new AerolineaEntities());
            Mapper = new Mappe<TEntity, Alquiler>();
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

        private List<RentalDTO> GetInformation(List<Alquiler> Information)
        {
            var MapInformation = Information.Select(t => new RentalDTO
            {
                FechaLLegada = t.FechaLLegada,
                FechaSalida = t.FechaSalida,
                CantidadPasajetos = t.CantidadPasajetos,
                DondeViaja = t.DondeViaja,
                Id = t.Id

            }).ToList();

            return MapInformation;
        }
    }
}
