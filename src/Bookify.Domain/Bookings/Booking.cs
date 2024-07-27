using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Booking;

public sealed class Booking : Entity
{
    private Booking(Guid id,
                    Guid apartmentId,
                    Guid userId,
                    DateRange duration,
                    Money priceForPeriod,
                    Money cleaninFee,
                    Money amenitiesUpCharge,
                    Money totalPrice,
                    BookingStatusEnum status,
                    DateTime createdOnUtc
     ) : base(id)
    {

        ApartmentId = apartmentId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        CleaninFee = cleaninFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }

    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaninFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatusEnum Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }

    public static Booking Reserve(Apartment apartment, Guid userId, DateRange duration, DateTime utcNow, PricingService pricingService)
    {
        var pricingDetails = pricingService.CalculatePrice(apartment, duration);
        var booking = new Booking(Guid.NewGuid(),
                                     apartment.Id,
                                     userId,
                                     duration,                                    
                                     pricingDetails.PriceForPeriod,
                                     pricingDetails.CleaninFee,
                                     pricingDetails.AmentitiesUpCharge,
                                     pricingDetails.TotalPrice,
                                     BookingStatusEnum.Reserved,
                                     utcNow);
        booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));
        return booking;
    }
}
