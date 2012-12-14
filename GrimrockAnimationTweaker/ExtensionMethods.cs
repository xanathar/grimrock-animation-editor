using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using AnimationEditor;
using GrimrockAnimationTweaker.Grim3dAdapters;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public static class ExtensionMethods
    {
        public static IEnumerable<GrimAnimationKeyFrame> KeyFrames(this IEnumerable<FrameRange> e)
        {
            foreach (FrameRange fr in e)
                foreach (GrimAnimationKeyFrame kf in fr.KeyFrames)
                    yield return kf;
        }

        public static GrimAnimation Clone(this GrimAnimation a)
        {
            return new GrimAnimation()
            {
                AnimationName = a.AnimationName,
                FramesPerSecond = a.FramesPerSecond,
                Items = a.Items.Select(i => i.Clone()).ToArray(),
                Magic = a.Magic,
                NumFrames = a.NumFrames,
                OriginalFilePath = a.OriginalFilePath,
                Version = a.Version
            };
        }


        public static GrimAnimationItem Clone(this GrimAnimationItem ai)
        {
            return new GrimAnimationItem()
            {
                NodeName = ai.NodeName,
                KeyFrames = ai.KeyFrames.Select(kf => kf.Clone()).ToList()
            };
        }

        public static GrimAnimationKeyFrame Clone(this GrimAnimationKeyFrame kf)
        {
            GrimAnimationKeyFrame k = new GrimAnimationKeyFrame();
            k.DebugLevel = kf.DebugLevel;
            k.Position = kf.Position.Clone();
            k.Scale = kf.Scale.Clone();
            k.Rotation = kf.Rotation.Clone();
            return k;
        }

        public static GrimVec3 Clone(this GrimVec3 kf)
        {
            return new GrimVec3() { X = kf.X, Y = kf.Y, Z = kf.Z };
        }

        public static GrimQuaternion Clone(this GrimQuaternion kf)
        {
            return new GrimQuaternion() { X = kf.X, Y = kf.Y, Z = kf.Z, W = kf.W };
        }

        public static Quaternion ToClrQuaternion(this GrimQuaternion q)
        {
            return new Quaternion() { X = q.X, Y = q.Y, Z = q.Z, W = q.W };
        }

        public static void SetFromClrQuaternion(this GrimQuaternion q, Quaternion q2)
        {
            q.X = (float)q2.X;
            q.Y = (float)q2.Y;
            q.Z = (float)q2.Z;
            q.W = (float)q2.W;
        }


        public static void Normalize(this GrimQuaternion qq)
        {
            Quaternion q = qq.ToClrQuaternion();
            q.Normalize();
            qq.SetFromClrQuaternion(q);
        }


        public static GrimVec3 Rotate(this GrimQuaternion grimQuaternion, GrimVec3 pt)
        {
            Quaternion q = grimQuaternion.ToClrQuaternion();
            q.Normalize();
            Quaternion q1 = new Quaternion(q.X, q.Y, q.Z, q.W);
            q1.Conjugate();

            Quaternion qNode = new Quaternion(pt.X, pt.Y, pt.Z, 0);
            qNode = q * qNode * q1;
            return new GrimVec3((float)qNode.X, (float)qNode.Y, (float)qNode.Z);
        }

        public static GrimVec3 RotateInverse(this GrimQuaternion grimQuaternion, GrimVec3 pt)
        {
            Quaternion q = new Quaternion(-grimQuaternion.X, -grimQuaternion.Y, -grimQuaternion.Z, grimQuaternion.W);
            q.Normalize();
            Quaternion q1 = new Quaternion(q.X, q.Y, q.Z, q.W);
            q1.Conjugate();

            Quaternion qNode = new Quaternion(pt.X, pt.Y, pt.Z, 0);
            qNode = q * qNode * q1;
            return new GrimVec3((float)qNode.X, (float)qNode.Y, (float)qNode.Z);
        }

        public static GrimModelNode FindNode(this GrimModel mdl, string p)
        {
            return mdl.Nodes.Find(mn => mn.Name == p);
        }

        public static IEnumerable<GrimModelNode> GetChildren(this GrimModel mdl, int parentIdx)
        {
            return mdl.Nodes.Where(n => n.Parent == parentIdx);
        }

        public static GrimVec3 Transform(this GrimMat4x3 m, GrimVec3 v)
        {
            return new GrimVec3()
            {
                X = GrimVec3.Dot(m.BaseX, v) + m.Translation.X,
                Y = GrimVec3.Dot(m.BaseY, v) + m.Translation.Y,
                Z = GrimVec3.Dot(m.BaseZ, v) + m.Translation.Z
            };
        }

        public static Matrix3D ToClrMatrix(this GrimMat4x3 m)
        {
            return new Matrix3D()
            {
                M11 = m.BaseX.X,
                M12 = m.BaseX.Y,
                M13 = m.BaseX.Z,
                M21 = m.BaseY.X,
                M22 = m.BaseY.Y,
                M23 = m.BaseY.Z,
                M31 = m.BaseZ.X,
                M32 = m.BaseZ.Y,
                M33 = m.BaseZ.Z,
                OffsetX = m.Translation.X,
                OffsetY = m.Translation.Y,
                OffsetZ = m.Translation.Z
            };
        }

        public static void SetFromClrMatrix(this GrimMat4x3 m, Matrix3D M)
        {
            m.BaseX = new GrimVec3((float)M.M11, (float)M.M12, (float)M.M13);
            m.BaseY = new GrimVec3((float)M.M21, (float)M.M22, (float)M.M23);
            m.BaseZ = new GrimVec3((float)M.M31, (float)M.M32, (float)M.M33);
            m.Translation.X = (float)M.OffsetX;
            m.Translation.Y = (float)M.OffsetY;
            m.Translation.Z = (float)M.OffsetZ;
        }


        public static GrimMat4x3 Mul(this GrimMat4x3 m1, GrimMat4x3 m2)
        {
            Matrix3D M1 = m1.ToClrMatrix();
            Matrix3D M2 = m2.ToClrMatrix();
            M1.Append(M2);
            GrimMat4x3 res = new GrimMat4x3();
            res.SetFromClrMatrix(M1);
            return res;
        }

    }
}
