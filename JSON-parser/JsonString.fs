module JsonString
open Util
open FParsec


//Fparsec satisfy creates a parser for a or several conditions
//The following example creates a parser where 'a' or 'b' are valid
//tokens
//let exampleParser : Parser<_> = satisfy (fun c -> c = 'a' || c = 'b')
//it can almost work a bit like <|>
let anyChar : Parser<_> = satisfy (fun c -> c <> '\\' && c <> '"')

let stringLiteral : Parser<_> =

    // can't handle escape characters right now :/
    let parseManyChar2 : Parser<_> = manyChars (anyChar) // <|> escape char )

    between (str "\"") (str "\"") parseManyChar2
