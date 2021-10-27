using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeablePrefab;
    private Dictionary<string, GameObject> spawnedPrefab = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        Debug.Log("yes found?");
        foreach (GameObject prefab in placeablePrefab)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            spawnedPrefab.Add(prefab.name, newPrefab);
        }
    }

    private void OnEnable()
    {
        Debug.Log("yes enabled");
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        Debug.Log("yes disabled");
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedPrefab[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Debug.Log("yes found" + name);
        Vector3 position = trackedImage.transform.position;
        GameObject prefab = spawnedPrefab[name];
        prefab.transform.position = position;
        prefab.SetActive(true);

        foreach (GameObject go in spawnedPrefab.Values)
        {
            if (go.name != name)
            {
                go.SetActive(false);
            }
        }

    }

}
