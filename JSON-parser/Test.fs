module Test
open Util
open Parser
open JsonString
open FParsec


let runTests =
    testParser sep " , "
    testParser stringLiteral "\"mystring\""
    testParser intConstant "3"
    testParser stringConstant "\"mystring\""
    testParser trueConstant "true"
    testParser falseConstant "false"
    testParser jsonParser "{true}"
    testParser jsonParser "{9}"
    testParser jsonParser "{\"mystring\",true,3,\"mystring\"}"
    0