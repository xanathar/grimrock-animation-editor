using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimationEditor;
using GrimrockAnimationTweaker.Grim3dAdapters;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public class MultiframeClip
    {
        Dictionary<string, List<GrimAnimationKeyFrame>> m_Contents = new Dictionary<string, List<GrimAnimationKeyFrame>>();

        public int Length { get { return m_Contents.Values.First().Count; } }

        public IEnumerable<GrimAnimationKeyFrame> GetKeyFramesForAnimationItem(GrimAnimationItem item)
        {
            return m_Contents[item.NodeName];
        }

        public void AddRange(GrimAnimationItem item, int from, int to)
        {
            List<GrimAnimationKeyFrame> frames = item.KeyFrames.GetRange(from, to - from + 1).Select(i => i.Clone()).ToList();
            m_Contents.Add(item.NodeName, frames);
        }

        public static MultiframeClip FromSelection(AnimSelection sel)
        {
            if (sel.Animation == null) return null;
            if (sel.Animation.Parent != null) return null;
            GrimAnimationAdapter adp = sel.Animation as GrimAnimationAdapter;
            if (adp == null) return null;

            MultiframeClip clip = new MultiframeClip();

            foreach (GrimAnimationItem gai in adp.GetWrappedAnimation().Items)
            {
                clip.AddRange(gai, Math.Max(0, sel.FrameIn ?? 0), Math.Min(sel.FrameOut ?? gai.KeyFrames.Count - 1, gai.KeyFrames.Count - 1));
            }

            return clip;
        }

        public void ExpandShrink(int newLen)
        {
            foreach (List<GrimAnimationKeyFrame> lst in m_Contents.Values)
                ExpandShrink(newLen, lst);
        }

        private static void ExpandShrink(int newLen, List<GrimAnimationKeyFrame> lst)
        {
            List<GrimAnimationKeyFrame> old = new List<GrimAnimationKeyFrame>();
            old.AddRange(lst);
            lst.Clear();
            int oldLen = old.Count - 1;

            for (int i = 0; i < newLen; i++)
            {
                double proportionalIndex = ((double)i) / ((double)newLen-1) * ((double)oldLen);
                int loOldIdx = (int)(Math.Floor(proportionalIndex));
                int hiOldIdx = loOldIdx + 1;
                double k = proportionalIndex - Math.Floor(proportionalIndex);

                if (loOldIdx < 0)
                {
                    loOldIdx = hiOldIdx = 0;
                }
                if (hiOldIdx > oldLen)
                {
                    hiOldIdx = hiOldIdx = oldLen - 1;
                }

                loOldIdx = Math.Max(0, Math.Min(oldLen, loOldIdx));
                hiOldIdx = Math.Max(0, Math.Min(oldLen, hiOldIdx));

                GrimAnimationKeyFrame kf = Interpolator.LinearInterpolateAll(old[loOldIdx], old[hiOldIdx], (float)k);
                lst.Add(kf);
            }

        }
    }
}
