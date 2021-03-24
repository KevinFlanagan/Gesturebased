using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteScreen : MonoBehaviour
{
    public GameObject levelCompScrn;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerCubeTag")
        {
            levelCompScrn.gameObject.SetActive(true);
        }
    }
}
