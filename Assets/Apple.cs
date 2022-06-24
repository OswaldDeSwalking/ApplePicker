using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
  public static float bottomY = -16f;

  private void Update()
  {
    if (transform.position.y < bottomY)
    {
      Destroy(this.gameObject);
      ApplePicker apScreipt = Camera.main.GetComponent<ApplePicker>();
      apScreipt.AppleDestroyed();
    }
  }
}
