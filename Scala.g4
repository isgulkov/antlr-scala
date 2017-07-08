grammar Scala;

options {
    language = CSharp;
}

/*
 Parser rules
 */

expression
    : primaryExpr
    ;

primaryExpr
    : '(' primaryExpression ')'
    | ID
    | STRING
    | LONG
    | INT
    ;

/*
 Lexer rules
 */

ID : [a-zA-Z][a-zA-Z0-9]* ;

STRING : '"' ( ~('\r' | '\n' | '"') | '\\"' )* '"' ;

LONG : DIGIT+ ('L' | 'l') ;

INT : DIGIT+ ;

DIGIT : [0-9] ;

WS : ( '\t' | ' ' | '\r' | '\n' )+ -> channel(HIDDEN) ;
