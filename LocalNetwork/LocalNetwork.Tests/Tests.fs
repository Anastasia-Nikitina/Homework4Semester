module LocalNetwork.Tests

open NUnit.Framework
open LocalNetwork
open FsUnit
open Foq

[<Test>]
let testForOneInfected () =
    let comp1 = Computer(1, Windows, true)
    let comp2 = Computer(2, Linux, false)
    let comp3 = Computer(3, MacOS, false)
    let network1 = Network([comp1; comp2; comp3], [(1, 2); (2,3)])
    network1.Start()
    comp1.IsInfected |> should equal true
    comp2.IsInfected |> should equal true
    comp3.IsInfected |> should equal true

[<Test>]
let testForZeroInfected () =
    let comp1 = Computer(1, Windows, false)
    let comp2 = Computer(2, Linux, false)
    let comp3 = Computer(3, MacOS, false)
    let network2 = Network([comp1; comp2; comp3], [(1, 3);(1, 2)])
    network2.Start()
    comp1.IsInfected |> should equal false
    comp2.IsInfected |> should equal false
    comp3.IsInfected |> should equal false
    
[<Test>]
let testForNotAllComputersInfected () =
    let comp1 = Computer(1, MyOS, false)
    let comp2 = Computer(2, Linux, true)
    let comp3 = Computer(3, MacOS, false)
    let network2 = Network([comp1; comp2; comp3], [(1, 2);(1, 3)])
    network2.Start()
    comp1.IsInfected |> should equal false
    comp2.IsInfected |> should equal true
    comp3.IsInfected |> should equal false
    
[<Test>]
let testWithMock () =
    let comp1 = Computer(1, MyOS, false)
    let comp2 = Computer(2, Linux, true)
    let comp3 = Computer(3, MacOS, false)
    let randomizer = Mock<System.Random>()
                             .Setup(fun x -> <@ x.NextDouble() @>)
                             .Returns(1)
                             .Create()
    let network3 = Network([comp1; comp2; comp3], [(1, 2); (1, 3)], randomizer)
    network3.Start()
    comp1.IsInfected |> should equal false
    comp2.IsInfected |> should equal true
    comp3.IsInfected |> should equal false                  