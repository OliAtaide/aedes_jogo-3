using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Botoes : MonoBehaviour
{
    public GameObject botao, caixa, campos, campo, botaoVerificar, botaoTentarNovamente;
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

        botaoVerificar.SetActive(true);
        botaoTentarNovamente.SetActive(false);
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
                    image.color = new Color32(70, 220, 0, 255);
                }
                else{
                    image.color = new Color32(220, 70, 0, 255);
                }
            }
            botaoVerificar.SetActive(false);
            botaoTentarNovamente.SetActive(true);
        }
    }

    public void tentarNovamente()
    {
        GameObject[] botoes = GameObject.FindGameObjectsWithTag("Botao");
        foreach (var i in botoes)
        {
            i.GetComponent<Button>().interactable = true;
        }

        campoObjs = GameObject.FindGameObjectsWithTag("Campo");
        foreach (var i in campoObjs)
        {
            i.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            i.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            i.GetComponent<BlocoCampo>().isFull = false;
        }

        botaoVerificar.SetActive(true);
        botaoTentarNovamente.SetActive(false);
    }

}