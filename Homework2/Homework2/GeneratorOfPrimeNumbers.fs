module Homework2.GeneratorOfPrimeNumbers

let isPrime number =           
    ((fun x -> number % (int x) <> 0), seq{float 2 .. (sqrt (float number))})
    ||>  Seq.forall
 
let generatePrimeNumbers =
    (isPrime, Seq.initInfinite(fun x -> x + 2))
    ||> Seq.filter   