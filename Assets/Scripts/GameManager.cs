using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float timer = 60f;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime * 1f;
        }
    }
}
