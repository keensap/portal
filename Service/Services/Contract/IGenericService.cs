using System;
using System.Collections.Generic;
using KeenSap.Portal.Data.Entities;
using KeenSap.Portal.Service.Dto;

namespace KeenSap.Portal.Service.Services.Contract
{
    public interface IGenericService<TEntity, TGetDto, TCreateDto, TUpdateDto>: IService 
        where TEntity : IEntity
        where TGetDto : IDto, new() 
        where TCreateDto : IDto
        where TUpdateDto : IDto
    {
        IEnumerable<TGetDto> Get();
        TGetDto Get(int id);
        TGetDto Add(TCreateDto dto);
        TGetDto Update(long id, TUpdateDto dto);
        bool Delete(int id);
    }
}
