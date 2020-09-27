using System;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    //TODO: Finish this class definition.
    /// <summary>
    /// 
    /// </summary>
    public class MmgVector2Vec
    {
        /// <summary>
        /// 
        /// </summary>
        private Vector2 vec = Vector2.Zero;

        public MmgVector2()
        {
            vec = Vector2.Zero;
        }

        public MmgVector2(MmgVector2 v)
        {
            vec = v.GetVector();
        }

        public MmgVector2(Vector2 v)
        {
            vec = v;
        }

        public MmgVector2(double x, double y)
        {
            vec = new Vector2((float)x, (float)y);
        }

        public MmgVector2(float x, float y)
        {
            vec = new Vector2(x, y);
        }

        public MmgVector2(int x, int y)
        {
            vec = new Vector2((float)x, (float)y);
        }

        public MmgVector2 Clone()
        {
            MmgVector2 v = new MmgVector2(vec.X, vec.Y);
            return v;
        }

        public void SetX(double x)
        {
            vec.X = (float)x;
        }

        public void SetY(double y)
        {
            vec.Y = (float)y;
        }

        public void SetX(float x)
        {
            vec.X = x;
        }

        public void SetY(float y)
        {
            vec.Y = y;
        }

        public void SetX(int x)
        {
            vec.X = (float)x;
        }

        public void SetY(int y)
        {
            vec.Y = (float)y;
        }

        public int GetX()
        {
            return (int)vec.X;
        }

        public int GetY()
        {
            return (int)vec.Y;
        }

        public double GetXDouble()
        {
            return (double)vec.X;
        }

        public double GetYDouble()
        {
            return (double)vec.Y;
        }

        public float GetXFloat()
        {
            return (float)vec.X;
        }

        public float GetYFloat()
        {
            return (float)vec.Y;
        }

        public Vector2 GetVector()
        {
            return vec;
        }

        public void SetVector(Vector2 v)
        {
            vec = v;
        }

        public MmgVector2 CloneFloat()
        {
            MmgVector2 v = new MmgVector2(GetXFloat(), GetYFloat());
            return v;
        }

        public MmgVector2 CloneDouble()
        {
            MmgVector2 v = new MmgVector2(GetXDouble(), GetYDouble());
            return v;
        }

        public static MmgVector2 GetOriginVec()
        {
            return new MmgVector2(0, 0);
        }

        public static MmgVector2 GetUnitVec()
        {
            return new MmgVector2(1, 1);
        }

        public override string ToString()
        {
            return "X: " + GetXDouble() + " Y: " + GetYDouble();
        }
    }
}