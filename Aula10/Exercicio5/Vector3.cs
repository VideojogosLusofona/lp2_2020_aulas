using System;

namespace Exercicio5
{
    public struct Vector3
    {
        // Vector coordinates X, Y, Z
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        // Constructor
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Vector magnitude (length)
        public float Magnitude => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

        // Sum overload
        public static Vector3 operator +(Vector3 v1, Vector3 v2) =>
            new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        // Subtraction overload
        public static Vector3 operator -(Vector3 v1, Vector3 v2) =>
            new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        // Negation overload
        public static Vector3 operator -(Vector3 v) =>
            new Vector3(-v.X, -v.Y, -v.Z);

        // Multiply overload
        public static Vector3 operator *(Vector3 v, float scalar) =>
            new Vector3(scalar * v.X, scalar * v.Y, scalar * v.Z);

        // Divide overload
        public static Vector3 operator /(Vector3 v, float scalar) =>
            new Vector3(v.X / scalar, v.Y / scalar, v.Z / scalar);

        // Equality overload
        public static bool operator ==(Vector3 v1, Vector3 v2) =>
            (v1.X == v2.X) && (v1.Y == v2.Y) && (v1.Z == v2.Z);

        // Inequality overload
        public static bool operator !=(Vector3 v1, Vector3 v2) => !(v1 == v2);

        // Since we overload == and !=, we should override Equals() and
        // GetHashCode()

        // Equals() override, simply call the equality operator on this vector
        // and on the given object, if it's not null
        public override bool Equals(object other)
        {
            if (other == null) return false;
            return this == (Vector3)other;
        }

        // Greater than overload
        public static bool operator >(Vector3 v1, Vector3 v2) =>
            v1.Magnitude > v2.Magnitude;

        // Less than overload
        public static bool operator <(Vector3 v1, Vector3 v2) =>
            v1.Magnitude < v2.Magnitude;


        // Greater or equal than overload
        public static bool operator >=(Vector3 v1, Vector3 v2) =>
            v1.Magnitude >= v2.Magnitude;

        // Less or equal than overload
        public static bool operator <=(Vector3 v1, Vector3 v2) =>
            v1.Magnitude <= v2.Magnitude;

        // GetHashCode() override; a simple way to get an approximately unique
        // hash code is to use XOR (^) on the hash codes of the individual
        // object properties
        public override int GetHashCode() =>
            X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        // ToString() override
        public override string ToString() => $"({X:f2}, {Y:f2}, {Z:f2})";
    }
}
