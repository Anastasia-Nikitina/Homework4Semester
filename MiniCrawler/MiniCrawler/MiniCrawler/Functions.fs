module Functions

open System.Net.Http
open System.Text.RegularExpressions

let downloadPage (url: string) (client:HttpClient) =
    client.GetStringAsync(url)
    |> Async.AwaitTask
    |> Async.Catch

let findLinks page =
    let regexp = Regex ("<a href=\"(https://\S+)\">", RegexOptions.Compiled)
    regexp.Matches(page)
    |> Seq.map (fun x -> x.Groups[1].Value)
          
let getAllSizes url =
    let client = new HttpClient()
    async {
        let! page =
            (url, client) ||> downloadPage
        match page with
        | Choice1Of2 content ->
            let links = findLinks content
            let! pages =
                links
                |> Seq.map(fun link -> (link, client) ||> downloadPage)
                |> Async.Parallel
            return
                pages
                |> Seq.map (fun page ->
                   match page with
                    | Choice1Of2 (content: string)  -> Some content.Length
                    | Choice2Of2 _  -> None) 
                |> Seq.zip links
        | Choice2Of2 _ -> return Seq.empty                  
    }
  
let printInfo linksWithLengths =
    linksWithLengths |>
    Seq.iter
        (fun (url, length) ->
            match length with
            | Some len -> printfn $"%s{url} - %i{len}"
            | None -> printfn "An error occurred while loading the page")