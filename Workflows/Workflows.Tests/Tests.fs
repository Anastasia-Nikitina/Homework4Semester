module Workflows.Tests
open NUnit.Framework
open Functions
open FsUnit

[<Test>]
let testForRounding () =
     let rounding = CalculatingWithRoundingBuilder 3
     let result = 
         rounding {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
     result |> should equal 0.048
    
[<Test>]
let testForNegativeRounding () =
    (fun () ->
        CalculatingWithRoundingBuilder -3 {
            let! a = 2.0 / 7.0
            let! b = 5.5
            return a * b
        } |> ignore) |> should throw typeof<System.ArgumentOutOfRangeException>
     
[<Test>]
let testForCorrectStrings () =
    let calculate = CalculatingStringBuilder()   
    let result = calculate {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }
    result |> should equal (Some 3)  
     
[<Test>]
let testForIncorrectStrings () =
    let calculate = CalculatingStringBuilder()   
    let result = calculate {
        let! x = "1"
        let! y = "Ъ"
        let z = x + y
        return z
    }
    result |> should equal None