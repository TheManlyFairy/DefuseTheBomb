using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneButton : MonoBehaviour {

    [Tooltip("Scene Index To Load")]
    public int relatedSceneId;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { ChangeScene(); });
    }

    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != relatedSceneId)
            SceneManager.LoadScene(relatedSceneId);
    }
}
