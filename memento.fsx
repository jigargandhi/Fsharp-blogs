// Memento Pattern in F#
type State<'T> = {State: State<'T> option; CurrentItem: 'T}
//'T -> State<'T>
let createState (instance :'T) =
    {State=None; CurrentItem= instance}

//('a->'a)->State<'a>->State<'b'>
let updateState modifier currentState  =
    let newObject = modifier currentState.CurrentItem
    { State =Some currentState; CurrentItem = newObject}
    
let getPreviousState state =
    match state.State with
    | Some x -> x
    | None -> failwith "No Old state"

type Person = { Name: string}


let changeNameTo name person =
    {person with Name=name}

let person = {Name="Jigar"}
let finalState = createState person
                    |> updateState (changeNameTo "GitHub")
// GitHub
printfn "Current Name: %s" finalState.CurrentItem.Name
let previousState = getPreviousState finalState
//Jigar
printfn "Previous Name: %s" previousState.CurrentItem.Name