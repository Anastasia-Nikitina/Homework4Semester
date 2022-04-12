module Homework2.ArithmeticExpressionTree

type Operation =
    | Addition
    | Subtraction
    | Multiplication
    | Division
    
type ArithmeticExpressionTree<'a> =
    | Leaf of 'a
    | Node of ArithmeticExpressionTree<'a> * Operation * ArithmeticExpressionTree<'a>
    
let rec calculateTree tree =
    match tree with
    | Node (left, operation, right) ->
        match operation with
        | Addition -> (calculateTree left)  + (calculateTree right)
        | Subtraction -> (calculateTree left) - (calculateTree right)
        | Multiplication -> (calculateTree left) * (calculateTree right)
        | Division -> (calculateTree left) / (calculateTree right)
    | Leaf x -> x