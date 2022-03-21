module Homework2.GeneratorOfPrimeNumbers

let isPrime number =           
    seq{float 2 .. (sqrt (float number))})
    |>  Seq.forall (fun x -> number % (int x) <> 0)
 
let generatePrimeNumbers =
    (isPrime, Seq.initInfinite(fun x -> x + 2))
    ||> Seq.filter   