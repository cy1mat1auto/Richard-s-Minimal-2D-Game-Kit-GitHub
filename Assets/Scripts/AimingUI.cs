using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingUI : MonoBehaviour
{
    //This script aligns the particle system which indicates our aim direction:
    ParticleSystem.Particle[] ToUpdate;
    public GameObject ArrowMarker;
    public float AimSensitivity = 2f;
    public ParticleSystem ps;
    private float polarity, flip;
    // Start is called before the first frame update
    void Start()
    {
        if (ArrowMarker == null)
        {
            ArrowMarker = gameObject;
        }

        if (ps == null)
        {
            ps = gameObject.GetComponent<ParticleSystem>();
        }

        if (ToUpdate == null)
        {
            ToUpdate = new ParticleSystem.Particle[ps.main.maxParticles];
        }

    }

    private void Update()
    {
        //This rotates our aim guide such that pushing the mouse up always rotates the guide counterclockwise and pulling
        //The mouse down always rotates the guide clockwise. How is the user experience? Can you make it better?
        if (Input.GetAxis("Mouse Y") != 0)
        {
            ArrowMarker.transform.Rotate(new Vector3(0, 0, 1), Mathf.Clamp(Input.GetAxis("Mouse Y"), -1, 1) * AimSensitivity);
        }
    }

    //This LateUpdate() ensures that the arrows of our particle system points along their path of travel.
    void LateUpdate()
    {
        int numParticlesAlive = ps.GetParticles(ToUpdate);

        if (ArrowMarker.transform.localEulerAngles.z < 180)
        {
            polarity = -1;
            flip = 0;
        }

        else
        {
            polarity = -1;
            flip = 0;
        }

        for (int i = 0; i < numParticlesAlive; i++)
        {
            ToUpdate[i].rotation = (ArrowMarker.transform.rotation.eulerAngles.z + flip) * polarity;
        }

        ps.SetParticles(ToUpdate, numParticlesAlive);
        //Debug.Log(ToUpdate[1].rotation);
    }
}
