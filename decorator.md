# Decorator pattern in F#

Idea behind decorator pattern is to execute some wrapper code or adorn a function call.

For example, we can do logging before and after the function call. We can audit the number of times a function is called which can be useful for testing. We can implement policies on function calls such as retry, timeout etc. 

Let us take a simple example of logging pre and post a function call.
We will create a generic logger that takes a function and a value. This generic logger will print a pre message, call the function and print a post message
```fsharp
//('a->'b)->'a->'b
let logger (f: 'a->'b) (valA:'a) =
    printfn "Pre"
    let result = f valA
    printfn "Post"
    result 
```
Lets create a simple function that adds 5 to the input
```fsharp
// int->int
let add5To x =
    printfn "calling add5To"
    x+5
```
Now lets create a decorated function for `add5To` function, execute it with a parameter 12 and pipe the output to printfn
```fsharp
let decoratedAdd = logger add5To

decoratedAdd 12
|>printfn "%d"
``` 
The output is as expected:
```
Pre
calling add5To
Post
17
```
So far so good. Now time to get a little bit ambitious.
Lets create a function that takes 2 values and adds them.
```fsharp
//int->int->intS
let add x y =
    printfn "calling add"
    x + y
```
No brainer isn't it. Now lets create a decorated function and call it with 2 parameters
```fsharp
// int->int->int
let decoratedAdder = logger add

decoratedAdder 1 4
|>printfn "%d"
```
The output is not what you might expect
```
Pre
Post
calling add
5
```
**What just happened?** Why did `calling add` come after the `Post`. 

If you see the type annotation on the logger it is `('a->'b')->'a->'b`. Which means it takes a function that takes _one_ parameter of type `'a` and outputs a value of type `'b`. The function `add` having the signature of `int->int->int` when added to the logger becomes of type `int->(int->int)`, i.e. for the logger `'a` is an `int` and `'b` is a function from `int->int`. 

When we call `decoratedAdder 1 4` it gets evaluated as `(decoratedAdder 1)` which does pre and post logging and  returns a function of type `int->int` and 4 is applied to this function which results in calling of the message `calling add` after the pre and post messages. 

Phew!! What did we learn here. We learned that the signature of the decorator after partial application of target function should be the same as target function for it to behave correctly. If you created a logger that takes a function of 2 parameters, you will see the correct output
```fsharp
//('a->'b->'c)->'a->'b->'c
let twoParamedLogger (f:'a->'b->'c) (a:'a) (b:'b) =
    printfn "Pre"
    let result = f a b
    printfn "Post"
    result

// int->int->int    
let decoratedAdd2 = twoParamedLogger add

decoratedAdd2 1 4
|>printfn "%d"
//Pre
//calling add
//Post
//5
```

We figured that in F# we can create decorators to wrap other functions, but we can only create correctly typed decorators. As it is F#'s strength is its type system.  