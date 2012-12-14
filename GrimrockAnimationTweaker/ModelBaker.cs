using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        IEnumerable<int> PreOrderVisit(int root = -1)
        {
            if (root >= 0)
                yield return root;

            for (int i = 0, len = m_Model.Nodes.Count; i < len; i++)
            {
                if (m_Model.Nodes[i].Parent == root)
                {
                    foreach (int n in PreOrderVisit(i)) 
                        yield return n;
                }
            }
        }


        public void BakeNodes(IEnumerable<string> nodesToBake)
        {
            HashSet<string> nodesToBakeSet = new HashSet<string>(nodesToBake);

            foreach (int nodeidx in PreOrderVisit())
            {
                if (nodesToBakeSet.Contains(m_Model.Nodes[nodeidx].Name))
                {
                    BakeNode(nodeidx);
                }
            }
        }

        private void BakeNode(int nodeidx)
        {
            GrimModelNode node = m_Model.Nodes[nodeidx];
            Debug.WriteLine(string.Format("Baking node {0}", node.Name));

            GrimMat4x3 matrix = node.LocalToParent;
            node.LocalToParent = GrimMat4x3.IdentityMatrix();

            if (node.Type == 0)
            {
                Debug.WriteLine(string.Format("Baking vertices {0}", node.Name));
                BakeVertices(node.MeshEntity, matrix);
            }

            foreach (GrimModelNode childnode in m_Model.GetChildren(nodeidx))
            {
                Debug.WriteLine(string.Format("Baking matrix of {0}", childnode.Name));
                BakeMatrix(childnode, matrix);
            }
        }

        private void BakeVertices(GrimModelMeshEntity grimModelMeshEntity, GrimMat4x3 matrix)
        {
            GrimModelVertexArray vertArray = grimModelMeshEntity.MeshData.VertexArrays[0];

            GrimVec3[] vertices = vertArray.getVertexDataAsVec3Array();

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = matrix.Transform(vertices[i]);
            }

            vertArray.putVertexDataAsVec3Array(vertices);
        }

        private void BakeMatrix(GrimModelNode node, GrimMat4x3 matrix)
        {
            node.LocalToParent = matrix.Mul(node.LocalToParent);
        }

        


    }
}
