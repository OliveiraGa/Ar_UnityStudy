using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSceneManager : MonoBehaviour
{
    private float scrollSpedd;
    private float objectVel = -210f;
    private float objectPosZ = 5.35f;


    [SerializeField]
    Material materialPrefabGround;

    [SerializeField]
    GameObject rootScene;
    [SerializeField]
    GameObject cerca;
    [SerializeField]
    GameObject canos;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        scrollSpedd = -0.5f;

        InvokeRepeating("CreateCerca", 1, 0.50f);
        InvokeRepeating("CreateCano", 1, 5.13f);
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpedd;
        materialPrefabGround.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }


    private void CreateCerca()
    {
        GameObject newObjectcerca = (GameObject)Instantiate(cerca);
        newObjectcerca.transform.parent = rootScene.transform;
        newObjectcerca.transform.position = new Vector3(-0.75f, 0, objectPosZ);
        newObjectcerca.transform.rotation = Quaternion.Euler(-90, 0, 0);
        newObjectcerca.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, objectVel), ForceMode.Force);
    }

    private void CreateCano()
    {
        var offsetCano = Random.Range(-0.5f, 0.0f);
        GameObject newCano = (GameObject)Instantiate(canos);
        newCano.transform.parent = rootScene.transform;
        newCano.transform.position = new Vector3(0, offsetCano, objectPosZ);
        newCano.transform.rotation = Quaternion.Euler(0, 0, 0);
        Rigidbody rb = newCano.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, objectVel), ForceMode.Force);
    }
}
