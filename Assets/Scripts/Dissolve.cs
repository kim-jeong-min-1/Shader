using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] private float Fade;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        StartCoroutine(DissolveOut());
    }

    IEnumerator DissolveOut()
    {
        while (true)
        {
            if(Fade <= 0)
            {
                Fade = 0;
                break;
            }

            Fade -= Time.deltaTime;
            material.SetFloat("_Fade", Fade);
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(0.9f);
        StartCoroutine(DissolveIn());
    }

    IEnumerator DissolveIn()
    {

        while (true)
        {
            if(Fade >= 1)
            {
                Fade = 1;
                break;
            }

            Fade += Time.deltaTime;
            material.SetFloat("_Fade", Fade);
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(0.9f);
        StartCoroutine(DissolveOut());
    }
}
