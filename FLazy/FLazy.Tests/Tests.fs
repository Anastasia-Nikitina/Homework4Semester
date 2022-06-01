module FLazy.Tests

open NUnit.Framework
open FsUnit
open System.Threading

open LazyFactory


[<Test>]

let TestForSingleThreadedLazy () =
    let x = 10
    let singleThreadedLazy = LazyFactory.CreateSingleThreadedLazy (fun () -> Interlocked.Decrement(ref x))
    singleThreadedLazy.Get() |> ignore
    singleThreadedLazy.Get() |> ignore
    singleThreadedLazy.Get() |> should equal 9

[<Test>]
let TestForConcurrentLazy () =
    let x = 0
    let lockFreeLazy = LazyFactory.CreateConcurrentLazy (fun () -> Interlocked.Increment(ref x))
    [ for _ in 0 .. 10 do async {
        lockFreeLazy.Get() |> should equal (lockFreeLazy.Get())
    } ]
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

[<Test>]
let TestForLockFreeLazy () =
    let x = 0
    let lockFreeLazy = LazyFactory.CreateLockFreeLazy (fun () -> Interlocked.Increment(ref x))
    [ for _ in 0 .. 10 do async {
        lockFreeLazy.Get() |> should equal (lockFreeLazy.Get())
    } ]
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore