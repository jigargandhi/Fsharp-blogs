# Builder pattern in F# (in a functional way)

The Wikipedia entry for [Builder pattern](https://en.wikipedia.org/wiki/Builder_pattern) already gives an example of it in F# language. That example however is based on a mutable type Car.

Let us try to analyze the builder pattern and achieve the same using functional principles. As per Wikipedia, the definition of builder pattern is 

**The intent of the Builder design pattern is to separate the construction of a complex object from its representation. By doing so the same construction process can create different representations.**

Let us know think in a functional way about how to achieve the intent. 

The example on Wikipedia is just a toy example 

Lets say we have a construction domain. We require to build a object of construction which can be a house, a store, a hospital. A piece of construction has a few windows, toilets, electricity points, and a lot of other things. However, the rules for amount of windows are different for house, store, hospital and other types of construction object. Let us see how to apply builder pattern in this domain. 

First we define the construction type as follows:
```fsharp 
type Construction = { NumWindows:uint; NumToilets:uint; NumElectricity:uint }
```
