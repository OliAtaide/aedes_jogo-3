using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BlocoCampo : MonoBehaviour
{
    public string resposta;
    public Bloco bloco;

    public bool isFull;

    public Button getBotao()
    {
        GameObject[] botoes = GameObject.FindGameObjectsWithTag("Botao");
        foreach (var b in botoes)
        {
            Botao botao = b.GetComponent<Botao>();
            if (botao.bloco == bloco)
            {
                return b.GetComponent<Button>();
            }
        }
        return null;
    }

    void OnTriggerStay2D(Collider2D col)
    {

        BlocoCaixa caixa = col.gameObject.GetComponent<BlocoCaixa>();

        if (!caixa.dragging && !caixa.used)
        {
            if (isFull)
            {
                getBotao().interactable = true;
            }

            bloco = caixa.bloco;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = bloco.texto;
            GetComponent<Image>().color = col.gameObject.GetComponent<Image>().color;
            getBotao().interactable = false;
            caixa.used = true;
            isFull = true;
            Destroy(col.gameObject);
        }
    }
}