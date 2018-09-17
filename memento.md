# Memento pattern in F#

Memento pattern allows to store state of an object so that it can be restored later

To hold the state of the object we create a state type in F# as follows
```fsharp
type State<'T> = {State: State<'T> option; CurrentItem: 'T}
```
In the `State` type, the State property refers to old state and CurrentItem refers to the current object.
Additionally, we create a few helper functions `createState`, `updateState` and `getPreviousState` to help us create initial State, transition to a new State and get the old state respectively.
```fsharp
//'T -> State<'T>
let createState (instance :'T) =
    {State=None; CurrentItem= instance}
```
`createState` function takes an object and returns a new state for that object. Since, it does not have any previous state its State is `None`
```fsharp
//('a->'a)->State<'a>->State<'b'>
let updateState modifier currentState  =
    let newObject = modifier currentState.CurrentItem
    { State =Some currentState; CurrentItem = newObject}
```
Next we have an `updateState` function that takes a function `modifier`. In F# records are immutable. We should create new instances instead of updating them. `modifier` functions does just that, it takes an instance and returns modified new instance.
In the `updateState` function we create a new state and set the State to `currentState` as old State. 
```fsharp
//State<'a>->State<'a>    
let getPreviousState state =
    match state.State with
    | Some x -> x
    | None -> failwith "No Old state"
```
To get previous state, we need to pattern match the State and get the State's CurrentItem to get the previous item.

Lets see how we can use it.
First we create a `Person` type who has a property Name of type `string`
```fsharp
type Person = {Name:string}
```
We also create a modifier function that takes a new name, a `Person` object and returns new `Person` object with the parameter name 
```fsharp
// string->Person->Person
let changeNameTo name person =
    {person with Name=name}
```
Now we can finally use it as follows:
```fsharp
let person = {Name="Jigar"}
let finalState = createState person
                    |> updateState (changeNameTo "GitHub")

printfn "Current Name: %s" finalState.CurrentItem.Name
// Current Name: GitHub

let previousState = getPreviousState finalState
printfn "Previous Name: %s" previousState.CurrentItem.Name
// Previous Name: Jigar
```