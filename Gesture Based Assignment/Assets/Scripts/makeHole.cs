using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class makeHole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void deleteTri(int index)
    {
        Destroy(this.gameObject.GetComponent<MeshCollider>());  //gets rid of old collider
        Mesh mesh = transform.GetComponent<MeshFilter>().mesh;  
        int[] oldTri = mesh.triangles; 
        int[] newTri = new int[mesh.triangles.Length-3];  //three points

        int i = 0;
        int j = 0;
        while(j < mesh.triangles.Length)
        {
            if(j != index*3)
            {
                newTri[i++] = oldTri[j++];
                newTri[i++] = oldTri[j++];
                newTri[i++] = oldTri[j++];
            }
            else
            {
                j += 3;  //jump 3 values
            }
        }
        transform.GetComponent<MeshFilter>().mesh.triangles = newTri;
        this.gameObject.AddComponent<MeshCollider>();  // new mesh collider
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out hit, 1000.0f))
            {
                deleteTri(hit.triangleIndex); // points to triangle i want to remove....  only counts three triangles to remove
            }
        }
    }
}
