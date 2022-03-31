module PhoneBook.Main

open System
open Functions

let getName () =
    printf "%A" "Enter name, please: "
    Console.ReadLine()
    
let getPhone () =
    printf "%A" "Enter phone, please: "
    Console.ReadLine()
    
let getPath () =
    printf "%A" "Enter path, please: "
    Console.ReadLine()
    
let printHelp () =
    printfn
        "%A"
        "Hello!\n\
        Enter next commands to use phone book:\n\
        add - add new record to phone book\n\
        findphone - find phone by name\n\
        findname - find name by phone\n\
        print - print contains phone book\n\
        save - save phone book to file\n\
        read - read phone book from file\n\
        exit - close the console"
        
let rec start listOfRecords =
    printfn "Enter the command: "
    match Console.ReadLine() with
    | "add" ->
        addRecord (getName()) (getPhone()) listOfRecords
        |> start        
    | "findphone" ->
        printfn "%A" (findPhone (getName()))
        start listOfRecords
    | "findname"  ->
        printfn "%A" (findName (getPhone()))
        start listOfRecords
    | "print" ->
        printPhoneBook listOfRecords
        start listOfRecords
    | "save" ->
        saveToFile listOfRecords (getPath())
        start listOfRecords
    | "read" ->
        readFromFile (getPath())
        |> start        
    | "exit" -> ()
    | _ ->
        printHelp ()
        start listOfRecords
printHelp()
start []
