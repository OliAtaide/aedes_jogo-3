using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Botoes : MonoBehaviour
{
    public GameObject botao, caixa;
    public List<Bloco> blocos;

    private void Start()
    {
        for (int i = 0; i < blocos.Count; i++)
        {
            Bloco temp = blocos[i];
            int randomIndex = Random.Range(i, blocos.Count);
            blocos[i] = blocos[randomIndex];
            blocos[randomIndex] = temp;
        }

        for (int i = 0; i < blocos.Count; i++)
        {
            botao.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            botao.GetComponent<Botao>().bloco = blocos[i];
            botao.GetComponent<Botao>().pai = GameObject.FindWithTag("Box");
            botao.GetComponent<Botao>().caixa = caixa;
            GameObject obj = Instantiate(botao, transform.position, transform.rotation);
            obj.transform.SetParent(transform, false);
            obj.name = blocos[i].name;
        }
    }

}