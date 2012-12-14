using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public class DataDumper
    {
        TextWriter tw;
        GrimModel model; 
        string modelfilename;


        public DataDumper(GrimModel model, string modelfilename, TextWriter tw)
        {
            this.tw = tw;
            this.model = model;
            this.modelfilename = modelfilename;
        }

        void Header(string text, string param)
        {
            tw.WriteLine("");
            tw.WriteLine("=========================================================================");
            Value(text, param);
            tw.WriteLine("=========================================================================");
        }

        private void Value(string text, object param)
        {
            tw.WriteLine("{0} = {1}", text, param != null ? param.ToString() : "(null)");
        }


        public void DumpModel()
        {
            Header("MODEL", modelfilename);
            Value("Version", model.Version);
            Value("Nodes.Count", model.Nodes.Count);

            foreach (GrimModelNode node in model.Nodes)
            {
                DumpNode(node);
            }
        }

        void Space()
        {
            tw.WriteLine();
        }

        private void DumpNode(GrimModelNode node)
        {
            Header("Node", node.Name);
            Value("LocalToParent", node.LocalToParent);
            Value("Parent", node.Parent);

            if (node.Parent >= 0)
                Value("Parent Name", model.Nodes[node.Parent].Name);

            Value("Type", node.Type);
            Value("TypeDesc", node.Type == 0 ? "MESH" : "DUMMY");

            if (node.Type != 0) return;

            Space();
            Value("MeshEntity.CastShadow", node.MeshEntity.CastShadow);
            Value("MeshEntity.EmissiveColor", node.MeshEntity.EmissiveColor);

            if (node.MeshEntity.Bones != null)
            {
                for (int i = 0; i < node.MeshEntity.Bones.Length; i++)
                {
                    Value("MeshEntity.Bones[" + i + "].BoneNodeIndex", node.MeshEntity.Bones[i].BoneNodeIndex);
                    Value("MeshEntity.Bones[" + i + "].InvRestMatrix", node.MeshEntity.Bones[i].InvRestMatrix);
                }
            }

            Space();
            Value("MeshEntity.MeshData.NumVertices", node.MeshEntity.MeshData.NumVertices);
            Value("MeshEntity.MeshData.BoundCenter", node.MeshEntity.MeshData.BoundCenter);
            Value("MeshEntity.MeshData.BoundRadius", node.MeshEntity.MeshData.BoundRadius);
            Value("MeshEntity.MeshData.BoundMin", node.MeshEntity.MeshData.BoundMin);
            Value("MeshEntity.MeshData.BoundMax", node.MeshEntity.MeshData.BoundMax);

            for (int i = 0; i < node.MeshEntity.MeshData.VertexArrays.Length; i++)
            {
                GrimModelVertexArray arr = node.MeshEntity.MeshData.VertexArrays[i];

                string[] ARRINDEXNAMES = { "POSITION", "NORMAL", "TANGENT", "BITANGENT", "COLOR", "TEXCOORD0", "TEXCOORD1", "TEXCOORD2", "TEXCOORD3", "TEXCOORD4", "TEXCOORD5", "TEXCOORD6", "TEXCOORD7", "BONE_INDEX", "BONE_WEIGHT" };
                string arrIndexName;

                if (i >= 0 && i < ARRINDEXNAMES.Length)
                {
                    arrIndexName = ARRINDEXNAMES[i];
                }
                else
                {
                    arrIndexName = i.ToString();
                }
                arrIndexName = "[" + arrIndexName + "]";
                

                if (arr != null && arr.RawVertexData != null)
                {
                    string[] DATATYPENAMES = { "byte", "int16", "int32", "float32" };

                    Space();

                    Value("MeshEntity.MeshData.VertexArrays" + arrIndexName + ".DataType", arr.DataType);
                    Value("MeshEntity.MeshData.VertexArrays" + arrIndexName + ".Dim", arr.Dim);
                    Value("MeshEntity.MeshData.VertexArrays" + arrIndexName + ".Stride", arr.Stride);
                    
                    if (arr.DataType >= 0 && arr.DataType < DATATYPENAMES.Length)
                        Value("MeshEntity.MeshData.VertexArrays" + arrIndexName + ".DataTypeName", DATATYPENAMES[arr.DataType]);
                    else
                        Value("MeshEntity.MeshData.VertexArrays" + arrIndexName + ".DataTypeName", "UNKNOWN!");

                    switch (arr.DataType)
                    {
                        case 0:
                            Value("MeshEntity.MeshData.VertexArrays" + arrIndexName + ".Data", DumpVertexArray(arr.getVertexDataAsByteArray()));
                            break;
                        case 1:
                            Value("MeshEntity.MeshData.VertexArrays" + arrIndexName + ".Data", DumpVertexArray(arr.getVertexDataAsInt16Array()));
                            break;
                        case 2:
                            Value("MeshEntity.MeshData.VertexArrays" + arrIndexName + ".Data", DumpVertexArray(arr.getVertexDataAsInt32Array()));
                            break;
                        case 3:
                            Value("MeshEntity.MeshData.VertexArrays" + arrIndexName + ".Data", DumpVertexArray(arr.getVertexDataAsFloatArray()));
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        string DumpVertexArray<T>(T[][] arr)
        {
            StringBuilder sb = new StringBuilder();


            for (int ii = 0; ii < Math.Min(arr.Length, 7); ii++)
            {
                T[] iarr = arr[ii];

                sb.Append("{ ");
                bool firstinner = true;
                for (int i = 0; i < Math.Min(iarr.Length, 7); i++)
                {
                    if (!firstinner)
                        sb.Append(", ");
                    sb.Append(iarr[i]);
                    firstinner = false;
                }

                sb.Append("}, ");
            }

            return sb.ToString();
        }

    }
}
