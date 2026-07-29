using AutoMapper;
using ModelBinding.Models;

namespace ModelBinding.MappingProfiles
{
    public class RoomMappingProfile: Profile
    {
        public RoomMappingProfile() {
            CreateMap<BookingDetails, BookingdetailsDTO>()

                .ForMember(
                destination => destination.GuestKaName,
                opt => opt.MapFrom(src => src.GuestName)
                )
                .ForMember(
                destination => destination.RoomKaType,
                opt => opt.MapFrom(src => src.RoomType)
                )

            

            .ForMember(
                destination => destination.roomOrder,
                opt => opt.MapFrom(src => src.roomOrder)
                );
            CreateMap<RoomOrder, RoomOrderDTO>();
            //CreateMap<RoomOrder, RoomOrderDTO>().
            //    ForMember(destination => destination.roomCleanKarnaHai , opt => opt.MapFrom(src => src.roomClean))
            //    .ForMember(destination => destination.DoUlikedIt , opt => opt.MapFrom(src => src.liked));

            CreateMap<OnlineBook, OnlineBookDTO>()
                .ForMember(destination => destination.cash, opt => opt.MapFrom(src => src.payment.cash))
                .ForMember(destination => destination.UPI, opt => opt.MapFrom(src => src.payment.UPI))
                .ForMember(destination => destination.Card, opt => opt.MapFrom(src => src.payment.Card));


            CreateMap<CreateRoomBook, OnlineBook>().ForMember(
                dest => dest.payment, opt => opt.MapFrom(src => new paymentMethods
                {
                    cash = src.cash,
                    UPI = src.UPI,
                    Card = src.Card
                }));

            CreateMap<OnlineBookDTO, OnlineBook>();
            CreateMap<OnlineBook, OnlineBook>()
                //.ForMember(dest => dest.Coupon, opt => opt.Ignore())
                 //.ForPath(dest => dest.payment.cash , opt => opt.Condition(src => src.payment.cash == "string"))
                 .ForAllMembers(opt =>
        opt.Condition((src, dest, srcMember) =>
            srcMember == "string"));
            //ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != "string"));


            CreateMap<User , UserDTO>();
            CreateMap<User, User>().
                ForMember(dest => dest.isnearBy, opt => opt.Ignore());
        //    CreateMap<User , User>().ForAllMembers(opt =>
        //opt.Condition((src, dest, srcMember) =>
        //    srcMember != null));

            //CreateMap<User, UserDTO>();
        }
    }
}
