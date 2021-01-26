module Util
open FParsec
open System

//type UserState = unit 
type Parser<'t> = Parser<'t, unit> // declared because of F# value restriction
let notYetImplemented = NotImplementedException
type NotYetDefined = NotDefined

let ws = spaces
let num = pint32
let str = pstring
let str_ws s = ws .>> str s
let run2 p strContent file = runParserOnString p () file strContent


let testParser parser testCase =
    let result = run parser testCase
    match result with
    | Success(_) -> printfn "Success!"
    | Failure(e, _, _) -> printfn "Error: %A" e