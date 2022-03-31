module Homework1.Functions

open Microsoft.FSharp.Collections

let factorial n =
    if n < 0 then failwith "Factorial can be calculated only for non-negative numbers"
    let rec inner n acc =
        if n = 0 then acc
        else inner (n - 1) (acc * n)
    inner n 1
    
let fibonacci n =
    if n < 0 then failwith "Fibonacci numbers are numbered starting from zero"
    let rec inner n acc1 acc2 =
        if n = 0 then acc1
        else inner (n - 1) acc2 (acc1 + acc2)
    inner n 0 1

let reverse list =
    let rec inner list acc =
        match list with
        | [] ->  acc
        | head :: tail -> inner tail (head :: acc)
    inner list []
    
let powersOfTwo n m =
    let rec inner m acc =
        if m = 0 then reverse acc
        else inner (m - 1)  (((List.head(acc))*2) :: acc)   
    inner m [pown 2 n]    

let findNumber n list =
    let rec inner n list acc =
        match list with
        | [] -> failwith "There is no such element in list"
        | head :: tail ->
            if head = n then acc
            else inner n tail (acc + 1)
    inner n list 0 
    
    

 