﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Base;
using Data.Entities;

namespace Core.Interfaces
{
    public interface IPeriodRepository : IBaseRepository<Period>
    {
        IEnumerable<Period> Pensum(int CareerId);
        Period GetValidPeriod();
        Task Update(Period period);
    }
}