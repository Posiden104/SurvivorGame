using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float seconds;

    [SerializeField]
    private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        //tmp = gameObject.GetComponent<TextMeshPro>();
        seconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        UpdateClock();
    }

    void UpdateClock()
    {
        var min = (int)seconds / 60;
        var sec = (int)seconds % 60;

        tmp.text = $"{min:00}:{sec:00}";
    }
}
