module Test
open Util
open Parser
open FParsec


let runTests =
    let p = sep
    testParser p " , "
    0