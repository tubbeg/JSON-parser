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

    // can't handle escape characters right now :/
    let parseManyChar = manyChars (anyChar) // <|> escape char )


    //between is essentially: (pstring "\"") >>. parseManyChar .>> (pstring "\"")
    between (str "\"") (str "\"") parseManyChar
