type Construction = { NumWindows:int; NumToilets:int; NumElectricity:int }

type IConstructionBuilder =
    
    abstract member WithRooms: int -> IConstructionBuilder

    abstract member WithToilet: int -> IConstructionBuilder

    abstract member Build: unit -> Construction

type HomeBuilder() =
    let mutable rooms = 0
    let mutable numWindows = 0
    let mutable toilets =0

    interface IConstructionBuilder with
        member this.WithRooms x =
            rooms <- x
            numWindows <- x*2
            this :> IConstructionBuilder
           
        member this.WithToilet x =
            if (x/2 = 0 )then
                toilets <-1
            else
                toilets <- x/2
            
            this :> IConstructionBuilder
        
        member this.Build ()=
            { NumWindows = numWindows; NumToilets= toilets; NumElectricity= 2 }


let m = HomeBuilder()
let b = m:>IConstructionBuilder

b.WithRooms(2)
let house = b.Build()

printfn "%d" house.NumWindows





