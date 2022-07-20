using MediatR;
using Udemy.Cqrs.CQRS.Results;

namespace Udemy.Cqrs.CQRS.Queries
{
    public class GetStudentByIdQuery :IRequest<GetStudentByIdQueryResult>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
