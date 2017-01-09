using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using wa.Service.Contracts;
using wa.DAL.Contracts;
using wa.Repository;

namespace wa.Service.Implementations
{
    class LeadService : ILeadService
    {
        IUnitOfWork _unitOfWork;
        ILeadRepository _leadRepository;

        public LeadService(
                        IUnitOfWork unitOfWork,
                        ILeadRepository leadRepository)
        {
            this._unitOfWork = unitOfWork;
            this._leadRepository = leadRepository;
        }


        public IEnumerable<Lead> GetAllLeads()
        {
            try
            {
                IEnumerable<Lead> list = _leadRepository.GetAll();
                return list;
            }
            catch
            {
                //обрабатываем ошибку, записываем в логи
                return null;
            }
        }

        public Lead GetLead(int id)
        {
            Lead lead = null;
            try
            {
                lead = new Lead();
                lead = _leadRepository.GetById(id);
                if (lead == null)
                    return null;
                return lead;
            }
            catch
            {
                //обрабатываем ошибку, записываем в логи
                return lead;
            }
        }
    }
}
