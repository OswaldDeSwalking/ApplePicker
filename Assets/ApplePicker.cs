using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")] public GameObject basketPrefab;

    public int numBasket = 3;

    public float basketBottomY = -14f;

    public float basketSpacingY = 2f;

    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0;i<numBasket; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

  public  void AppleDestroyed()
  {
      GameObject[] tempAppleArray = GameObject.FindGameObjectsWithTag("Apple");
      foreach (var tGO in tempAppleArray)
      {
          Destroy(tGO);
      }

      int bsketIndex = basketList.Count - 1;
      GameObject tBasketGO = basketList[bsketIndex];
      basketList.RemoveAt(bsketIndex);
      Destroy(tBasketGO);
      if (basketList.Count == 0)
      {
          SceneManager.LoadScene("_Scene_0");
      }
  }

    // Update is called once per frame
    void Update()
    {
        
    }
}
