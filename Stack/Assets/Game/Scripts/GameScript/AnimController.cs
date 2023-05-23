using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] private GameObject animSpawn;
    [SerializeField] private ParticleSystem PsAnim;

    public void PlayAnim()
    {
        if (PsAnim)
        {
            PsAnim.Play();
        }
    }

    public void ActiveAnim(bool active)
    {
        animSpawn.SetActive(active);
    }
    public void SetScaleAnim(Vector3 scale)
    {
        PsAnim.transform.localScale = scale;
    }
    public void SetAnimSpawn(Vector3 pos)
    {
        animSpawn.transform.position = pos;
    }
}
