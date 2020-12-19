using System;

namespace Exercicio3
{
    public struct Vector2
    {
        // Vector coordinates X, Y
        public float X { get; }
        public float Y { get; }

        // Constructor
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        // Implicit conversion to Vector3 (no information is lost)
        public static implicit operator Vector3(Vector2 v) =>
            new Vector3(v.X, v.Y, 0f);

        // Explicit conversion from Vector3 (we lose information on Z)
        public static explicit operator Vector2(Vector3 v) =>
            new Vector2(v.X, v.Y);

        // Vector magnitude (length)
        public float Magnitude => (float)Math.Sqrt(X * X + Y * Y);

        // Sum overload
        public static Vector2 operator +(Vector2 v1, Vector2 v2) =>
            new Vector2(v1.X + v2.X, v1.Y + v2.Y);

        // Subtraction overload
        public static Vector2 operator -(Vector2 v1, Vector2 v2) =>
            new Vector2(v1.X - v2.X, v1.Y - v2.Y);

        // Negation overload
        public static Vector2 operator -(Vector2 v) =>
            new Vector2(-v.X, -v.Y);

        // Multiply overload
        public static Vector2 operator *(Vector2 v, float scalar) =>
            new Vector2(scalar * v.X, scalar * v.Y);

        // Divide overload
        public static Vector2 operator /(Vector2 v, float scalar) =>
            new Vector2(v.X / scalar, v.Y / scalar);

        // Equality overload
        public static bool operator ==(Vector2 v1, Vector2 v2) =>
            (v1.X == v2.X) && (v1.Y == v2.Y);

        // Inequality overload
        public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1 == v2);

        // Since we overload == and !=, we should override Equals() and
        // GetHashCode()

        // Equals() override, simply call the equality operator on this vector
        // and on the given object, if it's not null
        public override bool Equals(object other)
        {
            if (other == null) return false;
            return this == (Vector2)other;
        }

        // Greater than overload
        public static bool operator >(Vector2 v1, Vector2 v2) =>
            v1.Magnitude > v2.Magnitude;

        // Less than overload
        public static bool operator <(Vector2 v1, Vector2 v2) =>
            v1.Magnitude < v2.Magnitude;


        // Greater or equal than overload
        public static bool operator >=(Vector2 v1, Vector2 v2) =>
            v1.Magnitude >= v2.Magnitude;

        // Less or equal than overload
        public static bool operator <=(Vector2 v1, Vector2 v2) =>
            v1.Magnitude <= v2.Magnitude;

        // GetHashCode() override; a simple way to get an approximately unique
        // hash code is to use XOR (^) on the hash codes of the individual
        // object properties
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        // ToString() override
        public override string ToString() => $"({X:f2}, {Y:f2})";
    }
}
