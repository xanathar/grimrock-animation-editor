using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public class Snapshot
    {
        Dictionary<string, GrimAnimation> m_Anims = new Dictionary<string, GrimAnimation>();
        string m_Name;

        public Snapshot(string name, IEnumerable<GrimAnimation> anims)
        {
            m_Anims = anims.Select(a => a.Clone()).ToDictionary(a => a.OriginalFilePath);
            m_Name = name;
        }

        public override string ToString()
        {
            return m_Name;
        }

        public bool RestoreOver(IEnumerable<GrimAnimation> anims)
        {
            bool bigChangesDone = false;

            foreach (GrimAnimation ga in anims)
            {
                if (!m_Anims.ContainsKey(ga.OriginalFilePath))
                    continue;

                GrimAnimation orig = m_Anims[ga.OriginalFilePath];

                ga.AnimationName = orig.AnimationName;
                ga.FramesPerSecond = orig.FramesPerSecond;


                GrimAnimationItem[] newItems = CopyItems(orig.Items, ga.Items);

                if (newItems != ga.Items)
                {
                    bigChangesDone = true;
                    ga.Items = newItems;
                }

                ga.Items = newItems;
                ga.Magic = orig.Magic;
                ga.NumFrames = orig.NumFrames;
                ga.Version = orig.Version;
            }

            return bigChangesDone;
        }

        private GrimAnimationItem[] CopyItems(GrimAnimationItem[] newItems, GrimAnimationItem[] oldItems)
        {
            if (CompareItems(newItems, oldItems))
            {
                return newItems.Select(i => i.Clone()).ToArray();
            }
            else
            {
                for (int i = 0; i < newItems.Length; i++)
                {
                    oldItems[i].KeyFrames = newItems[i].KeyFrames.Select(kf => kf.Clone()).ToList();
                }

                return oldItems;
            }
        }

        private bool CompareItems(GrimAnimationItem[] newItems, GrimAnimationItem[] oldItems)
        {
            if (newItems.Length != oldItems.Length)
                return true;

            for (int i = 0; i < newItems.Length; i++)
            {
                if (newItems[i].NodeName != oldItems[i].NodeName)
                    return true;
            }

            return false;
        }
    }
}
