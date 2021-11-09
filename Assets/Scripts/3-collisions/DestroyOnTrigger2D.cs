using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    int counter = 0;
    [SerializeField] Image Heart1;
    [SerializeField] Image Heart2;
    [SerializeField] Image Heart3;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            if (counter==2)
            {
                Destroy(Heart3);
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                QuitGame();
            }
            else
            {
                counter++;
                if (counter == 1)
                {
                    Destroy(Heart1);
                }
                else
                {
                    Destroy(Heart2);
                }
            }
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
