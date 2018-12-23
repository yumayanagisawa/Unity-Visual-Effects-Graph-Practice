using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class DataViz : MonoBehaviour
{
    //UnityEngine.Experimental.VFX.VisualEffectAsset
    VisualEffectAsset visualEffectAsset;
    private Material mat;
    private float t;
    private int currentCell = -10; // wait for 10 seconds, then data viz
    private VisualEffect dataViz;
    private float endSpeed = 1.0f;
    // Start is called before the first frame updatef,
    float[] Jews = {
        0.871f, 0.886f, 0.89f, 0.889f, 0.888f, 0.889f, 0.89f, 0.892f, 0.891f, 0.89f, 0.889f, 0.889f,
        0.887f, 0.887f, 0.887f, 0.887f, 0.886f, 0.884f, 0.87f, 0.858f, 0.856f, 0.855f, 0.854f, 0.853f,
        0.852f, 0.853f, 0.851f, 0.848f, 0.846f, 0.843f, 0.841f, 0.84f, 0.838f, 0.836f, 0.831f, 0.829f,
        0.829f, 0.828f, 0.826f, 0.823f, 0.821f, 0.819f, 0.816f, 0.816f, 0.819f, 0.818f, 0.815f, 0.813f,
        0.804f, 0.799f, 0.794f, 0.788f, 0.781f, 0.775f, 0.770f, 0.767f, 0.764f, 0.761f, 0.759f, 0.757f,
        0.756f, 0.756f, 0.755f, 0.753f, 0.752f, 0.751f, 0.750f, 0.749f, 0.748f, 0.746f
    };
    float[] Muslims = {
        0.09f, 0.079f, 0.075f, 0.076f, 0.077f, 0.077f, 0.076f, 0.075f, 0.075f, 0.076f, 0.077f, 0.077f/*0.00fpseudo*/,
        0.078f, 0.078f, 0.079f, 0.08f, 0.081f, 0.083f, 0.094f, 0.105f, 0.107f, 0.108f, 0.11f, 0.111f,
        0.111f, 0.112f, 0.114f, 0.117f, 0.119f, 0.121f, 0.123f, 0.125f, 0.126f, 0.128f, 0.13f, 0.131f,
        0.131f, 0.132f, 0.134f, 0.136f, 0.138f, 0.141f, 0.143f, 0.143f, 0.139f, 0.139f, 0.14f, 0.142f,
        0.145f, 0.146f, 0.148f, 0.150f, 0.151f, 0.153f, 0.155f, 0.158f, 0.160f, 0.162f, 0.164f, 0.166f,
        0.167f, 0.170f, 0.171f, 0.172f, 0.173f, 0.174f, 0.175f, 0.176f, 0.176f, 0.177f
    };
    float[] Christians = {
        0.028f, 0.025f, 0.025f, 0.025f, 0.025f, 0.024f, 0.024f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f/*0.00fpseudo*/,
        0.023f, 0.023f, 0.022f, 0.022f, 0.022f, 0.022f, 0.024f, 0.026f, 0.025f, 0.025f, 0.025f, 0.025f,
        0.025f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f,
        0.023f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f, 0.023f, 0.024f, 0.025f, 0.026f, 0.028f, 0.029f,
        0.021f, 0.021f, 0.021f, 0.021f, 0.021f, 0.021f, 0.021f, 0.021f, 0.021f, 0.021f, 0.021f, 0.021f,
        0.021f, 0.020f, 0.020f, 0.020f, 0.020f, 0.020f, 0.020f, 0.020f, 0.020f, 0.020f
    };
    float[] Druzes = {
        0.012f, 0.01f, 0.01f, 0.01f, 0.01f, 0.011f, 0.011f, 0.01f, 0.01f, 0.011f, 0.011f, 0.011f/*0.00fpseudo*/,
        0.012f, 0.012f, 0.012f, 0.012f, 0.011f, 0.012f, 0.012f, 0.012f, 0.012f, 0.012f, 0.012f, 0.012f,
        0.012f, 0.012f, 0.012f, 0.012f, 0.012f, 0.012f, 0.013f, 0.013f, 0.013f, 0.013f, 0.016f, 0.016f,
        0.016f, 0.017f, 0.017f, 0.017f, 0.017f, 0.017f, 0.018f, 0.017f, 0.017f, 0.017f, 0.017f, 0.017f,
        0.016f, 0.016f, 0.016f, 0.016f, 0.016f, 0.016f, 0.016f, 0.016f, 0.016f, 0.016f, 0.017f, 0.017f,
        0.017f, 0.017f, 0.017f, 0.017f, 0.016f, 0.016f, 0.016f, 0.016f, 0.016f, 0.016f
    };
    
    void Start()
    {
        Debug.Log(Jews.Length.ToString()); //70
        // assign data art
        dataViz = GetComponent<VisualEffect>();
        SetIitialValues();
        // initialise the "t"
        t = 0.0f;
    }

    void SetIitialValues()
    {
        dataViz.SetFloat("Radius Size Jewish", Jews[0]);// materials.Length;
        dataViz.SetFloat("Radius Size Muslim", Muslims[0]);
        dataViz.SetFloat("Radius Size Christian", Christians[0]);
        dataViz.SetFloat("Radius Size Druze", Druzes[0]);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<Renderer>().materials[0].shaderKeywords);// HasProperty("Radius Size Jewish").ToString());
        // update time
        t += Time.deltaTime;
        if (t >= 1.0f)
        {
            // increment currentCell
            currentCell++;
            // reset t
            t = 0.0f;
            // data viz
            if (currentCell < -10)
            {
                if (endSpeed > 0)
                {
                    endSpeed -= 10 * Time.deltaTime;
                }
                dataViz.SetFloat("Particle Speed For End", endSpeed);
            }
            if (currentCell == -10)
            {
                dataViz.Play();
                SetIitialValues();
                endSpeed = 1.0f;
                dataViz.SetFloat("Particle Speed For End", endSpeed);
            }
            else if (currentCell >= 70)
            {
                dataViz.Stop();
                currentCell = -30;
                dataViz.SetFloat("Particle Speed For End", 0.0f);
            }
            else if (currentCell > 0)
            {
                dataViz.SetFloat("Radius Size Jewish", Jews[currentCell]);
                dataViz.SetFloat("Radius Size Muslim", Muslims[currentCell]);
                dataViz.SetFloat("Radius Size Christian", Christians[currentCell]);
                dataViz.SetFloat("Radius Size Druze", Druzes[currentCell]);
                //Debug.Log("viz started");
            }
            
        }

    }
    
}
