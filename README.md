# JSON-parser

A simple JSON-parser implemented in F# using the Fparsec library (https://www.quanttec.com/fparsec/).


## Limitations

* Cannot handle large files
* Slow performance
* It's a top-down recursive parser which has its own limits

## Todo

* Add support for null type
* The parser cannot handle escape characters properly
