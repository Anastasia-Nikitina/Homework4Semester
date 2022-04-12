module Tests
open NUnit.Framework
open Functions
open FsCheck

[<Test>]
let checkFunctionsToEquality () =
    let inner x l =
        func x l = pointFree x l
    Check.QuickThrowOnFailure inner
    