module Lambda_Interpreter.Tests

open NUnit.Framework
open FsUnit
open Functions

[<Test>]
let testSubstitutionApplication () =
    let term = Application (Variable "x", Variable"y")
    let result = substitution "x" term (Variable "y")
    result |> should equal (Application (Variable "y", Variable "y"))
    
[<Test>]    
let testSubstitutionAbstraction () =
    let term = LambdaAbstraction("x", Variable "y")
    let result = substitution "y" term (Variable "x")
    result |> should equal (LambdaAbstraction("y1", Variable "x"))
 
[<Test>]    
let testAbsVarReduction () =
    let term = Application (LambdaAbstraction("x", Variable "x"), Variable "hello")
    let result = betaReduction term
    result |> should equal (Variable "hello")
    
[<Test>]
let testVarVarReduction () =
    let term = Application (Variable "x", Variable "y")
    let result = betaReduction term
    result |> should equal term

[<Test>]
let testAbsAbsReduction () =
    let term = Application (LambdaAbstraction ("x", Variable "x"), LambdaAbstraction("y", Variable "y"))
    let result = betaReduction term
    result |> should equal (LambdaAbstraction("y", Variable "y"))