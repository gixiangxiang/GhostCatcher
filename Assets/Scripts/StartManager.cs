using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
  [SerializeField] InputField nameIpf;
  [SerializeField] Button startBtn;
  [SerializeField] Text warnningTxt;
  public void OnStartClick()
  {
    nameIpf.text.Trim();
    if (nameIpf.text.Length >0)
    {
      PhotonManager.photonMg.playerName = nameIpf.text;
      PhotonManager.photonMg.Connect();
    }
    else
    {
      warnningTxt.gameObject.SetActive(true);
    }

  }

}
