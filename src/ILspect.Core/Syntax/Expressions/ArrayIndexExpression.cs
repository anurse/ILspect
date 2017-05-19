﻿using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILspect.Syntax.Expressions
{
    internal class ArrayIndexExpression : Expression
    {
        public Expression Array { get; }
        public Expression Index { get; }
        public MetadataType Type { get; }
        public TypeReference ObjectType { get; }

        public ArrayIndexExpression(Expression array, Expression index, MetadataType type, TypeReference objectType, Instruction instruction) : base(instruction)
        {
            Array = array;
            Index = index;
            Type = type;
            ObjectType = objectType;
        }

        public override string ToString()
        {
            return $"{Array}[{Index}]";
        }
    }
}