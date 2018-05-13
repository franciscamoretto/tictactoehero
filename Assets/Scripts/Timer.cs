using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int totalTime = 0;
    public Text countdownText;
    public delegate void TimeOut();
    public static event TimeOut OnTimeOut;
    private bool isCounting = false;
    private float countdown;
    private float startTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.countdownText.text = ((int)countdown).ToString("D2");

        if (this.isCounting)
        {
            if ((this.startTime + this.totalTime) > Time.fixedTime)
            {
                this.countdown -= Time.fixedDeltaTime;
            } else
            {
                this.isCounting = false;
                this.countdown = 0;
                if (OnTimeOut != null)
                {   
                    OnTimeOut();
                }
            }
        }
	}

    /// <summary>
    /// Inicia a contagem regreciva do timer
    /// </summary>
    public void StartTimer()
    {
        this.startTime = Time.fixedTime;
        this.isCounting = true;
    }

    /// <summary>
    /// Pausa o contador de tempo
    /// </summary>
    public void PauseTimer()
    {
        this.isCounting = false;
    }

    /// <summary>
    /// Reseta o tempo para o valor inicial
    /// </summary>
    public void ResetTimer()
    {
        this.isCounting = false;
        this.countdown = totalTime;
    }
}
