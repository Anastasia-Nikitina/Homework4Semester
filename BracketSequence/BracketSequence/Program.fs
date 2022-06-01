module Program
   
let checkBrackets (string: string) =
    let list = Seq.toList(string)
    let counter = [|0; 0; 0|] // counter for square, round and curly brackets 
    let rec inner list stack  =
        let funForOpen current list  =
            counter.[current] <- counter.[current] + 1            
            inner list (current :: stack)
        let funForClose current list  =
            if stack.IsEmpty || stack.Head <> current || counter.[current] = 0 then false
            else
                counter.[current] <- counter.[current] - 1
                inner list stack.Tail
        match list with
        | '[' :: tail -> funForOpen 0 tail
        | '(' :: tail -> funForOpen 1 tail          
        | '{' :: tail -> funForOpen 2 tail
        | ']' :: tail -> funForClose 0 tail
        | ')' :: tail -> funForClose 1 tail
        | '}' :: tail -> funForClose 2 tail
        | _ :: tail -> inner tail stack
        | [] -> counter = [|0; 0; 0|]
    inner list []