using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostGlobalController : MonoBehaviour
{
    private PostProcessVolume globalVolume;

    private void Awake()
    {
        globalVolume = GetComponent<PostProcessVolume>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //statusColorEffect(true);

    }

    public void statusColorEffect(bool status)
    {
        ColorGrading colorFX;
        globalVolume.profile.TryGetSettings(out colorFX);
        colorFX.active = status;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerContoller.onDamage += statusColorEffect;
    }
}
