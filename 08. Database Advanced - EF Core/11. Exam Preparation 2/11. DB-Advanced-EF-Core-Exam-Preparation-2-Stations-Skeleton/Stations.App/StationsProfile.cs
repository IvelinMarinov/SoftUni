using AutoMapper;
using Stations.DataProcessor.Dto;
using Stations.Models;

namespace Stations.App
{
	public class StationsProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public StationsProfile()
		{
		    CreateMap<StationImportDto, Station>();
		    CreateMap<SeatingClassImportDto, SeatingClass>();
		    
		    CreateMap<TrainSeatImportDto, TrainSeat>()
		        .AfterMap((src, dest) =>
		        {
		            dest.SeatingClass = new SeatingClass
		            {
		                Name = src.Name,
		                Abbreviation = src.Abbreviation
		            };
		        });

		    CreateMap<TrainImportDto, Train>()
                .ForMember(dest => dest.TrainSeats, opt => opt.MapFrom(src => src.Seats));
		}
	}
}
