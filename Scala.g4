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

STRING : '"' ( ~('\r' | '\n' | '"') | '\\"' )* '"' ;

LONG : DIGIT+ 'L' ;

INT : DIGIT+ ;

DIGIT : [0-9] ;

WS : ( '\t' | ' ' | '\r' | '\n' )+ -> channel(HIDDEN) ;
