module Homework2.CountingEvenNumbers

let countEvenUsingMap list =
    ((fun x -> if x % 2 = 0 then 1 else 0), list)
    ||> List.map
    |> List.sum
    
let countEvenUsingFilter list =
    ((fun x -> x % 2 = 0), list)
    ||> List.filter
    |> List.length
    
let countEvenUsingFold list =
    ((fun acc x -> if x % 2 = 0 then (acc + 1) else acc), 0, list)
    |||> List.fold  