using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Player player;
    public GameObject effects;

    public void EndScene()
    {
        Destroy(player);
        effects.SetActive(true);
        Invoke("Restart", 1f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
