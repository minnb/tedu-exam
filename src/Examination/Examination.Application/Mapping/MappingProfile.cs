﻿using AutoMapper;
using BuildingBlocks.Dtos.Dtos;
using Examination.Domain.AggregateModels.ExamAggregate;

namespace Examination.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exam, ExamDto>().ReverseMap();
        }
    }
}
