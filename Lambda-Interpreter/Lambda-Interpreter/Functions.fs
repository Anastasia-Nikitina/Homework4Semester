module Functions

type Term =
    | Variable of string
    | Application of Term * Term
    | LambdaAbstraction of string * Term
    
let rec getFreeVariables term =
    match term with
    | Variable var -> Set.singleton var
    | Application (term1, term2) -> getFreeVariables term1 + getFreeVariables term2
    | LambdaAbstraction (var, term) -> getFreeVariables term - Set.singleton(var)
        
let rec substitution variable givTerm subTerm =
    match givTerm with
    | Variable var ->
        if (variable <> var) then givTerm else subTerm
    | Application( term1, term2) ->  Application (substitution variable term1 subTerm, substitution variable term2 subTerm)
    | LambdaAbstraction (var, term) ->
        if var = variable then givTerm
        elif (not ((getFreeVariables term).Contains(variable) && (getFreeVariables subTerm).Contains(var)))
        then LambdaAbstraction(var, substitution variable term subTerm)
        else
            let freeVars = getFreeVariables term + getFreeVariables subTerm
            let renamedVar = Set.maxElement(freeVars) + string '1'
            let renamedTerm = substitution var term (Variable renamedVar)
            LambdaAbstraction(renamedVar, substitution variable renamedTerm subTerm)

let rec betaReduction term =
    match term with
    | Variable _ -> term
    | Application (LambdaAbstraction (var, term1), term2) -> betaReduction (substitution var term1 term2)
    | Application (term1, term2) ->
        let calcTerm1 = betaReduction term1
        match calcTerm1 with
        | LambdaAbstraction(var, term3) -> betaReduction(substitution var term3 term2)
        | _ -> Application(calcTerm1, betaReduction term2)                
    | LambdaAbstraction (var, term1) -> LambdaAbstraction(var, betaReduction term1)