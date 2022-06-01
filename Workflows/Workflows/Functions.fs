module Workflows.Functions
open System

type CalculatingWithRoundingBuilder(accuracy: int) =
    member this.Bind(x, f) = f x
    member this.Return(x: float) = Math.Round(x, accuracy)
    
type CalculatingStringBuilder() =
    member this.Bind(x: string, f) =
        try
            int x |> f
        with
        | :? FormatException -> None 
    member this.Return(x) = Some x
      