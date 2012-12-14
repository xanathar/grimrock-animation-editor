using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimationEditor
{
    public class AnimSelection
    {
        public SelectionType Type { get; set; }
        public IList<IAnimation> Animations { get; private set; }
        public IAnimation Animation { get; set; }
        public int? FrameIn { get; set; }
        public int? FrameOut { get; set; }

        public AnimSelection()
        {
            Animations = new List<IAnimation>();
        }

        public override string ToString()
        {
            switch (Type)
            {
                case SelectionType.None:
                    return "[None]";
                case SelectionType.Frame:
                case SelectionType.FrameRange:
                    return string.Format("[{0}: {1} = {2} -> {3}]", Type, Animation.Name, FrameIn, FrameOut);
                case SelectionType.Animation:
                    return string.Format("[{0}: {1}]", Type, Animation.Name);
                case SelectionType.MultipleAnimations:
                    return string.Format("[{0}: {1}]", Type, string.Join(", ", Animations.Select(a => a.Name).ToArray()));
                default:
                    return "[ERROR!! - Unknown Type]";
            }
        }

    }
}
