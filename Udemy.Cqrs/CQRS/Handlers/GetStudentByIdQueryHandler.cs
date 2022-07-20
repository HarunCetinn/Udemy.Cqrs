using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Udemy.Cqrs.CQRS.Queries;
using Udemy.Cqrs.CQRS.Results;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs.CQRS.Handler
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResult>
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Set<Student>().FindAsync(request.Id);
            return new GetStudentByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname
            };

        }

        //public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        //{
        //    var student = _context.Set<Student>().Find(query.Id);
        //    return new GetStudentByIdQueryResult
        //    {
        //        Age = student.Age,
        //        Name = student.Name,
        //        Surname = student.Surname
        //    };

        //}


    }
}
