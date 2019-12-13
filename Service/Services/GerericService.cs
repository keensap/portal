using System;
using System.Collections.Generic;
using KeenSap.Portal.Data.Entities;
using KeenSap.Portal.Service.Services.Contract;
using KeenSap.Portal.Data.Repository.Contract;
using KeenSap.Portal.Service.Dto.Response;
using KeenSap.Portal.Service.Dto;
using System.Linq;
using AutoMapper;
using KeenSap.Portal.Service.Common.EventArgs;

namespace KeenSap.Portal.Service.Services
{
    public delegate void CreatingEventHandler<T>(CreateEventArgs<T> e);
    public delegate void UpdatingEventHandler<T>(UpdateEventArgs<T> e);
    
    public abstract class GerericService<TEntity, TGetDto, TCreateDto, TUpdateDto>: IGenericService<TEntity, TGetDto, TCreateDto, TUpdateDto> 
        where TEntity : Entity
        where TGetDto : IDto, new() 
        where TCreateDto : IDto 
        where TUpdateDto : IDto
    {
        // protected internal readonly IUnitOfWork _unitOfWork;
        protected internal readonly IGenericRepository<TEntity> _repository;
        protected internal readonly IMapper _mapper;

        public GerericService(IGenericRepository<TEntity> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TGetDto> Get()
        {
            var entities = _repository.Get();
			return _mapper.Map<IEnumerable<TGetDto>>(entities);
        }

        public TGetDto Get(int id)
        {
            var entity = _repository.Get(id);
			return _mapper.Map<TGetDto>(entity);
        }

        public virtual TGetDto Add(TCreateDto dto)
		{
			if (dto == null)
			{
				throw new ArgumentNullException(nameof(dto));
			}

			var entity = _mapper.Map<TEntity>(dto);
			_repository.Add(entity);
            _repository.GetContext().SaveChanges();
			//_unitOfWork.Commit();
			return _mapper.Map<TGetDto>(entity);
		}

		public virtual TGetDto Update(long id, TUpdateDto dto)
		{
            var existing = _repository.Get(id);
            if (existing == null) throw new ArgumentException("Invalid Id");
            var entity = _mapper.Map(dto, existing);
			if (entity == null) throw new ArgumentNullException(nameof(entity));
			//entity = _mapper.Map(dto, entity);
            var updatingEventArgs = new UpdateEventArgs<TEntity>(entity, id);
                    OnUpdating(updatingEventArgs);
			_repository.Update(entity);
            _repository.GetContext().SaveChanges();
			//_unitOfWork.Commit();
			return _mapper.Map<TGetDto>(entity);
		}

		public virtual bool Delete(int id)//TCreateDto dto)
		{
			//if (dto == null) throw new ArgumentNullException(nameof(dto));
			//var entity = _repository.GetById(id);
			_repository.Remove(id);
            _repository.GetContext().SaveChanges();
			//_unitOfWork.Commit();
            return true;
		}

        public event UpdatingEventHandler<TEntity> Updating;

        protected virtual void OnUpdating(UpdateEventArgs<TEntity> e)
        {
            UpdatingEventHandler<TEntity> handler = Updating;
            if (handler != null)
            {
                handler(e);
            }
        }
    }
}
