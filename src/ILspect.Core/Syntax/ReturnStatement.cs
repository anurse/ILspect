﻿using Mono.Cecil.Cil;

namespace ILspect.Syntax
{
    public class ReturnStatement : Statement
    {
        public Expression Value { get; }

        public ReturnStatement(Expression value, Instruction instruction) : base(instruction)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"return {Value}";
        }
    }
}