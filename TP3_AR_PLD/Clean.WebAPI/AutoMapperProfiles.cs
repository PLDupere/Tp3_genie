using System.Linq;
using AutoMapper;
using Clean.Core;
using Clean.Core.Entities;
using Clean.WebAPI.Dtos;

namespace Clean.WebAPI
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Mapping for CalculVersementsDtos and CalculVersements entities
            CreateMap<CalculVersementsDtos, CalculVersements>().ReverseMap();

            // Mapping for DemandeAideFinanciereDtos and DemandeAideFinanciere entities
            CreateMap<EtudiantsDtos, DemandeAideFinancieres>().ReverseMap();

            // Mapping for DossierEtudiantsDtos and DossierEtudiants entities
            CreateMap<DossierEtudiantsDtos, DossierEtudiants>().ReverseMap();

            // Mapping for Etudiants and UserForDetailedDto
            CreateMap<EtudiantsDtos, Etudiants>().ReverseMap();
        }
    }
}
