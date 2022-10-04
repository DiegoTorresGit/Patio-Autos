using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace arquetipo.Infrastructure.Services
{
    public class EjecutivoImplementacion : IEjecutivo
    {
        private readonly BlogContext _context;
        public EjecutivoImplementacion(BlogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ejecutivo>> Get(string cedula)
        {
            return await _context.Ejecutivo.Where(r => r.identificacion_eje == cedula).ToListAsync();
        }
        public async Task<IEnumerable<Ejecutivo>> GetEjePat(int codigo_pat)
        {
            return await _context.Ejecutivo.Where(r => r.id_pat == codigo_pat).ToListAsync();
        }
        private DataTable CSVToDataTable(string path)
        {
            DataTable dt = new DataTable();
            string csvData;
            using (StreamReader sr = new StreamReader(path))
            {
                csvData = sr.ReadToEnd().ToString();
                string[] row = csvData.Split('\n');
                for (int i = 0; i < row.Count() - 1; i++)
                {
                    string[] rowData = row[i].Split(',');
                    {
                        if (i == 0)
                        {
                            for (int j = 0; j < rowData.Count(); j++)
                            {
                                dt.Columns.Add(rowData[j].Trim());
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            for (int k = 0; k < rowData.Count(); k++)
                            {
                                dr[k] = rowData[k].ToString();
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                }

                return dt;
            }
        }
        public async Task<string> Import(string csv_file_path)
        {
            try
            {
                DataTable csvData = new DataTable();
                csvData = CSVToDataTable(csv_file_path);

                int result = (from row in csvData.AsEnumerable()
                              group row by row.Field<string>("identificacion") into g
                              where g.Count() > 1
                              select new
                              {
                                  codigo = g.Key
                              }).Count();


                if (result > 0)
                {
                    return "Existen datos duplicados";
                }
                foreach (DataRow dt_csv in csvData.Rows)
                {
                    Ejecutivo ejecutivo = new Ejecutivo();
                    ejecutivo.identificacion_eje = dt_csv[0].ToString();
                    ejecutivo.nombres_eje = dt_csv[1].ToString();
                    ejecutivo.apellidos_eje = dt_csv[2].ToString();
                    ejecutivo.direccion_eje = dt_csv[3].ToString();
                    ejecutivo.telefono_con_eje = dt_csv[4].ToString();
                    ejecutivo.celular_eje = dt_csv[5].ToString();
                    ejecutivo.id_pat = Convert.ToInt32(dt_csv[6].ToString());
                    ejecutivo.edad_eje = Convert.ToInt32(dt_csv[7].ToString());
                    _context.Set<Ejecutivo>().Add(ejecutivo);
                    await _context.SaveChangesAsync();
                }
                return "Datos importados exitosamente";
            }
            catch (Exception e)
            {
                return "Se produjo una excepcion : " + e.Message;
            }
        }
        public async Task<Ejecutivo> Update(Ejecutivo entity)
        {
            _context.Set<Ejecutivo>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity == null)
                    throw new Exception("No existen datos");

                _context.Set<Ejecutivo>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<Ejecutivo> GetById(int id)
        {
            try
            {
                return await _context.Set<Ejecutivo>().FindAsync(id);
            }
            catch (Exception)
            {
                return null;

            }
        }
        public async Task<bool> Create(Ejecutivo entity)
        {
            try
            {
                if (!_context.Cliente.Any(r => r.identificacion_cli == entity.identificacion_eje))
                {
                    _context.Set<Ejecutivo>().Add(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
                //_context.Cliente.Any(r => r.identificacion_cli == entity.identificacion_cli);
                //_context.Set<Cliente>().Add(entity);
                //await _context.SaveChangesAsync();
                //return entity;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
