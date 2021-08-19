using BuildingBlocks.Dtos.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Examination.Application.Queries.GetHomeExamList
{
    public class GetHomeExamListQuery : IRequest<IEnumerable<ExamDto>>
    {
    }
}
