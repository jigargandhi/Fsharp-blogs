let logger (f: 'a->'b) (valA:'a) =
    printfn "Pre"
    let result = f valA
    printfn "Post"
    result 

let add5To x =
    printfn "calling add5To"
    x+5
let decoratedAdd = logger add5To

decoratedAdd 12
|>printfn "%d" 

let add x y =
    printfn "calling add"
    x + y

let decoratedAdder = logger add

decoratedAdder 1 4
|>printfn "%d"

let twoParamedLogger (f:'a->'b->'c) (a:'a) (b:'b) =
    printfn "Pre"
    let result = f a b
    printfn "Post"
    result
    
let decoratedAdd2 = twoParamedLogger add

decoratedAdd2 1 4
|>printfn "%d"