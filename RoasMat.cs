using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoasMat : MonoBehaviour
{
    Material Mat;
    Vector2 offset = Vector2.zero;
    public float Speed;

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Mat = meshRenderer.material;
    }
    void Update()
    {
        offset.y += Speed * Time.deltaTime;
        Mat.SetTextureOffset("_MainTex", offset);
    }
}