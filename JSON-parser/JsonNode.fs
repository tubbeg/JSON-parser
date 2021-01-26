﻿module JsonNode
open Util

type Node =
    | Array of Node array
    | Number of int
    | String of string
    | Boolean of bool
    | Object of NotYetDefined