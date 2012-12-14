using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public static class Interpolator
    {

        public static void Invert<T>(FrameRange range, Func<GrimAnimationKeyFrame, T> getter, Action<GrimAnimationKeyFrame, T> setter)
        {
            Stack<T> stack = new Stack<T>();
            foreach (GrimAnimationKeyFrame kf in range.KeyFrames)
                stack.Push(getter(kf));
            foreach (GrimAnimationKeyFrame kf in range.KeyFrames)
                setter(kf, stack.Pop());
        }


        public static GrimQuaternion Slerp(GrimQuaternion min, GrimQuaternion max, float k)
        {
            Quaternion q1 = new Quaternion(min.X, min.Y, min.Z, min.W);
            Quaternion q2 = new Quaternion(max.X, max.Y, max.Z, max.W);

            Quaternion q = Quaternion.Slerp(q1, q2, (double)k);

            return new GrimQuaternion((float)q.X, (float)q.Y, (float)q.Z, (float)q.W);
        }

        public static float Smooth(float t)
        {
            return t * t * (3.0f - 2.0f * t);
        }

        public static GrimVec3 Vec3Interpolator(GrimVec3 min, GrimVec3 max, float k)
        {
            GrimVec3 result = new GrimVec3();
            result.X = (max.X - min.X) * k + min.X;
            result.Y = (max.Y - min.Y) * k + min.Y;
            result.Z = (max.Z - min.Z) * k + min.Z;
            return result;
        }

        public static GrimAnimationKeyFrame LinearInterpolateAll(GrimAnimationKeyFrame kf0, GrimAnimationKeyFrame kf1, float k)
        {
            GrimAnimationKeyFrame kf = new GrimAnimationKeyFrame();

            kf.DebugLevel = kf0.DebugLevel;
            kf.Position = Vec3Interpolator(kf0.Position, kf1.Position, k);
            kf.Scale = Vec3Interpolator(kf0.Scale, kf1.Scale, k);
            kf.Rotation = Slerp(kf0.Rotation, kf1.Rotation, k);

            return kf;
        }


        public static void Interpolate<T>(FrameRange range, Func<GrimAnimationKeyFrame, T> getter, Action<GrimAnimationKeyFrame, T> setter, Func<T, T, float, T> interpolator, Func<float, float> smoother)
        {
            T min = getter(range.Animation.KeyFrames[range.MinFrame]);
            T max = getter(range.Animation.KeyFrames[range.MaxFrame]);

            for (int frame = range.MinFrame + 1; frame < range.MaxFrame; frame++)
            {
                GrimAnimationKeyFrame kf = range.Animation.KeyFrames[frame];
                float k = (float)(frame - range.MinFrame) / (float)(range.MaxFrame - range.MinFrame);
                k = smoother(k);
                T result = interpolator(min, max, k);
                setter(kf, result);
            }
        }
    }
}
