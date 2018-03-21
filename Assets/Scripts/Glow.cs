using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    float maxSize = 250;
    float growingSpeed = 120;
    bool glowing = true;
    float waitingTime = 2f;

    public void GlowTheCubes()
    {
        StartCoroutine(GlowUp());
    }
    IEnumerator GlowUp()
    {
        while (glowing)
        {
            while (maxSize > transform.localScale.x)
            {
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growingSpeed;
                yield return null;
            }

            while (200 < transform.localScale.x) // The original square size is 200x200
            {
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growingSpeed;
                yield return null;
            }
            glowing = false;
        }
    }
}
