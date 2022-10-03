﻿using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IEjecutivo
    {
        Task<IEnumerable<Ejecutivo>> GetEjecutivo(string cedula);
        Task<String> Import(string url);
        Task<bool> Create(Ejecutivo ejecutivo);
        Task Delete(int id);
        Task<Ejecutivo> Update(Ejecutivo ejecutivo);
        Task<Ejecutivo> GetById(int id);
    }
}
