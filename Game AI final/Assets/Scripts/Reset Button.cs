using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("Reset").GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        World.boids.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
