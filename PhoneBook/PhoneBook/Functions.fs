module PhoneBook.Functions

open System
open System.IO

[<Struct>]
type Record =
    val Name: string
    val Phone: string
    new(name, phone) = { Name=name; Phone=phone }

 
let addRecord name phone listOfRecords =
    Record(name, phone) :: listOfRecords
    
let findPhone name listOfRecords  =
     listOfRecords
     |> List.filter (fun (record: Record) -> record.Name = name)
     |> List.map (fun (record: Record) -> record.Phone)
     
let findName phone listOfRecords  =
     listOfRecords
     |> List.filter (fun (record: Record) -> record.Phone = phone)
     |> List.map (fun (record: Record) -> record.Name) 
         
let printPhoneBook listOfRecords =
    listOfRecords |> List.iter (fun (record: Record) -> printfn($"%A{record.Name} %A{record.Phone}"))
    
let saveToFile listOfRecords path =
   let stringOfRecords = List.map(fun (record: Record) -> $"%A{record.Name} %A{record.Phone}") listOfRecords   
   File.WriteAllLines(path, stringOfRecords)
    
let readFromFile path =
    File.ReadAllLines(path)
    |> Seq.toList
    |> List.map(fun (record: string) -> record.Split(' '))
    |> List.map(fun (a: string[]) -> Record(a[0], a[1]))
