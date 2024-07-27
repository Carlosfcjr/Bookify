namespace Bookify.Domain.Shared;

public record class Money(decimal Amount,Currency Currency)
{
    public static Money operator +(Money first, Money second){
        if(first.Currency!=second.Currency)
            throw new InvalidOperationException("Currencies have to be equal");
        
        return new Money(first.Amount+second.Amount,first.Currency);
    }
    public static Money Zero()=>new(0,Currency.Nome);

    public bool IsZero()=> this == Zero();
}
