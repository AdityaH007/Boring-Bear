using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SkyboxChanger : MonoBehaviour
{
    public Material[] Skyboxes;
    private Dropdown _dropdown;
    private int currentIndex = 0;

    void Start()
    {
        _dropdown = GetComponent<Dropdown>();
        PopulateDropdown();

        // Start changing the skybox every 2 minutes
        StartCoroutine(ChangeSkyboxPeriodically(20f)); // 120 seconds = 2 minutes
    }

    public void PopulateDropdown()
    {
        List<string> options = new List<string>();
        foreach (Material skybox in Skyboxes)
        {
            options.Add(skybox.name);
        }
        _dropdown.AddOptions(options);
    }

    IEnumerator ChangeSkyboxPeriodically(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            ChangeSkybox();
        }
    }

    public void ChangeSkybox()
    {
        currentIndex = (currentIndex + 1) % Skyboxes.Length;
        RenderSettings.skybox = Skyboxes[currentIndex];
        RenderSettings.skybox.SetFloat("_Rotation", 0);
        _dropdown.value = currentIndex;
    }
}
