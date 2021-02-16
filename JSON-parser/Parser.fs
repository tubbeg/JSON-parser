module Parser
open FParsec
open Util
open JsonNode
open JsonString

// Fparsec |>> is a custom operator which
//runs a parser (num) and then applies a function
//which in this case is a type (Node.Number)
let intConstant : Parser<_> = num |>> Node.Number
let stringConstant = stringLiteral |>> Node.String 


let trueBool : Parser<string> = str "true"
let falseBool : Parser<string> = str "false"

// Fparsec >>% behaves like |>> except it doesn't
//apply a function. Instead it will always return
//a constant result if successful
//let example = (pstring "myNullConst") >>% null
let trueConstant = trueBool >>% (Node.Boolean true)
let falseConstant = falseBool >>% (Node.Boolean false)

let sep : Parser<_> = str_ws ","
let betweenBrackets prsr =
    ws >>. (between (str_ws "{") (str_ws "}") prsr)

let listOfParsers = trueConstant <|> falseConstant <|> intConstant <|> stringConstant
let jsonParser = betweenBrackets listOfParsers