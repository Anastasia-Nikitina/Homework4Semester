module Functions

let generateNumbers n =
    let rec inner i (n_inn: int) acc =
        match i with
        | 1 -> acc
        | _ -> inner (i-1) n_inn (acc @ [n_inn])
    inner n n [n]       
//let task1 n =
//    | 
//    Seq.initInfinite(fun x ->)
    
    
let stars1 n =
    let rec inner n_inn acc =
        match n_inn with
        | 0 -> acc
        | _ -> inner (n_inn - 1) (acc + "*")
    inner n ""
    
let stars2 n =
    let rec inner n_inn acc =
        match n_inn with   
        | 2 -> acc + "*"
        | _ -> inner (n_inn - 1) (acc + " ")
    inner n "*"
    
let task2 n =
    let rec inner i n_inn acc =
        match acc with
        | "" -> inner (i - 1) n_inn (acc + (stars1 n_inn) + "\n")
        | _ -> 
            match i with
            | 1 -> acc + (stars1 n_inn)
            | _ -> inner (i - 1) n_inn (acc + (stars2 n_inn) + "\n")
        
    printfn "%A "(inner n n "")        
        
        
        
        
    
    