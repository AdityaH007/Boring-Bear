using System.Collections;
using UnityEngine;

public class SkyBoxUpdate : MonoBehaviour
{
    public Material[] skyboxes;
    public float transitionDuration = 1.0f;

    private int currentIndex = 0;
    private Material currentSkybox;
    private Material targetSkybox;
    private float transitionStartTime;

    void Start()
    {
        currentSkybox = skyboxes[currentIndex];
        RenderSettings.skybox = currentSkybox;
        StartCoroutine(ChangeSkybox(20f));
    }

    IEnumerator ChangeSkybox(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            currentIndex = (currentIndex + 1) % skyboxes.Length;
            targetSkybox = skyboxes[currentIndex];
            transitionStartTime = Time.time;
        }
    }

    void Update()
    {
        if (targetSkybox != null)
        {
            float t = (Time.time - transitionStartTime) / transitionDuration;
            RenderSettings.skybox = LerpSkybox(currentSkybox, targetSkybox, Mathf.Clamp01(t));

            if (t >= 1.0f)
            {
                currentSkybox = targetSkybox;
                targetSkybox = null;
            }
        }
    }

    Material LerpSkybox(Material start, Material end, float t)
    {
        Material result = new Material(Shader.Find("RenderFX/Skybox"));

        result.SetColor("_Tint", Color.Lerp(start.GetColor("_Tint"), end.GetColor("_Tint"), t));
        result.SetTexture("_MainTex", start.GetTexture("_MainTex"));
        result.SetTexture("_Tex", start.GetTexture("_Tex"));

        return result;
    }
}
