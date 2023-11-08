# Lesson 3 Independent Challenges

Before starting the challenges, make sure you have CSharpier and Husky installed:

```
dotnet tool install --global csharpier
dotnet tool install --global husky
```

Finally, run `husky install` at the root of the repository.

## Challenge 1: `FlipCoin` (4 points)

Write a method that uses `random.Next` to simulate the flip of a coin and return the results in the form of an element of the `CoinSide` enum.

The first line of the function is written for you. You should use this line without changing it, since otherwise the tests will not pass.

## Challenge 2: `RollNSidedDice` (8 points)

Write a method that uses `random.Next` to simulate the roll of an `n`-sided dice and return the result. Each whole number from 1 to `n` (inclusive) is written on its own face of the dice.

If `n` is less than 1, an `ArgumentOutOfRangeException` should be thrown for the parameter `n` with the following exact message, replacing the `___` with the value of `n`:

```
It isn't possible to have a ___-sided dice
```

The first line of the function is written for you. You should use this line without changing it, since otherwise the tests will not pass.

## Challenge 3: `GetRenewedReturnDate` (4 points)

Write a method that gets the new return date for a library book that is being renewed. This should be a `DateTime` object that is two weeks from midnight today.

The first line of the function is written for you. You should use this line without changing it, since otherwise the tests will not pass.

## Challenge 4: `CalculateAge` (14 points)

Write a method that takes a `DateTime` object representing a date of birth and returns the corresponding age in the form of a tuple: `(years: ___, months: ___)`, replacing the `___`s with the number of years and months since the given date of birth.

Note that the months value should not exceed 12: for example, rather than returning 4 years and 14 months, the method should return 5 years and 2 months. Also, as is generally the case with ages, you should round down if fractions are involved.

If the date portion of the date of birth provided is in the future, an `ArgumentOutOfRangeException` should be thrown for the parameter `dateOfBirth` with the following exact message:

```
Date of birth cannot be in the future
```

The first line of the function is written for you. You should use this line without changing it, since otherwise the tests will not pass.

## Challenge 5: `CalculateSphereVolume` (8 points)

Write a method that takes a value representing the radius of a sphere and returns the volume of that sphere.

For reference, the formula for finding the volume of a sphere based on its radius $r$ is as follows:

$$V=\frac{4}{3}\pi r^3$$

If the radius provided is less than zero, an `ArgumentOutOfRangeException` should be thrown with the following exact message:

```
It isn't possible for a sphere to have a negative radius
```

## Challenge 6: `CalculateQuadraticEquationSolutions` (20 points)

Write a method that takes three values representing the coefficients of a quadratic equation and returns an array containing all the unique solutions to the equation in any order. More specifically, for $a$, $b$ and $c$ such that $ax^2+bx+c=0$, return as many unique values of $x$ as there are existing are that make the equation true.

For reference, when $a \neq 0$, the quadratic formula for solving quadratic equations is as follows, which could result in 0, 1 or 2 solutions:

$$x=\frac{-b\pm \sqrt{b^2-4ac}}{2a}$$

For the case where $a = 0$ and $b \neq 0$, the formula for solving the resulting linear equation is as follows, which results in 1 solution:

$$x=-\frac{c}{b}$$

For the case where $a = b = 0$ and $c \neq 0$, there are no solutions for the resulting equation.

For the case where $a = b = c = 0$, an `InvalidOperationException` should be raised with the following exact message:

```
Infinite number of solutions found
```

Your method should not result in an uncaught exception if there are no solutions: an empty array should be returned instead. If you've come across complex numbers before, note that we are only interested in real solutions here.

## Challenge 7: `GetGuestCount` (14 points)

Write a method that asks the user for a single response: the number of guests for a restaurant booking. If the user enters a positive integer, return this integer. Otherwise, raise a `FormatException` with one of the following exact messages:

```
Bookings cannot be for a negative number of guests
Bookings cannot be for zero guests
Bookings must be for a valid whole number of guests
```

For negative non-whole numbers of guests, choose the third error message rather than the first.

## Challenge 8: `SplitBillEvenly` (14 points)

A restaurant bill totals 100.00 currency. A method has been partially written for you that asks the user for a single response: the number of guests to split the bill evenly between. If the user types a positive integer, the method outputs the following exact text, replacing the `___` with the size of each share, formatted to exactly two decimal places:

```
That will be ___ each, thank you!
```

(Exact rounding concerns are disregarded for this exercise). Otherwise, if the user types a negative integer, the method outputs the following exact text:

```
The bill cannot be split between a negative number of guests.
```

However, there are still two error cases to be handled that should result in the relevant choice of the following two exact messages being output:

```
The bill cannot be split between zero guests.
That isn't a valid whole number of guests.
```

The only action you should take to achieve this is to replace the existing `finally` block with appropriate `catch` blocks. The rest of the existing code should not be modified.

## Challenge 9: `GreetCustomer` (8 points)

A method has been written for you that asks a user for a single response upon entering a shop: which action out of three possible options they would like to take. At the moment, the method sometimes results in an uncaught `IndexOutOfRangeException` or `FormatException`. We would like to change this.

If possible, the method should still output the following exact text, replacing the `___` with the selected option:

```
You selected: ___.
```

Otherwise, the method should output the following exact text:

```
That wasn't one of the options.
```

You should achieve this change by wrapping one line of the method in a `try`-`catch` block.

## Challenge 10: `ServeCustomer` (6 points)

A method has been written for you that asks a user for a single response: which of the available fruits they would like to purchase. At the moment, the method sometimes results in an uncaught `KeyNotFoundException`. We would like to change this.

If possible, the method should still output the following exact text, replacing the `___` with the price of the fruit chosen:

```
That will be ___, please!
```

Otherwise, the method should output the following exact text:

```
That wasn't one of the options.
```

You should achieve this change by wrapping one line of the method in a `try`-`catch` block. Don't worry if some of the constructs used in the existing code are unfamiliar to you; just focus on the exception handling part.

## Bonus challenge: `CountMondaysBetween`

Write a method that takes two `DateTime`s (a start date and an end date) and returns the number of Mondays that occurred between these two dates (inclusive).

In the case where the end date falls before the start date, an `ArgumentOutOfRangeException` should be thrown for the parameter `end` with the following exact message:

```
End date cannot be before start date
```

You should start by thinking of some of your own test cases (which you don't have to write actual tests for unless you're feeling particularly ambitious).
