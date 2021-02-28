module JsonString
open Util
open FParsec



//Fparsec satisfy creates a parser for one or many conditions
//The following example creates a parser where 'a' or 'b' are valid
//tokens
//let exampleParser : Parser<_> = satisfy (fun c -> c = 'a' || c = 'b')
//it can almost work a bit like <|>
let anyChar : Parser<_> = satisfy (fun c -> c <> '\\' && c <> '"')


let stringLiteral : Parser<_> =

    let parseManyChar = manyChars (anyChar)// <|> escapeChar)

    //this is basically what Fparsec between does, but I find this
    //this easier to read
    (str_ws "\"" >>. parseManyChar .>> str_ws "\"")
