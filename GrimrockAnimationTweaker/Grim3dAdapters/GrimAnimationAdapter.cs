using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AnimationEditor;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker.Grim3dAdapters
{
    public class GrimAnimationAdapter : IAnimationAdapter, IPropertyGridProvider
    {
        private GrimAnimation m_Obj;

        public class PropertyGridObject
        {
            GrimAnimationAdapter m_Parent;

            public PropertyGridObject(GrimAnimationAdapter gaa)
            {
                m_Parent = gaa;
            }

            public float FramesPerSecond
            {
                get { return m_Parent.m_Obj.FramesPerSecond; }
                set { m_Parent.m_Obj.FramesPerSecond = value; }
            }
        }


        public GrimAnimationAdapter(GrimAnimation anim)
        {
            m_Obj = anim;
        }

        public object GetWrappedObject()
        {
            return m_Obj;
        }

        public int MaxFrames
        {
            get { return m_Obj.NumFrames; }
        }

        public string Name
        {
            get { return string.IsNullOrEmpty(m_Obj.AnimationName) ? Path.GetFileNameWithoutExtension(m_Obj.OriginalFilePath) : m_Obj.AnimationName; }
        }

        public bool IsKeyFrame(int frame)
        {
            return false;
        }

        public IAnimation Parent
        {
            get { return null; }
        }

        public GrimAnimation GetWrappedAnimation()
        {
            return m_Obj;
        }

        public object GetPropertyGridObject()
        {
            return new PropertyGridObject(this);
        }
    }
}
