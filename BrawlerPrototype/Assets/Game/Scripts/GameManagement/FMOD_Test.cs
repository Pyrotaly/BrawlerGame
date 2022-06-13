using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

 public class FMOD_Test : MonoBehaviour
{
    public static FMOD_Test instance;

    public EventReference[] fmodEvent;

    //[SerializeField]  public Dictionary<string, EventReference> allSoundsDictionary = new Dictionary<string, EventReference>();

    public static void PlaySound(string path)
    {
        //EventReference s = Array.Find(fmodEvent, EventReference => EventReference.Path == path);
        //String s = Array.Find(fmodEvent, EventReference.Find(path == EventReference.Path));

        RuntimeManager.PlayOneShot(path); //, GetComponent<Transform>().position);
    }

    public void Start()
    {
        //PlaySound("event:/Okay");
    }
}
