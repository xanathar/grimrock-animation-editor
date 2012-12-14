using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public class ModelBaker
    {
        readonly GrimModel m_Model;

        public ModelBaker(GrimModel model)
        {
            m_Model = model;
        }

        IEnumerable<int> PostOrderVisit(int root = -1)
        {
            for(int i = 0, len = m_Model.Nodes.Count; i < len; i++)
            {
                if (m_Model.Nodes[i].Parent == root)
                {
                    foreach(int n in PostOrderVisit(i)) 
                        yield return n;
                }
            }

            if (root >= 0)
                yield return root;
        }


        public void BakeNodes(IEnumerable<string> nodesToBake)
        {

        }




    }
}
