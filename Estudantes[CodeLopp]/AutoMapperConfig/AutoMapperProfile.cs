using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using Estudantes_CodeLopp_.Models;
using Estudantes_CodeLopp_.Models.ViewModels;

namespace Estudantes_CodeLopp_.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            // AME->Aluno
            CreateMap<AlunoMaeEnderecoViewModel, Aluno>()
                .ForMember(dest => dest.NomeCompleto, map => map.MapFrom(src => src.NomeCompletoAluno))
                .ForMember(dest => dest.IdMae, map => map.MapFrom(src => src.IdMaeFK))
                .ForMember(dest => dest.IdEndereco, map => map.MapFrom(src => src.IdEnderecoFK)).ReverseMap();
            
            //Aluno ->AME
            CreateMap<Aluno, AlunoMaeEnderecoViewModel>()
                .ForMember(dest => dest.NomeCompletoAluno, map => map.MapFrom(src => src.NomeCompleto))
                .ForMember(dest => dest.IdMaeFK, map => map.MapFrom(src => src.IdMae))
                .ForMember(dest => dest.IdEnderecoFK, map => map.MapFrom(src => src.IdEndereco)).ReverseMap();



            //AME->ENd
            CreateMap<AlunoMaeEnderecoViewModel, Endereco>()
                .ForMember(dest => dest.Bairro, map => map.MapFrom(src => src.Bairro));

            //End->AME
            CreateMap<Endereco, AlunoMaeEnderecoViewModel>()
                .ForMember(dest => dest.Bairro, map => map.MapFrom(src => src.Bairro));



            //AME -> Mae
            CreateMap<AlunoMaeEnderecoViewModel, Mae>()
                .ForMember(dest => dest.NomeCompleto, map => map.MapFrom(src => src.NomeCompletoMae));
            

            //Mae-> AME                
            CreateMap<Mae, AlunoMaeEnderecoViewModel>()
                .ForMember(dest => dest.NomeCompletoMae, map => map.MapFrom(src => src.NomeCompleto));

        }
    }
}