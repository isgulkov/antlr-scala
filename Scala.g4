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

ID : [a-zA-Z][a-zA-Z0-9]* ;

STRING : '"' ( ~('\r' | '\n' | '"') | '\\"' )* '"' ;

LONG : DIGIT+ 'L' ;

INT : DIGIT+ ;

DIGIT : [0-9] ;

WS : ( '\t' | ' ' | '\r' | '\n' )+ -> channel(HIDDEN) ;
