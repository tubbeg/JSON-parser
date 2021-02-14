module Test
open Util
open Parser
open JsonString
open FParsec


let runTests =
    let p = sep
    testParser p " , "
    let p2 = stringLiteral
    testParser p2 "\"mystring\""
    0