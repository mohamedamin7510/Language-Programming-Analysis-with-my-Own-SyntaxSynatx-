
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                =  0, // (EOF)
        SYMBOL_ERROR              =  1, // (Error)
        SYMBOL_WHITESPACE         =  2, // Whitespace
        SYMBOL_AND                =  3, // And
        SYMBOL_ASSIGN             =  4, // Assign
        SYMBOL_BEGIN              =  5, // begin
        SYMBOL_BOOL               =  6, // bool
        SYMBOL_COLON              =  7, // Colon
        SYMBOL_COMMA              =  8, // Comma
        SYMBOL_DIVIDE             =  9, // Divide
        SYMBOL_DO                 = 10, // do
        SYMBOL_ELSE               = 11, // else
        SYMBOL_END                = 12, // end
        SYMBOL_EQ                 = 13, // Eq
        SYMBOL_FALSE              = 14, // false
        SYMBOL_FLOAT              = 15, // float
        SYMBOL_FUNCTION           = 16, // function
        SYMBOL_GT                 = 17, // Gt
        SYMBOL_IDENTIFIER         = 18, // Identifier
        SYMBOL_IF                 = 19, // if
        SYMBOL_INT                = 20, // int
        SYMBOL_LPAREN             = 21, // LParen
        SYMBOL_LT                 = 22, // Lt
        SYMBOL_MINUS              = 23, // Minus
        SYMBOL_NEQ                = 24, // Neq
        SYMBOL_NOT                = 25, // Not
        SYMBOL_NUMBER             = 26, // Number
        SYMBOL_OR                 = 27, // Or
        SYMBOL_PLUS               = 28, // Plus
        SYMBOL_RETURN             = 29, // return
        SYMBOL_RPAREN             = 30, // RParen
        SYMBOL_SEMI               = 31, // Semi
        SYMBOL_START              = 32, // Start
        SYMBOL_STRING             = 33, // string
        SYMBOL_STRINGLITERAL      = 34, // StringLiteral
        SYMBOL_THEN               = 35, // then
        SYMBOL_TIMES              = 36, // Times
        SYMBOL_TRUE               = 37, // true
        SYMBOL_VAR                = 38, // var
        SYMBOL_WHILE              = 39, // while
        SYMBOL_ADDITIVEEXPR       = 40, // <AdditiveExpr>
        SYMBOL_ARGLIST            = 41, // <ArgList>
        SYMBOL_ARGTAIL            = 42, // <ArgTail>
        SYMBOL_ASSIGNMENT         = 43, // <Assignment>
        SYMBOL_CONDITION          = 44, // <Condition>
        SYMBOL_DECLARATION        = 45, // <Declaration>
        SYMBOL_EMPTY              = 46, // <Empty>
        SYMBOL_EQUALITYEXPR       = 47, // <EqualityExpr>
        SYMBOL_EXPRESSION         = 48, // <Expression>
        SYMBOL_FACTOR             = 49, // <Factor>
        SYMBOL_LOGICALANDEXPR     = 50, // <LogicalAndExpr>
        SYMBOL_LOGICALOREXPR      = 51, // <LogicalOrExpr>
        SYMBOL_LOOP               = 52, // <Loop>
        SYMBOL_METHODCALL         = 53, // <MethodCall>
        SYMBOL_METHODDECLARATION  = 54, // <MethodDeclaration>
        SYMBOL_MULTIPLICATIVEEXPR = 55, // <MultiplicativeExpr>
        SYMBOL_OPTIONALARGS       = 56, // <OptionalArgs>
        SYMBOL_OPTIONALELSE       = 57, // <OptionalElse>
        SYMBOL_OPTIONALPARAMS     = 58, // <OptionalParams>
        SYMBOL_PARAM              = 59, // <Param>
        SYMBOL_PARAMLIST          = 60, // <ParamList>
        SYMBOL_PARAMTAIL          = 61, // <ParamTail>
        SYMBOL_PROGRAM            = 62, // <Program>
        SYMBOL_RELATIONALEXPR     = 63, // <RelationalExpr>
        SYMBOL_RETURNSTATEMENT    = 64, // <ReturnStatement>
        SYMBOL_STATEMENT          = 65, // <Statement>
        SYMBOL_STATEMENTLIST      = 66, // <StatementList>
        SYMBOL_TYPE               = 67  // <Type>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                                   =  0, // <Program> ::= Start <StatementList> end
        RULE_STATEMENTLIST                                                       =  1, // <StatementList> ::= <Statement> <StatementList>
        RULE_STATEMENT                                                           =  2, // <Statement> ::= <Declaration>
        RULE_STATEMENT2                                                          =  3, // <Statement> ::= <Assignment>
        RULE_STATEMENT3                                                          =  4, // <Statement> ::= <Condition>
        RULE_STATEMENT4                                                          =  5, // <Statement> ::= <Loop>
        RULE_STATEMENT5                                                          =  6, // <Statement> ::= <MethodDeclaration>
        RULE_STATEMENT6                                                          =  7, // <Statement> ::= <MethodCall>
        RULE_STATEMENT7                                                          =  8, // <Statement> ::= <ReturnStatement>
        RULE_STATEMENT8                                                          =  9, // <Statement> ::= <Empty>
        RULE_DECLARATION_VAR_IDENTIFIER_COLON_SEMI                               = 10, // <Declaration> ::= var Identifier Colon <Type> Semi
        RULE_TYPE_INT                                                            = 11, // <Type> ::= int
        RULE_TYPE_FLOAT                                                          = 12, // <Type> ::= float
        RULE_TYPE_STRING                                                         = 13, // <Type> ::= string
        RULE_TYPE_BOOL                                                           = 14, // <Type> ::= bool
        RULE_ASSIGNMENT_IDENTIFIER_ASSIGN_SEMI                                   = 15, // <Assignment> ::= Identifier Assign <Expression> Semi
        RULE_CONDITION_IF_THEN_END                                               = 16, // <Condition> ::= if <Expression> then <StatementList> <OptionalElse> end
        RULE_OPTIONALELSE_ELSE                                                   = 17, // <OptionalElse> ::= else <StatementList>
        RULE_OPTIONALELSE                                                        = 18, // <OptionalElse> ::= <Empty>
        RULE_LOOP_WHILE_DO_END                                                   = 19, // <Loop> ::= while <Expression> do <StatementList> end
        RULE_METHODDECLARATION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_COLON_BEGIN_END = 20, // <MethodDeclaration> ::= function Identifier LParen <OptionalParams> RParen Colon <Type> begin <StatementList> end
        RULE_OPTIONALPARAMS                                                      = 21, // <OptionalParams> ::= <ParamList>
        RULE_OPTIONALPARAMS2                                                     = 22, // <OptionalParams> ::= <Empty>
        RULE_PARAMLIST                                                           = 23, // <ParamList> ::= <Param> <ParamTail>
        RULE_PARAMTAIL_COMMA                                                     = 24, // <ParamTail> ::= Comma <Param> <ParamTail>
        RULE_PARAMTAIL                                                           = 25, // <ParamTail> ::= <Empty>
        RULE_PARAM_IDENTIFIER_COLON                                              = 26, // <Param> ::= Identifier Colon <Type>
        RULE_METHODCALL_IDENTIFIER_LPAREN_RPAREN_SEMI                            = 27, // <MethodCall> ::= Identifier LParen <OptionalArgs> RParen Semi
        RULE_OPTIONALARGS                                                        = 28, // <OptionalArgs> ::= <ArgList>
        RULE_OPTIONALARGS2                                                       = 29, // <OptionalArgs> ::= <Empty>
        RULE_ARGLIST                                                             = 30, // <ArgList> ::= <Expression> <ArgTail>
        RULE_ARGTAIL_COMMA                                                       = 31, // <ArgTail> ::= Comma <Expression> <ArgTail>
        RULE_ARGTAIL                                                             = 32, // <ArgTail> ::= <Empty>
        RULE_RETURNSTATEMENT_RETURN_SEMI                                         = 33, // <ReturnStatement> ::= return <Expression> Semi
        RULE_EXPRESSION                                                          = 34, // <Expression> ::= <LogicalOrExpr>
        RULE_LOGICALOREXPR_OR                                                    = 35, // <LogicalOrExpr> ::= <LogicalOrExpr> Or <LogicalAndExpr>
        RULE_LOGICALOREXPR                                                       = 36, // <LogicalOrExpr> ::= <LogicalAndExpr>
        RULE_LOGICALANDEXPR_AND                                                  = 37, // <LogicalAndExpr> ::= <LogicalAndExpr> And <EqualityExpr>
        RULE_LOGICALANDEXPR                                                      = 38, // <LogicalAndExpr> ::= <EqualityExpr>
        RULE_EQUALITYEXPR_EQ                                                     = 39, // <EqualityExpr> ::= <EqualityExpr> Eq <RelationalExpr>
        RULE_EQUALITYEXPR_NEQ                                                    = 40, // <EqualityExpr> ::= <EqualityExpr> Neq <RelationalExpr>
        RULE_EQUALITYEXPR                                                        = 41, // <EqualityExpr> ::= <RelationalExpr>
        RULE_RELATIONALEXPR_LT                                                   = 42, // <RelationalExpr> ::= <RelationalExpr> Lt <AdditiveExpr>
        RULE_RELATIONALEXPR_GT                                                   = 43, // <RelationalExpr> ::= <RelationalExpr> Gt <AdditiveExpr>
        RULE_RELATIONALEXPR                                                      = 44, // <RelationalExpr> ::= <AdditiveExpr>
        RULE_ADDITIVEEXPR_PLUS                                                   = 45, // <AdditiveExpr> ::= <AdditiveExpr> Plus <MultiplicativeExpr>
        RULE_ADDITIVEEXPR_MINUS                                                  = 46, // <AdditiveExpr> ::= <AdditiveExpr> Minus <MultiplicativeExpr>
        RULE_ADDITIVEEXPR                                                        = 47, // <AdditiveExpr> ::= <MultiplicativeExpr>
        RULE_MULTIPLICATIVEEXPR_TIMES                                            = 48, // <MultiplicativeExpr> ::= <MultiplicativeExpr> Times <Factor>
        RULE_MULTIPLICATIVEEXPR_DIVIDE                                           = 49, // <MultiplicativeExpr> ::= <MultiplicativeExpr> Divide <Factor>
        RULE_MULTIPLICATIVEEXPR                                                  = 50, // <MultiplicativeExpr> ::= <Factor>
        RULE_FACTOR_IDENTIFIER                                                   = 51, // <Factor> ::= Identifier
        RULE_FACTOR_NUMBER                                                       = 52, // <Factor> ::= Number
        RULE_FACTOR_STRINGLITERAL                                                = 53, // <Factor> ::= StringLiteral
        RULE_FACTOR_TRUE                                                         = 54, // <Factor> ::= true
        RULE_FACTOR_FALSE                                                        = 55, // <Factor> ::= false
        RULE_FACTOR_LPAREN_RPAREN                                                = 56, // <Factor> ::= LParen <Expression> RParen
        RULE_FACTOR                                                              = 57, // <Factor> ::= <MethodCall>
        RULE_FACTOR_NOT                                                          = 58, // <Factor> ::= Not <Factor>
        RULE_FACTOR_PLUS                                                         = 59, // <Factor> ::= Plus <Factor>
        RULE_FACTOR_MINUS                                                        = 60, // <Factor> ::= Minus <Factor>
        RULE_EMPTY                                                               = 61  // <Empty> ::= 
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox L;
        public MyParser(string filename , ListBox L)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.L = L;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //And
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //Assign
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //Colon
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //Comma
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVIDE :
                //Divide
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //Eq
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //Gt
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //LParen
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //Lt
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //Minus
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEQ :
                //Neq
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOT :
                //Not
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMBER :
                //Number
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //Or
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //Plus
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //RParen
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //Semi
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //then
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //Times
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDITIVEEXPR :
                //<AdditiveExpr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGLIST :
                //<ArgList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGTAIL :
                //<ArgTail>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<Condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARATION :
                //<Declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EMPTY :
                //<Empty>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQUALITYEXPR :
                //<EqualityExpr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALANDEXPR :
                //<LogicalAndExpr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALOREXPR :
                //<LogicalOrExpr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP :
                //<Loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODCALL :
                //<MethodCall>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODDECLARATION :
                //<MethodDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTIPLICATIVEEXPR :
                //<MultiplicativeExpr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPTIONALARGS :
                //<OptionalArgs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPTIONALELSE :
                //<OptionalElse>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPTIONALPARAMS :
                //<OptionalParams>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAM :
                //<Param>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMLIST :
                //<ParamList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMTAIL :
                //<ParamTail>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RELATIONALEXPR :
                //<RelationalExpr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNSTATEMENT :
                //<ReturnStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<StatementList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<Program> ::= Start <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<StatementList> ::= <Statement> <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <Declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <Condition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <Loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <MethodDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<Statement> ::= <MethodCall>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT7 :
                //<Statement> ::= <ReturnStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT8 :
                //<Statement> ::= <Empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARATION_VAR_IDENTIFIER_COLON_SEMI :
                //<Declaration> ::= var Identifier Colon <Type> Semi
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<Type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_FLOAT :
                //<Type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_STRING :
                //<Type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_BOOL :
                //<Type> ::= bool
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_ASSIGN_SEMI :
                //<Assignment> ::= Identifier Assign <Expression> Semi
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION_IF_THEN_END :
                //<Condition> ::= if <Expression> then <StatementList> <OptionalElse> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPTIONALELSE_ELSE :
                //<OptionalElse> ::= else <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPTIONALELSE :
                //<OptionalElse> ::= <Empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOP_WHILE_DO_END :
                //<Loop> ::= while <Expression> do <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_COLON_BEGIN_END :
                //<MethodDeclaration> ::= function Identifier LParen <OptionalParams> RParen Colon <Type> begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPTIONALPARAMS :
                //<OptionalParams> ::= <ParamList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPTIONALPARAMS2 :
                //<OptionalParams> ::= <Empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMLIST :
                //<ParamList> ::= <Param> <ParamTail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMTAIL_COMMA :
                //<ParamTail> ::= Comma <Param> <ParamTail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMTAIL :
                //<ParamTail> ::= <Empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAM_IDENTIFIER_COLON :
                //<Param> ::= Identifier Colon <Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODCALL_IDENTIFIER_LPAREN_RPAREN_SEMI :
                //<MethodCall> ::= Identifier LParen <OptionalArgs> RParen Semi
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPTIONALARGS :
                //<OptionalArgs> ::= <ArgList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPTIONALARGS2 :
                //<OptionalArgs> ::= <Empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGLIST :
                //<ArgList> ::= <Expression> <ArgTail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGTAIL_COMMA :
                //<ArgTail> ::= Comma <Expression> <ArgTail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGTAIL :
                //<ArgTail> ::= <Empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN_SEMI :
                //<ReturnStatement> ::= return <Expression> Semi
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <LogicalOrExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXPR_OR :
                //<LogicalOrExpr> ::= <LogicalOrExpr> Or <LogicalAndExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXPR :
                //<LogicalOrExpr> ::= <LogicalAndExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXPR_AND :
                //<LogicalAndExpr> ::= <LogicalAndExpr> And <EqualityExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXPR :
                //<LogicalAndExpr> ::= <EqualityExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXPR_EQ :
                //<EqualityExpr> ::= <EqualityExpr> Eq <RelationalExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXPR_NEQ :
                //<EqualityExpr> ::= <EqualityExpr> Neq <RelationalExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXPR :
                //<EqualityExpr> ::= <RelationalExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELATIONALEXPR_LT :
                //<RelationalExpr> ::= <RelationalExpr> Lt <AdditiveExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELATIONALEXPR_GT :
                //<RelationalExpr> ::= <RelationalExpr> Gt <AdditiveExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELATIONALEXPR :
                //<RelationalExpr> ::= <AdditiveExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDITIVEEXPR_PLUS :
                //<AdditiveExpr> ::= <AdditiveExpr> Plus <MultiplicativeExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDITIVEEXPR_MINUS :
                //<AdditiveExpr> ::= <AdditiveExpr> Minus <MultiplicativeExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDITIVEEXPR :
                //<AdditiveExpr> ::= <MultiplicativeExpr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTIPLICATIVEEXPR_TIMES :
                //<MultiplicativeExpr> ::= <MultiplicativeExpr> Times <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTIPLICATIVEEXPR_DIVIDE :
                //<MultiplicativeExpr> ::= <MultiplicativeExpr> Divide <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTIPLICATIVEEXPR :
                //<MultiplicativeExpr> ::= <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_IDENTIFIER :
                //<Factor> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_NUMBER :
                //<Factor> ::= Number
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_STRINGLITERAL :
                //<Factor> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TRUE :
                //<Factor> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_FALSE :
                //<Factor> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<Factor> ::= LParen <Expression> RParen
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <MethodCall>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_NOT :
                //<Factor> ::= Not <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_PLUS :
                //<Factor> ::= Plus <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_MINUS :
                //<Factor> ::= Minus <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EMPTY :
                //<Empty> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "'" + " Line:" +
                args.UnexpectedToken.Location.LineNr;

            L.Items.Add(message);
            string m2 = args.ExpectedTokens.ToString();
            L.Items.Add(m2);
            //todo: Report message to UI?
        }
    }
}
