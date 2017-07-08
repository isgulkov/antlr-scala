grammar Scala;

options {
    language = CSharp;
}

/*
 Parser rules
 */

//

/*
 Lexer rules
 */

//

WS : ( '\t' | ' ' | '\r' | '\n' )+ -> channel(HIDDEN) ;
