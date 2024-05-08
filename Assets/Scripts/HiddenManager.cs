using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenManager : MonoBehaviour
{
    private float displayTime = 2.0f;
    [SerializeField]
    private Text HiddenText;
    [SerializeField]
    private Image HiddenBack;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowMessage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ShowMessage()
    {
        HiddenText.gameObject.SetActive(true);
        HiddenBack.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        HiddenText.gameObject.SetActive(false);
        HiddenBack.gameObject.SetActive(false);
    }
}
