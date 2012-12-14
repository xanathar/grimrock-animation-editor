using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AnimationEditor;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker.Grim3dAdapters
{
    public class GrimAnimationItemAdapter : IAnimationAdapter
    {
        private GrimAnimationItem m_Obj;
        private IAnimation m_Parent;

        public GrimAnimationItemAdapter(GrimAnimationItem anim, IAnimation parent)
        {
            m_Obj = anim;
            m_Parent = parent;
        }

        public object GetWrappedObject()
        {
            return m_Obj;
        }

        public int MaxFrames
        {
            get { return m_Obj.KeyFrames.Count; }
        }

        public string Name
        {
            get { return m_Obj.NodeName; }
        }

        public bool IsKeyFrame(int frame)
        {
            return false;
        }

        public IAnimation Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        public GrimAnimationItem GetWrappedAnimationItem()
        {
            return m_Obj;
        }
    }
}
