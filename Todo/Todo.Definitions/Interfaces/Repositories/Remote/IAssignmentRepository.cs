﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetAssignmentsAsync(string courseId);

        Task<IEnumerable<Assignment>> GetAssignmentsAsync();
    }
}
