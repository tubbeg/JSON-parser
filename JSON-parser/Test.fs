module Test
open Util
open Parser
open JsonString
open FParsec


let runTests =
    initParser listOfParsers
    testParser sep " , "
    testParser stringLiteral "\"mystring\""
    testParser intConstant "3"
    testParser stringConstant "\"mystring\""
    testParser trueConstant "true"
    testParser falseConstant "false"
    testParser jsonParser "{\"number\":true}"
    //testParser jsonParser "{9}"
    testParser jsonParser "{\"number\":{\"mystring\":\"mystring\"}}"
    (*
    testParser objectParser "{\"mystring\",{true,false,{{true}}},\"mystring\"}"*)
    0