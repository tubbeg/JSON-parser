module JsonNode

type Node =
    | Array of Node array
    | Number of int
    | String of string
    | Boolean of bool
    | Obj of (Node) list
