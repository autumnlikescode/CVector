public struct ViewMatrixT
{
    public ViewMatrixT(float[] matrix)
    {
        this.matrix = matrix;
    }

    public float this[int index]
    {
        get { return matrix[index]; }
    }

    public float[] matrix = new float[16];
}

public struct Vector3
{
    public Vector3(float x = 0.0f, float y = 0.0f, float z = 0.0f)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // operator overloads
    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vector3 operator /(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
    }

    public static Vector3 operator *(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    }

    public Vector3 WTS(ViewMatrixT matrix)
    {
        float _x = matrix[0] * X + matrix[4] * Y + matrix[8] * Z + matrix[12];
        float _y = matrix[1] * X + matrix[5] * Y + matrix[9] * Z + matrix[13];
        float w = matrix[3] * X + matrix[7] * Y + matrix[11] * Z + matrix[15];
        float invW = 1.0f / w;
        _x *= invW;
        _y *= invW;
        return new Vector3(_x, _y, 0.0f);
    }

    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
}

