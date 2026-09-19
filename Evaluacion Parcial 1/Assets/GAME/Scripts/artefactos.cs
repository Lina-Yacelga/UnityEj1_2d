using System;
using System.Collections.Generic;

[Serializable]
public class Artefacto
{
    public string codigo;
    public string nombre;
    public string tipo;
    public int nivel;
    public bool procesado;
}

[Serializable]
public class ListaArtefactos
{
    public List<Artefacto> artefactos;
}

[Serializable]
public class ResultadoArtefactos
{
    public int totalCargados;
    public int totalProcesados;
    public int totalPendientes;
    public List<Artefacto> artefactos;
}