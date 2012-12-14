using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimationEditor
{
    public class AnimationPod : IAnimation
    {
        public int MaxFrames { get; set;}
        public string Name { get; set;}

        private HashSet<int> m_KeyFrames = new HashSet<int>();

        public HashSet<int> KeyFrames
        {
            get { return m_KeyFrames; }
        }

        public bool IsKeyFrame(int frame)
        {
            return m_KeyFrames.Contains(frame);
        }

        public IAnimation Parent { get; set; }
    }
}
