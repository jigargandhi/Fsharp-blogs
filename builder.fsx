type Construction = { NumWindows:int; NumToilets:int; NumElectricity:int }

type IConstructionBuilder =
    
    abstract member WithRooms: int -> IConstructionBuilder

    abstract member WithToilet: int -> IConstructionBuilder

type HomeBuilder() =
    let mutable numWindows = 0
    let mutable toilets =0

    interface IConstructionBuilder with
        member this.WithRooms x =
            
            numWindows <- x*2
            this :> IConstructionBuilder
           
        member this.WithToilet x =
            if (x/2 = 0 )then
                toilets <-1
            else
                toilets <- x/2
            
            this :> IConstructionBuilder




