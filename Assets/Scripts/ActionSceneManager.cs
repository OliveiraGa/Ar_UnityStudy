using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSceneManager : MonoBehaviour
{
    private float scrollSpedd;
    private float objectVel = -210f;
    private float objectPosZ = 5.35f;


    private GameObject objetoX;

    [SerializeField]
    Material materialPrefabGround;
    [SerializeField]
    GameObject rootScene;
    [SerializeField]
    GameObject cerca;
    [SerializeField]
    GameObject canos;
    [SerializeField]
    GameObject nuvem;
    [SerializeField]
    GameObject arbusto;
    [SerializeField]
    GameObject pedras;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        scrollSpedd = -0.5f;

        InvokeRepeating("CreateCerca", 1, 0.50f);
        InvokeRepeating("CreateCano", 1, 5.13f);
        InvokeRepeating("CreateArbustoNuvemPedra", 1, 1.4f);

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


    private void CreateArbustoNuvemPedra()
    {
        var sortObject = Random.Range(1, 4);

        var offSetNuvem = Random.Range(1.1f, 2.5f);
        var giroRandom = Random.Range(-180.0f, 180.0f);
        var grioNuvem = 0.0f;
        var posX = 0.0f;

        if((Random.Range(1,3)%2) == 0)
        {
            posX = -0.45f;
            grioNuvem = 0.0f;
        }
        else
        {
            posX = 0.45f;
            grioNuvem = 180.0f;
        }


        switch (sortObject)
        {
            case 1:
                objetoX = (GameObject)Instantiate(arbusto);
                objetoX.transform.parent = rootScene.transform;
                objetoX.transform.position = new Vector3(posX, 0, objectPosZ);
                objetoX.transform.rotation = Quaternion.Euler(-90, giroRandom, 0);
                break;
            case 2:
                objetoX = (GameObject)Instantiate(nuvem);
                objetoX.transform.parent = rootScene.transform;
                objetoX.transform.position = new Vector3(posX, offSetNuvem, objectPosZ);
                objetoX.transform.rotation = Quaternion.Euler(-90, giroRandom, 0);
                break;
            case 3:
                objetoX = (GameObject)Instantiate(pedras);
                objetoX.transform.parent = rootScene.transform;
                objetoX.transform.position = new Vector3(posX, 0, objectPosZ);
                objetoX.transform.rotation = Quaternion.Euler(-90, giroRandom, 0);
                break;
            default:
                break;
                
        }

        objetoX.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, objectVel), ForceMode.Force);

    }
}
