using UnityEngine;

public class BasePanel : MonoBehaviour {

    public void OnCloseClicked() {
        Dismiss();
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Dismiss() {
        gameObject.SetActive(false);
    }

    public void ShowPanel(BasePanel panel) {
        panel.Show();
    }
}
