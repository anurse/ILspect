using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILspect.Syntax.Expressions
{
    public class DereferenceExpression : Expression, IEquatable<DereferenceExpression>
    {
        public Expression Address { get; }
        public MetadataType Type { get; }
        public TypeReference ObjectType { get; }

        public DereferenceExpression(Expression address, MetadataType type)
            : this(address, type, objectType: null, instruction: null) { }

        public DereferenceExpression(Expression address, MetadataType type, Instruction instruction)
            : this(address, type, objectType: null, instruction: instruction) { }

        public DereferenceExpression(Expression address, TypeReference objectType)
            : this(address, type: MetadataType.Object, objectType: objectType, instruction: null) { }

        public DereferenceExpression(Expression address, TypeReference objectType, Instruction instruction)
            : this(address, type: MetadataType.Object, objectType: objectType, instruction: instruction) { }

        private DereferenceExpression(Expression address, MetadataType type, TypeReference objectType, Instruction instruction) : base(instruction)
        {
            Address = address;
            Type = type;
            ObjectType = objectType;
        }

        public override string ToString()
        {
            var typeName = Type == MetadataType.Object ?
                ObjectType.FullName :
                Type.ToString();
            return $"*(({typeName}&){Address})";
        }

        public override bool Equals(object obj) => obj is DereferenceExpression e && Equals(e);

        public override int GetHashCode()
        {
            var combiner = HashCodeCombiner.Start();
            combiner.Add(base.GetHashCode());
            combiner.Add(Address);
            combiner.Add(Type);
            combiner.Add(ObjectType);
            return combiner.CombinedHash;
        }

        public bool Equals(DereferenceExpression other)
        {
            return base.Equals(other) &&
                Equals(Address, other.Address) &&
                Equals(ObjectType, other.ObjectType) &&
                Type == other.Type;
        }
    }
}
