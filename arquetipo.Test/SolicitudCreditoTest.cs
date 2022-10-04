using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Services;
using arquetipo.Test.DbCache;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace arquetipo.Test;

[TestClass]
public class SolicitudCreditoTest : ContextC
{
    [TestMethod]
    public void SolicitudCreditoOk()
    {
        ISolicitudCredito _iasignacion = new SolicitudCreditoImplementacion(dbcontext); 

        Solicitud_Credito sc = new Solicitud_Credito();
        sc.codigo_cli = 1;
        sc.codigo_est = 1;
        sc.codigo_pat = 1;
        sc.codigo_sc = 1;
        sc.cuotas_sc = 1000;
        sc.entrada_sc = 200;
        sc.fecha_sc = "20220909";
        sc.id_eje = 1;
        sc.id_veh = 1;
        sc.meses_plazo_veh_sc = 1;
        sc.observacion_eje = "ninguna";
        dynamic resultado = _iasignacion.Create(sc);

        Assert.IsTrue(resultado != null);
    }
    [TestMethod]
    public void DuplicidadClientes()
    {
        ICliente _icliente = new ClienteImplementacion(dbcontext);

        Cliente _cliente = new Cliente();
        _cliente.apellidos_cli = "TORRES";
        _cliente.nombres_cli = "Diego";
        _cliente.nombre_conyugue_cli = "SN";
        _cliente.sujeto_credito_cli = "SUJETO DE CREDITO";
        _cliente.telefono_cli = "023451366";
        _cliente.edad_cli = 50;
        _cliente.direccion_cli = "SANTA LUCIA";
        _cliente.identificacion_cli = "1722046628";
        _cliente.fecha_naciminto_cli = Convert.ToDateTime("08/08/2022");
        _cliente.identificacion_conyuge_cli = "s/n";
        _cliente.estado_civil_cli = "CASADO";
        dynamic resultado = _icliente.Create(_cliente);
        Assert.IsTrue(resultado != null);
    }
}