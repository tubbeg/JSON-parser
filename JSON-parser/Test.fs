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
    testParser objectParser "{\"number\":true}"
    //testParser jsonParser "{9}"
    testParser objectParser "{\"number\":{\"mystring\":\"mystring\" ,\"myval\":{\"val\":3243}, \"mystring\":91234},\"number\":34234,\"object\":{\"mystring\":\"string\"}}"
    let testString = readFileLinesToString "./jsonTest.json"
    testParser objectParser testString
    (*
    testParser objectParser "{\"mystring\",{true,false,{{true}}},\"mystring\"}"*)
    0