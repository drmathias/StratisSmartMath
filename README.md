# StratisSmartMath

Math library for operations using decimals.

## Concept

The concept (unfinished) provides an interface where operations can be done more naturally.

### Type convertions

```csharp
Stratoshi s1 = 1_250_000_000;
Strat s2 = Strat.Parse("1.25");
Stratoshi s3 = (Stratoshi)s2;
Strat s4 = (Strat)s3;
Stratoshi s5 = s4.ToStratoshis();
Strat s6 = s5.ToStrats();
```

### Arithmetic

```csharp
Stratoshi s7 = s1 + s2;
Stratoshi s8 = s1 - s2;

var x = 10;
var y = "4.05";
Stratoshi s9 = s1 * x;
Strat s10 = s2 * y;
Stratoshi s11 = s1 / x;
Strat s12 = s2 / y;
```

### Comparison

```csharp
var greaterThan = s11 > s12;
var greaterEqualThan = s11 >= s12;
var lessThan = s11 < s12;
var lessEqualThan = s11 <= s12;
var equalTo = s11 == s12;
var notEqualTo = s11 != s12;
var equals = s11.Equals(s12);
```