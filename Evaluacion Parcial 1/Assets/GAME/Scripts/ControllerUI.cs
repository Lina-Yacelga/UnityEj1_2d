using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControllerUI : MonoBehaviour
{
    [Header("Referencias a Controllers y Canvas")]
    public ControllerGame controllerGame;
    public TextMeshProUGUI txtInfo;
    public Button btnProcesar;
    public Button btnGuardar;

    void Start()
    {
        
        if (btnProcesar != null)
            btnProcesar.onClick.AddListener(OnBotonProcesarClicked);

        if (btnGuardar != null)
            btnGuardar.onClick.AddListener(OnBotonGuardarClicked);

        ActualizarPantalla();
    }

    public void OnBotonProcesarClicked()
    {
        if (controllerGame != null)
        {
            bool exito = controllerGame.ProcesarSiguiente();

            if (!exito)
            {
                Debug.LogWarning("No existen artefactos pendientes por procesar.");
            }

            ActualizarPantalla();
        }
    }

    public void OnBotonGuardarClicked()
    {
        if (controllerGame != null)
        {
            controllerGame.GuardarResultado();
        }
    }

    public void ActualizarPantalla()
    {
        if (controllerGame == null || txtInfo == null) return;

        string textoUI = "CENTRO DE ANALISIS\n\n";
        textoUI += "Total Cargados: " + controllerGame.totalCargados + "\n";
        textoUI += "Procesados: " + (controllerGame.totalCargados - controllerGame.pendientes.Count) + "\n";
        textoUI += "Pendientes: " + controllerGame.pendientes.Count + "\n\n";

        if (controllerGame.ultimoProcesado != null)
        {
            textoUI += "Ultimo procesado: " + controllerGame.ultimoProcesado.codigo + " " + controllerGame.ultimoProcesado.nombre + "\n";
        }
        else
        {
            textoUI += "Ultimo procesado: Ninguno\n";
        }

        if (controllerGame.pendientes.Count > 0)
        {
            textoUI += "Proximo artefacto: " + controllerGame.pendientes[0].codigo + " " + controllerGame.pendientes[0].nombre;
        }
        else
        {
            textoUI += "Proximo artefacto: ¡Procesamiento finalizado!";
        }

        txtInfo.text = textoUI;
    }
}