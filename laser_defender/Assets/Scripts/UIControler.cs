using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    TextMeshProUGUI textScore;

    void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScoreText(string text)
    {
        this.textScore.text = text;
    }


}
