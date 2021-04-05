using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class FindAssets : MonoBehaviour
{
    // Find all object that have an Audio component

    [MenuItem("Zulu/FindAssets Audio")]
    static void FindAudio()
    {
        
        Debug.Log("Find Assets Script started...");
        // Find all Prefabs that have an Audio component under my Prefabs folder
        Debug.Log("Finding all Prefabs that have an Audio Component...");

        string[] guids = AssetDatabase.FindAssets("t:Object", new[] { "Assets/Prefabs" });

        foreach (string guid in guids)
        {
            //Debug.Log(AssetDatabase.GUIDToAssetPath(guid));
            string myObjectPath = AssetDatabase.GUIDToAssetPath(guid);
            Object[] myObjs = AssetDatabase.LoadAllAssetsAtPath(myObjectPath);

            //Debug.Log("printing myObs now...");
            foreach (Object thisObject in myObjs)
            {
                //Debug.Log(thisObject.name);
                //Debug.Log(thisObject.GetType().Name); 
                string myType = thisObject.GetType().Name;
                if (myType == "AudioSource")
                {
                    Debug.Log("Audio Source Found in...  " + thisObject.name + " at " + myObjectPath);
                }
            }
        }

        // Find all object that have an Audio component in the current Scene
        Debug.Log("Finding all Assets in the Current Scene that have an Audio Component...");
        AudioSource[] myAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        Debug.Log("Found " + myAudioSources.Length + " objects with an AudioSource attached");
        foreach (AudioSource item in myAudioSources)
        {
            Debug.Log(item.gameObject.name);
        }
    }
}

