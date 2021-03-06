﻿using ILspect.Syntax.Expressions;
using Mono.Cecil.Cil;

namespace ILspect.Syntax.Statements
{
    public class DiscardStatement : Statement
    {
        public Expression Value { get; }

        public DiscardStatement(Expression value)
            : this(value, instruction: null) { }

        public DiscardStatement(Expression value, Instruction instruction) : base(instruction)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"__discard({Value})";
        }
    }
}