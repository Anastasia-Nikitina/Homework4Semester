module Functions

open System.Net.Http
open System.Text.RegularExpressions

let downloadPage (url: string) (client:HttpClient) =
    client.GetStringAsync(url)
    |> Async.AwaitTask
    |> Async.Catch

let findLinks page =
    let pattern = "<a href=\"(https://\S+)\">"
    Regex.Matches(page, pattern)
    |> Seq.map (fun x -> x.Groups[1].Value)
       
let getSize url =
    use client = new HttpClient()
    let page = (url, client) ||> downloadPage |> Async.RunSynchronously
    match page with
    | Choice1Of2 content -> Some content.Length
    | Choice2Of2 _ -> None
    
let getAllSizes url =
    let client = new HttpClient()
    async {
        let page =
            (url, client) ||> downloadPage |> Async.RunSynchronously
        match page with
        | Choice1Of2 content ->
            let links = findLinks content
            return (links
            |> Seq.map(getSize)
            |> Seq.zip links)
        | Choice2Of2 _ -> return Seq.empty                  
    }
  
let printInfo linksWithLengths =
    linksWithLengths |>
    Seq.iter
        (fun (url, length) ->
            match length with
            | Some len -> printfn $"%s{url} - %i{len}"
            | None -> printfn "An error occurred while loading the page")