module Functions

let func x l = List.map (fun y -> y * x) l

let step1 x = List.map (fun y -> y * x)

let step2 x = List.map (fun y -> (*) x y)

let step3 x = List.map ((*) x)

let pointFree = (*) >> List.map
