module BracketSequence.Test

open NUnit.Framework
open Program
open FsUnit

[<Test>]
let testForTrue1 () =
    let string = "({[hello]})"
    checkBrackets string |> should equal true

[<Test>]    
let testForTrue2 () =
    let string = "()([])"
    checkBrackets string |> should equal true
    
[<Test>]
let testForTrue3 () =
    let string = "{[aaa]} () "
    checkBrackets string |> should equal true
    
[<Test>]
let testForFalse1 () =
    let string = ":((("
    checkBrackets string |> should equal false
    
[<Test>]
let testForFalse2 () =
    let string = "{(})"
    checkBrackets string |> should equal false    

[<Test>]
let testForFalse3 () =
    let string = "][a)(b}{c["
    checkBrackets string |> should equal false      