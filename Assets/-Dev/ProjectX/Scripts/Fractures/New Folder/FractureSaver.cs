using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Project.Scripts.Fractures
{
    public class FractureSaver : MonoBehaviour
    {
        GameObject fracture;
        void Awake()
        {
            fracture = GameObject.Find("Fracture");
        }

        void Start()
        {
            StartCoroutine(Delay());
        }

        public IEnumerator Delay()
        {
            yield return new WaitForSeconds(10);
            SaveFracturedObjects(fracture.GetComponent<ChunkGraphManager>(), "Assets/ExportedChunks");
        }
        // Bu metot çağrıldığında, belirtilen ChunkGraphManager'ın altındaki parçaları kaydeder.
        public static void SaveFracturedObjects(ChunkGraphManager graphManager, string savePath)
        {
            Transform root = graphManager.transform;
            List<Rigidbody> rigidbodies = new List<Rigidbody>(root.GetComponentsInChildren<Rigidbody>());

            foreach (Rigidbody rb in rigidbodies)
            {
                SaveChunk(rb.gameObject, savePath);
            }
        }

        // Tek bir parçayı kaydeder.
        private static void SaveChunk(GameObject chunk, string savePath)
        {
            MeshFilter meshFilter = chunk.GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = chunk.GetComponent<MeshRenderer>();
            Rigidbody rb = chunk.GetComponent<Rigidbody>();

            if (meshFilter && meshRenderer && rb)
            {
                // İhtiyaç duyulan diğer bileşenleri ekleyebilirsiniz (örneğin, collider).

                // Şekli kaydetmek için aşağıdaki satırı kullanabilirsiniz.
                // Örnek olarak, OBJ formatında kaydediyorum. Farklı formatlar kullanabilirsiniz.
                string chunkSavePath = $"{savePath}/{chunk.name}.obj";
                SaveMeshAsOBJ(chunk.GetComponent<MeshFilter>().mesh, chunkSavePath);

                // Oluşturulan yeni Chunk objesini istediğiniz yere kaydedebilirsiniz.
                // Örneğin, Resources klasörüne kaydediyorum.
                // Bu, daha iyi bir kaydetme yöntemi düşünüldüğünde değiştirilebilir.
                //string prefabPath = $"Assets/ExportedChunks/Prefab/{chunk.name}.prefab";
                //PrefabUtility.SaveAsPrefabAsset(chunk, prefabPath);

                // Oluşturulan yeni Chunk objesini sahneye de ekleyebilirsiniz.
                // Örneğin, yorumu kaldırırsanız bu şekilde eklenir:
                // Instantiate(newChunkObject);
            }
            else
            {
                Debug.LogError("Chunk is missing required components (MeshFilter, MeshRenderer, Rigidbody).");
            }
        }

        // Mesh'i OBJ formatında kaydetmek için kullanılır.
        private static void SaveMeshAsOBJ(Mesh mesh, string path)
        {
            ObjExporter.MeshToFile(mesh, path);
        }
    }
}