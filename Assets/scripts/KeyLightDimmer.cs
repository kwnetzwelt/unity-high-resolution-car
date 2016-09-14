using UnityEngine;
using System.Collections;

public class KeyLightDimmer : MonoBehaviour {
    public Material sharedMaterial;
    float emission = 2;
	
    void OnEnable()
    {
        Apply();
    }

    void Apply()
    {

        Color finalColor = Color.white * Mathf.LinearToGammaSpace(emission);
        sharedMaterial.SetColor("_EmissionColor", finalColor);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.U))
        {
            emission += Time.deltaTime;
            Apply();
        }else if(Input.GetKey(KeyCode.Z ))
        {

            emission -= Time.deltaTime;
            Apply();
            
        }
    }
}
