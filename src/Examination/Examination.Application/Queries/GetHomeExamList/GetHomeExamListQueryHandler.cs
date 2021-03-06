using AutoMapper;
using BuildingBlocks.Dtos.Dtos;
using Examination.Domain.AggregateModels.ExamAggregate;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Queries.GetHomeExamList
{
    public class GetHomeExamListQueryHandler : IRequestHandler<GetHomeExamListQuery, IEnumerable<ExamDto>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;

        public GetHomeExamListQueryHandler(IExamRepository examRepository,
            IMapper mapper,
            IClientSessionHandle clientSessionHandle)
        {
            _examRepository = examRepository ?? throw new ArgumentNullException(nameof(examRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;

        }
        public async Task<IEnumerable<ExamDto>> Handle(GetHomeExamListQuery request, CancellationToken cancellationToken)
        {
            var exams = await _examRepository.GetExamListAsync();
            var examDtos = _mapper.Map<IEnumerable<ExamDto>>(exams);
            return examDtos;
        }
    }
}
