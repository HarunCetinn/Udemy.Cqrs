using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Udemy.Cqrs.CQRS.Queries;
using Udemy.Cqrs.CQRS.Results;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs.CQRS.Handler
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery,IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _context;

        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname, /*Age = x.Age*/ }).AsNoTracking().ToListAsync();

        }
    }
}
