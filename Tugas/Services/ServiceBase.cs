using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tugas.Interfaces;
using Tugas.Models;
using Tugas.Models.Entity;
using Tugas.Models.Request;

namespace Tugas.Services
{
    public class ServiceBase : IServiceBase
    {
        protected IRepositoryBase _repository;
        public ServiceBase(IRepositoryBase repository)
        {
            _repository = repository;
        }

        public virtual async Task<ServiceResult> GetAllData()
        {
            try
            {
                var result = await _repository.GetAllData();

                return new ServiceResult
                {
                    Message = "Get data successfully",
                    IsError = false,
                    Content = result
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Message = ex.Message,
                    IsError = true
                };
            }
        }

        public virtual async Task<ServiceResult> Get(int Id)
        {
            try
            {
                var result = await _repository.Get(Id);

                return new ServiceResult
                {
                    Message = "Get data successfully",
                    IsError = false,
                    Content = result
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Message = ex.Message,
                    IsError = true
                };
            }
        }
        public virtual async Task<ServiceResult> Create(IEnumerable<StudentModel> studentModels)
        {
            try
            {
                var result = await _repository.Create(studentModels);

                return new ServiceResult
                {
                    Message = "Data created successfully",
                    IsError = false,
                    Content = result
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Message = ex.Message,
                    IsError = true
                };
            }
        }

    }
}
