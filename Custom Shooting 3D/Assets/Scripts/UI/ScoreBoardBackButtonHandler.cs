using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardBackButtonHandler : MonoBehaviour {

    GameObject PanelGO;
    Button ButtonCancel;

	public void ClosePanel()
    {
        ButtonCancel = GetComponent<Button>();
        PanelGO = ButtonCancel.transform.parent.parent.gameObject;
        PanelGO.SetActive(false);
    }
}
