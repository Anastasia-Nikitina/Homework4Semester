module PhoneBook.Tests

open Functions

open NUnit.Framework
open FsUnit
open PhoneBook

[<Test>]
let testForAddRecord () =
    addRecord "jellyena" "88005553535" [Record("noname", "123456789")]     
    |> should equal [Record("jellyena", "88005553535"); Record("noname", "123456789")]

[<Test>]   
let testForFindPhone () =
    let name = "jellyena"
    let phoneBook = [Record("jellyena", "88005553535");  Record("noname", "123456789")]
    findPhone name phoneBook |> should equal ["88005553535"]
 
[<Test>]    
let testForFindName () =
    let phone = "123456789"
    let phoneBook = [Record("jellyena", "88005553535");  Record("noname", "123456789")]
    findName phone phoneBook |> should equal ["noname"]
