module MiniCrawler.Tests

open NUnit.Framework
open Functions
open FsUnit

[<Test>]
let TestForPageWithTwoLinks () =
    "https://www.anekdot.ru/"
    |> getAllSizes
    |> Async.RunSynchronously
    |> should equivalent [("https://gb.anekdot.ru/login/", Some 19486)
                          ("https://gb.anekdot.ru/register/", Some 20624)]
 
[<Test>]   
let TestForPageWithoutLinks () =
    "http://info.cern.ch/hypertext/WWW/TheProject.html"
    |> getAllSizes
    |> Async.RunSynchronously
    |> should equivalent []    