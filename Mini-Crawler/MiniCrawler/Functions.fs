module Functions

open  System.Text.RegularExpressions

let regexp = Regex("<a href=\"(https://\S+)\">", RegexOptions.Compiled)

let findLinks html =
    let href = "<a href=\"https://\S+\">"
    let httpsAddress = "https://\S+\""
    Regex.Matches(html, href)
    |> Seq.map (fun x -> Regex.Match(x.Value, httpsAddress).Value |> (fun x -> x.Remove (x.Length - 1)))
    
let findURLs html =
    let urlPattern = "<a href=\"(https://\S+)\">"
    let regex = Regex(urlPattern, RegexOptions.Compiled)

    regex.Matches(html)
    |> Seq.map (fun x -> x.Groups[1].Value)    