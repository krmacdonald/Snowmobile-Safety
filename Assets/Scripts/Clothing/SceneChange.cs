using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string SceneName;

public void SceneSwitch(){
    //Changes scene based on name of scene typed in
    SceneManager.LoadScene(SceneName);
}

}
