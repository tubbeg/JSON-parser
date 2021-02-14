module JsonNode

type Node =
    | Array of Node array
    | Number of int
    | String of string
    | Boolean of bool
    | Object of Object list
and Object = string * Node