module Homework2.MapForBinaryTree

type BinaryTree<'a> =
     | None
     | Node of BinaryTree<'a> * 'a * BinaryTree<'a>

let rec mapForTree func tree =
     match tree with
     | None -> None
     | Node(left, current, right) -> Node(mapForTree func left, func current, mapForTree func right)