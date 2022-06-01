module LazyConcurrent

open ILazy
open System

type LazyConcurrent<'a> (supplier : unit -> 'a) =
    let lockObject = Object()
    let mutable result = None 
    interface ILazy<'a> with 
        member this.Get() =
            lock lockObject
                (fun () ->
                    if result.IsNone
                    then result <- Some(supplier()))
            result.Value