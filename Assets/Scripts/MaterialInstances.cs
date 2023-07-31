using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MaterialInstances : MonoBehaviour
{
    public Texture texture;
    public float cutoffMax;
    public float cutoffMin;
    float cuttoffHeight;
    public Material material;
    public GameObject go;
    public int capacity;

    // Start is called before the first frame update
    void Start()
    {
        cuttoffHeight = cutoffMin;
        go = gameObject;
        material = GetComponent<MeshRenderer>().material;
        material.SetTexture("_Texture", texture);
        material.SetFloat("_Cutoff_Height", cuttoffHeight);
    }

    public void UpdateMaterial(float percentage)
    {
        DOTween.To(() => cuttoffHeight, x => cuttoffHeight = x, cutoffMin + ((cutoffMax - cutoffMin) * (percentage / capacity)), 0.4f)
        .OnUpdate(() =>
        {
            material.SetFloat("_Cutoff_Height", cuttoffHeight);
        });
    }
}
