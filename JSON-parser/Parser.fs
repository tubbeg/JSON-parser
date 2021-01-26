module Parser
open FParsec
open Util
//open String


let identifier = notYetImplemented

let stringConstant = notYetImplemented 

let intConstant = notYetImplemented

let sep : Parser<_> = str_ws ","
let leftLimit : Parser<_> = str_ws "{"
let rightLimit : Parser<_> = str_ws "}"
let myParser = notYetImplemented //intConstant <|> stringConstant