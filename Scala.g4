grammar Scala;

options {
    language = CSharp;
}

/*
 Parser rules
 */

file
    :
    'object' ID
    '{'
        'def' 'main' '(' 'args' ':' 'Array' '[' 'String' ']' ')'
        '{'
            statements
        '}'
    '}' EOF
    ;

statements
    : statement*
    ;

statement
    : whileStmt
    | forStmt
    | declarationStmt ';'
    | printStmt ';'
    | printlnStmt ';'
    | expression ';'
    ;

whileStmt
    : 'while' '(' expression ')' '{' statements '}'
    ;

forStmt
    : 'for' '(' ID '<-' expression 'to' expression ')' '{' statements '}'
    ;

declarationStmt
    : 'var' ID ('=' expression)?
    ;

printStmt
    : 'print' '(' expression ')'
    ;

printlnStmt
    : 'println' '(' expression ')'
    ;

expression // assignment expression, right-associative
    : comparativeExpr
    | comparativeExpr '=' expression
    ;

comparativeExpr
    : multiplicativeExpr
    | comparativeExpr '<' multiplicativeExpr
    | comparativeExpr '>' multiplicativeExpr
    | comparativeExpr '==' multiplicativeExpr
    ;

multiplicativeExpr
    : bitshiftExpr
    | multiplicativeExpr '*' bitshiftExpr
    | multiplicativeExpr '/' bitshiftExpr
    ;

bitshiftExpr
    : primaryExpr
    | bitshiftExpr '<<' primaryExpr
    | bitshiftExpr '>>' primaryExpr
    ;

primaryExpr
    : '(' expression ')'
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
