using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGame : MonoBehaviour
{
    
    public List<Artefacto> todosLosArtefactos { get; private set; } = new List<Artefacto>();

   
    public List<Artefacto> pendientes { get; private set; } = new List<Artefacto>();

    public Artefacto ultimoProcesado { get; private set; } = null;
    public int totalCargados { get; private set; } = 0;

    void Awake()
    {
        CargarJSON();
    }

    private void CargarJSON()
    {
        string ruta = Path.Combine(Application.streamingAssetsPath, "artefactos.json");

        if (File.Exists(ruta))
        {
            string jsonTexto = File.ReadAllText(ruta);
            ListaArtefactos datos = JsonUtility.FromJson<ListaArtefactos>(jsonTexto);

            todosLosArtefactos = datos.artefactos;
            totalCargados = todosLosArtefactos.Count;

            foreach (var art in todosLosArtefactos)
            {
                if (!art.procesado)
                {
                    pendientes.Add(art);
                }
            }
        }
        else
        {
            Debug.LogError("No se encontró el archivo en: " + ruta);
        }
    }

    public bool ProcesarSiguiente()
    {
        if (pendientes.Count > 0)
        {
            
            Artefacto actual = pendientes[0];
            actual.procesado = true;

            ultimoProcesado = actual;
            pendientes.RemoveAt(0); 
            return true;
        }

        return false; 
    }

    public void GuardarResultado()
    {
        ResultadoArtefactos resultado = new ResultadoArtefactos();
        resultado.totalCargados = totalCargados;
        resultado.totalProcesados = totalCargados - pendientes.Count;
        resultado.totalPendientes = pendientes.Count;
        resultado.artefactos = todosLosArtefactos;

        string jsonSalida = JsonUtility.ToJson(resultado, true);
        string rutaSalida = Path.Combine(Application.streamingAssetsPath, "artefactos_resultado.json");

        File.WriteAllText(rutaSalida, jsonSalida);
        Debug.Log("Resultado guardado en: " + rutaSalida);
    }
}