using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimationEditor
{
    [Flags]
    public enum SelectionType
    {
        None = 0,
        Frame = 0x1,
        FrameRange = 0x2,
        Animation = 0x4,
        MultipleAnimations = 0x8
    }
}
