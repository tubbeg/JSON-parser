module Test
open Util
open Parser
open JsonString
open FParsec


let runTests =
    initParser jsonReference listOfParsers
    testParser sep " , "
    testParser stringLiteral "\"mystring\""
    testParser intConstant "3"
    testParser stringConstant "\"mystring\""
    testParser trueConstant "true"
    testParser falseConstant "false"
    testParser jsonParser "{true}"
    testParser jsonParser "{9}"
    testParser jsonParser "{{\"mystring\"}}"
    testParser jsonParser "{\"mystring\",true,{{999}},3,\"mystring\"}"
    0