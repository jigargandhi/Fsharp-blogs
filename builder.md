# Builder pattern in F# (in a functional way)

The Wikipedia entry for [Builder pattern](https://en.wikipedia.org/wiki/Builder_pattern) already gives an example of it in F# language. That example however is based on a mutable type Car.

Let us try to analyze the builder pattern and achieve the same using functional principles. As per Wikipedia, the definition of builder pattern is 

**The intent of the Builder design pattern is to separate the construction of a complex object from its representation. By doing so the same construction process can create different representations.**

Let us know think in a functional way about how to achieve the intent. 

The example on Wikipedia is just a toy example 

lets say we have a construction. That contruction can be a house, a store, a hospital 
type Construction = { NumWalls:uint; Accessibility:bool; NumToilets:uint }

Lets say to  every construction object we can add rooms, add toilets wheelchair accessibility etc. 

This seems a faily 