# StratisSmartMath

Math library for operations using decimals.

## Conversions

Math requires going back and forth between a decimal string value and a ulong value in stratoshis. Using extension methods on `string` or `ulong` types, you can go back and forth between values.

### To Stratoshis From Decimal

```C#
string decimalAmount = "1.234";


ulong decimalAmountInStratoshis = decimalAmount.ToStratoshis();
// decimalAmountInStratoshis = 123_400_000
```

### To Decimal From Stratoshis

```C#
ulong stratoshiAmount = 500_000_000;

string stratoshiAmountAsDecimal = stratoshiAmount.ToDecimal();
// stratoshiAmountAsDecimal = "5.00000000"
```

## Arithmetic

Operations include Addition, Subtraction, Multiplication and hopefully soon Division. All operations are extension methods on `string` or `ulong` types.

### Addition

```C#
ulong amount = "1.234".Add("0.001");
// amount = 123_500_000

// Chain multiple together
ulong chained = "1.234".Add("0.001").Add("0.0002");
// chained = 123_520_000
```

### Subtraction

```C#
ulong amount = "1.234".Subtract("0.001");
// amount = 123_300_000

// Chain multiple together
ulong chained = "1.234".Subtract("0.001").Subtract("0.0002");
// chained = 123_280_000
```

### Multiplication

```C#
ulong amount = "1.234".Multiply("0.001");
// amount = 123_400

// Chain multiple together
ulong chained = "1.234".Multiply("0.001").Multiply("2");
// chained = 246_800
```

## Comparisons

Compare two decimals or a mix of decimals and values in stratoshis. Operations include LessThan, LessThanOrEqualTo, GreaterThan, GreaterThanOrEqualTo, and EqualTo and return a boolean value.

### Less Than

```C#
string first = "1.234";
ulong second = 140_000_123;

Assert(first.IsLessThan(second)) // true
Assert(second.IsLessThan(first)) // false
```

### Less Than Or Equal To

```C#
string first = "1.234";
ulong second = 140_000_123;
ulong third = 123_400_000;

Assert(first.IsLessThanOrEqualTo(second)) // true
Assert(second.IsLessThanOrEqualTo(first)) // false
Assert(third.IsLessThanOrEqualTo(first)) // true
```

### Greater Than

```C#
string first = "1.234";
ulong second = 140_000_123;

Assert(first.IsGreaterThan(second)) // false
Assert(second.IsGreaterThan(first)) // true
```

### Greater Than Or Equal To

```C#
string first = "1.234";
ulong second = 140_000_123;
ulong third = 123_400_000;

Assert(first.IsGreaterThanOrEqualTo(second)) // false
Assert(second.IsGreaterThanOrEqualTo(first)) // true
Assert(third.IsGreaterThanOrEqualTo(first)) // true
```

### Greater Than

```C#
string first = "1.234";
ulong second = 140_000_123;
ulong third = 123_400_000;

Assert(first.IsEqualTo(second)) // false
Assert(second.IsEqualTo(first)) // false
Assert(third.IsEqualTo(first)) // true

```
