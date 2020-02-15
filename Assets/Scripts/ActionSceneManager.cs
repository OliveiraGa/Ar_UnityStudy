using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSceneManager : MonoBehaviour
{
    float scrollSpedd;
    [SerializeField]
    Material materialPrefabGround;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        scrollSpedd = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpedd;
        materialPrefabGround.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
