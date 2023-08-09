using System.IO;
using UnityEngine;

public static class ObjExporter
{
    public static void MeshToFile(Mesh mesh, string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine("g " + mesh.name);
            foreach (Vector3 v in mesh.vertices)
            {
                sw.WriteLine(string.Format("v {0} {1} {2}", v.x, v.y, v.z));
            }
            sw.WriteLine("");
            foreach (Vector3 vn in mesh.normals)
            {
                sw.WriteLine(string.Format("vn {0} {1} {2}", vn.x, vn.y, vn.z));
            }
            sw.WriteLine("");
            foreach (Vector2 vt in mesh.uv)
            {
                sw.WriteLine(string.Format("vt {0} {1}", vt.x, vt.y));
            }
            for (int material = 0; material < mesh.subMeshCount; material++)
            {
                sw.WriteLine("");
                sw.WriteLine("usemtl " + "Material" + material);
                sw.WriteLine("usemap " + "Material" + material);
                int[] triangles = mesh.GetTriangles(material);
                for (int i = 0; i < triangles.Length; i += 3)
                {
                    sw.WriteLine(string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}", triangles[i] + 1, triangles[i + 1] + 1, triangles[i + 2] + 1));
                }
            }
        }
    }
}
