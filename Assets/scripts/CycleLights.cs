using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class CycleLights : MonoBehaviour {
    public Transform spawnTarget;
    public GameObject[] prefabs;

    public GameObject spawnedInstance;

    int index;

    [SerializeField]
    RigidbodyFirstPersonController fpsController;

    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            index = (index + 1) % prefabs.Length;
            if (spawnedInstance != null)
                GameObject.Destroy(spawnedInstance);
            if (prefabs[index] != null)
            {
                spawnedInstance = GameObject.Instantiate(prefabs[index]) as GameObject;
                spawnedInstance.transform.parent = spawnTarget;
                spawnedInstance.transform.localPosition = Vector3.zero;
                spawnedInstance.transform.localRotation = Quaternion.identity;
            }
        }
        if(Input.GetButtonDown("Fire2"))
        {
            fpsController.enabled = !fpsController.enabled;
        }
        if(!fpsController.enabled && spawnedInstance != null)
        {

            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");


            if (Input.GetButton("Fire3"))
            {

                if (Mathf.Abs(xMove) > 0.01f)
                   spawnedInstance.transform.localScale = spawnedInstance.transform.localScale + Vector3.right * xMove * Time.deltaTime;
                if(Mathf.Abs(yMove) > 0.01f)
                    spawnedInstance.transform.localScale = spawnedInstance.transform.localScale + Vector3.up * yMove * Time.deltaTime;
            }else
            {

                if (Mathf.Abs(xMove) > 0.01f)
                    spawnedInstance.transform.localPosition = spawnedInstance.transform.localPosition + Vector3.right * xMove * Time.deltaTime;
                if (Mathf.Abs(yMove) > 0.01f)
                    spawnedInstance.transform.localPosition = spawnedInstance.transform.localPosition + Vector3.forward * yMove * Time.deltaTime;
            }

        }

    }
}
