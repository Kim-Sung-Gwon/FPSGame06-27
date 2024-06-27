using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// 씬 관련 기능을 사용 하겠다 그리고 그뒤는
// 생략을 명시 한다.

public class UIManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR  // 전처리기 : 컴파일전 미리 기능이 정해져 있다.
        UnityEditor.EditorApplication.isPlaying = false;
        // 유니티에서 편집중 인 상태에 종료
#else   // 빌드에서 종료
        Application.Quit();
#endif
    }
}
