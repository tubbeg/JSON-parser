module Parser
open FParsec
open Util
open JsonNode
open JsonString


let sep : Parser<_> = ws >>. str_ws "," .>> ws
//this needs to change
let recordElement list = sepBy1 (ws >>. list .>> ws) sep

(*This is necessary for recursive grammar, and also possibly because
of F# type inference. What createParserForwardedToRef does is
creating a parser (jsonValue) which forwards all parser calls to
the parser in jsonReference (reference cell). The reference cell is
mutable, and initially holds what is basically a dummy parser which
throws an exception when called. This is why this parser must be
initialized*)
let jsonValue, jsonReference = createParserForwardedToRef<Node, unit>()

let initParser list =
    jsonReference := list

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

let betweenBraces prsr =
    ws >>. (str_ws "{" >>. prsr .>> str_ws "}")
  
let betweenBrackets prsr =
    ws >>. (str_ws "[" >>. ws >>. prsr .>> ws .>> str_ws "]")
    
let arrayParser = betweenBrackets (recordElement jsonValue)

let arrayConstant = arrayParser |>> (fun a -> Node.Array((a |> List.toArray)))

let keyPattern = stringLiteral >>. (str_ws ":") >>. ws
    
let objectParser = betweenBraces (recordElement (keyPattern >>. jsonValue))
let objectConstant = objectParser |>> (fun n -> Obj(n))

let listOfParsers =
    arrayConstant
    <|> objectConstant
    <|> trueConstant
    <|> falseConstant
    <|> intConstant
    <|> stringConstant