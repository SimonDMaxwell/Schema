using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintRotator : MonoBehaviour
{
    public GameObject[] _rotation;
    Dictionary<string, GameObject> rotation = new Dictionary<string, GameObject>();
    private void Start()
    {
        rotation.Add("Demon", _rotation[0]);
        rotation.Add("Natural", _rotation[1]);
        rotation.Add("Sinner", _rotation[2]);
    }

    public void Rotate(string str)
    {
        for (int i = 0; i < _rotation.Length; i++)
        {
            rotation[str].SetActive(false);
        }
        rotation[str].SetActive(true);
    }
}
