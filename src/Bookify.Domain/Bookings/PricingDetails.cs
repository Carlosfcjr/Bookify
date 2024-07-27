using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Booking;

public record PricingDetails(
    Money PriceForPeriod,
    Money CleaninFee,
    Money AmentitiesUpCharge,
    Money TotalPrice);
