module Homework2Tests

open Homework2
open NUnit.Framework
open FsUnit
open FsCheck
open CountingEvenNumbers
open MapForBinaryTree
open ArithmeticExpressionTree
open GeneratorOfPrimeNumbers

[<Test>]
let mapShouldBeEqualFoldAndFilter () =
    let inner (list: list<int>) =
        let test1 = countEvenUsingMap list = countEvenUsingFold list
        let test2 = countEvenUsingFilter list = countEvenUsingFold list
        let test3 = countEvenUsingFilter list = countEvenUsingMap list
        (test1, test2, test3) |> should equal (true, true, true)
    Check.QuickThrowOnFailure inner
    
[<Test>]    
let testForMapBinaryTree () =
    let tree1 = BinaryTree.Node(BinaryTree.Node(None, 2, None), 1, BinaryTree.Node(None, 3, None))
    let tree2 = BinaryTree.Node(BinaryTree.Node(None, 4, None), 2, BinaryTree.Node(None, 6, None))
    mapForTree (fun x -> x * 2) tree1  |> should equal tree2
 
[<Test>]     
let testForArithmeticExpressionTree () =
    let tree = Node(Node(Leaf 6, Subtraction, Leaf 3), Multiplication, Leaf 5)
    calculateTree tree |> should equal 15
    
[<Test>]
let testForGeneratorPrimeNumbers () =
    let res = seq { for i in 0 .. 9 do Seq.item i generatePrimeNumbers}
    let expect = seq { 2; 3; 5; 7; 11; 13; 17; 19; 23; 29 }
    res |> should equal expect