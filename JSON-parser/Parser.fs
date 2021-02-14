module Parser
open FParsec
open Util
open JsonNode
open JsonString


let identifier = notYetImplemented

// Fparsec |>> is a custom operator which
//runs a parser (num) and then applies a function
//which in this case is a type (Node.Number)
let intConstant : Parser<_> = num |>> Node.Number

let stringConstant = stringLiteral |>> Node.String 

let sep : Parser<_> = str_ws ","
let leftLimit : Parser<_> = str_ws "{"
let rightLimit : Parser<_> = str_ws "}"
let myParser = notYetImplemented //intConstant <|> stringConstant