using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Botoes : MonoBehaviour
{
    public GameObject botao, caixa, campos, campo;
    public List<Bloco> blocos;
    GameObject[] campoObjs;

    private void Start()
    {
        for (int i = 0; i < blocos.Count; i++)
        {
            campo.GetComponent<BlocoCampo>().resposta = blocos[i].grupo;
            GameObject obj = Instantiate(campo, campos.transform.position, campos.transform.rotation);
            obj.transform.SetParent(campos.transform, false);
            obj.name = blocos[i].name;
        }

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

    public bool todasRespondidas()
    {
        for (int i = 0; i < blocos.Count; i++)
        {
            if (!campoObjs[i].GetComponent<BlocoCampo>().isFull)
            {
                return false;
            }
        }
        return true;
    }

    public void checarRespostas()
    {
        campoObjs = GameObject.FindGameObjectsWithTag("Campo");

        if (todasRespondidas())
        {
            foreach (var i in campoObjs)
            {
                BlocoCampo campo = i.GetComponent<BlocoCampo>();
                Image image = i.GetComponent<Image>();
                if (campo.resposta == campo.bloco.grupo)
                {
                    image.color = new Color32(70, 219, 0, 255);
                }
            }
        }
    }

}