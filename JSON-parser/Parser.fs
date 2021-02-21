module Parser
open FParsec
open Util
open JsonNode
open JsonString

(*This is necessary for recursive grammar, and also possibly because
of F# type inference. What createParserForwardedToRef does is
creating a parser (jsonValue) which forwards all parser calls to
the parser in jsonReference (reference cell). The reference cell is
mutable, and initially holds what is basically a dummy parser which
throws an exception when called. This is why this parser must be
initialized*)
let jsonValue, jsonReference = createParserForwardedToRef<Node, unit>()

let initParser ref list =
    ref := list

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

//might remove this later
let spawn (o : Node) =
    let newObjectList = Node.Obj(o::[])
    newObjectList

let objectParser = betweenBrackets jsonValue |>> spawn

let listOfParsers =
    objectParser
    <|> trueConstant
    <|> falseConstant
    <|> intConstant
    <|> stringConstant
    
let recordElement list = sepEndBy list sep
let jsonParser = betweenBrackets (recordElement listOfParsers)
