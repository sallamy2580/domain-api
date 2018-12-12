﻿
using Logic.Common;

namespace Logic.Customers
{
    public class Dollars : ValueObject<Dollars>


    {

        private const decimal MaxDollarAmount = 1_000_000;
        public decimal Value { get; }
        private Dollars(decimal value)
        {
            Value = value;
        }

        public bool IsZero => Value == 0;

        public static Result<Dollars> Create(decimal dollarAmount)
        {
            if (dollarAmount < 0)
            {
                return Result.Fail<Dollars>("Dollar amount cannot be negative");
            }

            if (dollarAmount > MaxDollarAmount)
            {
                return Result.Fail<Dollars>("Dollar amount cannot be greater than " + MaxDollarAmount);
            }

            if (dollarAmount % 0.01m > 0)
            {
                return Result.Fail<Dollars>("Dollar amount cannot part of a penny");
            }

            return Result.Ok(new Dollars(dollarAmount));

        }

        protected override bool EqualsCore(Dollars other)
        {
            return (Value == other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator decimal(Dollars dollars)
        {
            return dollars.Value;
        }
        //Replaceed by of
        //public static explicit operator Dollars(decimal dollarAmount)
        //{
        //    return Create(dollarAmount).Value;
        //}

        public static Dollars Of (decimal dollarAmount)
        {
            return Create(dollarAmount).Value;
        }

        public static Dollars operator *(Dollars dollars, decimal multiplier)
        {
            return Of(dollars.Value * multiplier);
        }

        public static Dollars operator +(Dollars dollars, Dollars valueAdded)
        {
            return Of(dollars.Value + valueAdded.Value);
        }
    }
}
