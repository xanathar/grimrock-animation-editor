using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimationEditor;
using GrimrockAnimationTweaker.Grim3dAdapters;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public class FrameRange
    {
        public GrimAnimationItem Animation { get; set; }
        public int MinFrame { get; set; }
        public int MaxFrame { get; set; }

        public FrameRange()
        { }

        public FrameRange(GrimAnimationItem anim, int? min, int? max)
        {
            Animation = anim;
            MinFrame = Math.Max(min ?? 0, 0);
            MaxFrame = Math.Min(max ?? anim.KeyFrames.Count - 1, anim.KeyFrames.Count - 1);
        }

        public FrameRange(GrimAnimationItem anim)
            : this(anim, null, null)
        {
        }

        public IEnumerable<GrimAnimationKeyFrame> KeyFrames
        {
            get
            {
                for (int i = MinFrame; i <= MaxFrame; i++)
                    yield return Animation.KeyFrames[i];
            }
        }

        public static IEnumerable<FrameRange> FromSelection(AnimSelection sel, bool extendOverMainAnims)
        {
            switch (sel.Type)
            {
                case AnimationEditor.SelectionType.None:
                    yield break;
                case AnimationEditor.SelectionType.Frame:
                case AnimationEditor.SelectionType.FrameRange:
                    {
                        GrimAnimationItemAdapter gai = sel.Animation as GrimAnimationItemAdapter;
                        GrimAnimationAdapter gmi = sel.Animation as GrimAnimationAdapter;

                        if (gai != null)
                        {
                            yield return new FrameRange(gai.GetWrappedAnimationItem(), sel.FrameIn, sel.FrameOut);
                        }
                        else if (gmi != null && extendOverMainAnims)
                        {
                            foreach (GrimAnimationItem gg in gmi.GetWrappedAnimation().Items)
                                yield return new FrameRange(gg, sel.FrameIn, sel.FrameOut);

                        }
                    }
                    break;
                case AnimationEditor.SelectionType.Animation:
                    {
                        GrimAnimationItemAdapter gai = sel.Animation as GrimAnimationItemAdapter;
                        GrimAnimationAdapter gmi = sel.Animation as GrimAnimationAdapter;

                        if (gai != null)
                        {
                            yield return new FrameRange(gai.GetWrappedAnimationItem());
                        }
                        else if (gmi != null && extendOverMainAnims)
                        {
                            foreach (GrimAnimationItem gg in gmi.GetWrappedAnimation().Items)
                                yield return new FrameRange(gg);
                         }
                    }
                    break;
                case AnimationEditor.SelectionType.MultipleAnimations:
                    {
                        HashSet<GrimAnimationItem> anims = new HashSet<GrimAnimationItem>();

                        foreach (IAnimation anim in sel.Animations)
                        {
                            GrimAnimationItemAdapter gai = anim as GrimAnimationItemAdapter;
                            GrimAnimationAdapter gmi = sel.Animation as GrimAnimationAdapter;

                            if (gai != null)
                            {
                                anims.Add(gai.GetWrappedAnimationItem());
                            }
                            else if (gmi != null && extendOverMainAnims)
                            {
                                foreach (GrimAnimationItem gg in gmi.GetWrappedAnimation().Items)
                                    anims.Add(gg);
                            }
                        }

                        foreach (GrimAnimationItem gg in anims)
                            yield return new FrameRange(gg);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
