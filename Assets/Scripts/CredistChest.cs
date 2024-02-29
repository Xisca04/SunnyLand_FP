using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredistChest : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private GameObject timeIsUpPanel;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _particles.Stop();
        timeIsUpPanel.SetActive(false);
    }

    private void Update()
    {
        if(SimpleTimer.Instance.timeLeft == 0)
        {
            StartCoroutine("TimeIsUp");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Finish"))
        {
            _anim.SetBool("IsOpened", true);
            _particles.Play();
            StartCoroutine("SendPlayer");
        } 
        else if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Repeat"))
        {
            _anim.SetBool("IsOpened", true);
            _particles.Play();
            StartCoroutine("SendAndRepeatLevel");
        }

    }

    private IEnumerator SendPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        Loader.Load(Loader.Scene.CreditsScene);
    }

    private IEnumerator SendAndRepeatLevel()
    {
        yield return new WaitForSeconds(1.5f);
        Loader.Load(Loader.Scene.Final_Level);
    }

    private IEnumerator TimeIsUp()
    {
        timeIsUpPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        Loader.Load(Loader.Scene.Final_Level);
    }
}
