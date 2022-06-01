module LocalNetwork

open System

type OS  =
    | Windows
    | Linux
    | MacOS
    | MyOS

type Computer(name: int, os: OS, isInfected: bool) =
    let probability () =
        match os with
        | Windows -> 0.7
        | Linux -> 0.5
        | MacOS -> 0.6
        | MyOS -> 0.0
    member this.Name = name
    member this.OS = os
    member val IsInfected = isInfected with get, set
    member val NewInfected = false with get, set
    member this.Probability = probability
    
type Network (computers: List<Computer>, communication: List<int*int>, ?randomizer) =
    let random =
        match randomizer with
        | Some x -> x
        | None -> Random()
    member this.Computers = computers
    member this.Infect(comp1: Computer, comp2: Computer) =
        let comp1Inf = comp1.IsInfected
        let comp2Inf = comp2.IsInfected
        if (communication |> List.contains((comp1.Name, comp2.Name))) &&
            (comp1Inf && not comp2Inf) || (not comp1Inf && comp2Inf)
        then
            if (comp1.Probability() > 0 && not comp1.IsInfected) ||  (comp2.Probability() > 0 && not comp2.IsInfected)
            then
                this.IsFinalState <- false            
                if (comp1.IsInfected) && (comp2.Probability() > random.NextDouble())
                then
                    comp2.IsInfected <- true
                    comp2.NewInfected <- true
                if (comp2.IsInfected) && (comp1.Probability() > random.NextDouble())
                then
                    comp1.IsInfected <- true
                    comp1.NewInfected <- true
        
    member this.Communication = communication
    member val IsFinalState = false with get, set 
    member this.Step() =
        this.Computers |> List.iter(fun x -> x.NewInfected <- false )
        this.IsFinalState <- true
        let step () =
            let rec inner (list: List<Computer>) =
                match list with
                | [] ->
                    computers
                | head :: tail ->
                    tail |> List.iter(fun x -> this.Infect(head, x))
                    inner (tail |> List.filter(fun x -> not x.NewInfected))      
            inner computers |> ignore
        step()   
    
    member this.Start() =
        let mutable numberOfStep = 1
        if (this.Computers |> List.filter(fun x -> x.IsInfected)).Length <> 0
        then
            while not this.IsFinalState do
                this.Step()
                printfn $"Step number %A{numberOfStep}"
                this.Computers
                |> List.iter(fun x -> printfn $"Computer %A{x.Name}. Is infected: %A{x.IsInfected}")
                numberOfStep <- numberOfStep + 1
        printfn "Network in final state"      
    