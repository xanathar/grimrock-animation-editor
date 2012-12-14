using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimationEditor
{
    public interface IAnimation
    {
        int MaxFrames { get; }
        string Name { get; }

        bool IsKeyFrame(int frame);

        IAnimation Parent { get; }
    }
}
