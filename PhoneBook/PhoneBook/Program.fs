module Program
open System

let getName ( ) =
    printf "%A" "Enter name, please: "
    Console.Readline()

let printHelp () =
    printfn
        "%A"
        "Hello!\n\
        Write this commands to use phone book:\n\
        add - add new record to phone book\n\
        findphone - find phone by name\n\
        findname - find name by phone\n\
        print - print contains phone book\n\
        save - save phone book to file\n\
        read - read phone book from file"
        
let rec start listOfRecords =
    printfn "Enter the command: "
    match Console.ReadLine() with
    | "add" -> getName
    