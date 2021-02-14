module Test
open Util
open Parser
open JsonString
open FParsec


let runTests =
    testParser sep " , "
    testParser stringLiteral "\"mystring\""
    testParser intConstant "33"
    testParser stringConstant "\"mystring\""
    0