using System.Collections.Generic;
using Model;

namespace wa.Service.Contracts
{
    interface ILeadService
    {
        Lead GetLead(int id);
        IEnumerable<Lead> GetAllLeads();
    }
}
