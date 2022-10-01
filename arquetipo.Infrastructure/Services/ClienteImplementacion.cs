using arquetipo.Repository.Context;
using arquetipo.Entity.Models;
using arquetipo.Domain.Interfaces;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace arquetipo.Infrastructure.Services
{
    public class ClienteImplementacion : ICliente
    {
        private readonly BlogContext _context;

        public ClienteImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
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
            csvData= CSVToDataTable(csv_file_path);

                int result = (from row in csvData.AsEnumerable()
                              group row by row.Field<string>("identificacion") into g
                              where g.Count() > 1
                              select new
                              {
                                  codigo = g.Key
                              }).Count();
                

                if (result>0)
                {
                    return "Existen datos duplicados ";
                }
                foreach (DataRow dt_csv in csvData.Rows)
                {
                    Cliente cliente = new Cliente();
                    cliente.identificacion_cli = dt_csv[0].ToString();
                    cliente.nombres_cli = dt_csv[1].ToString();
                    cliente.edad_cli = Convert.ToInt32(dt_csv[2].ToString());
                    cliente.fecha_naciminto_cli = Convert.ToDateTime(dt_csv[3].ToString());
                    cliente.apellidos_cli = dt_csv[4].ToString();
                    cliente.direccion_cli = dt_csv[5].ToString();
                    cliente.telefono_cli = dt_csv[6].ToString();
                    cliente.estado_civil_cli = dt_csv[7].ToString();
                    cliente.identificacion_cli = dt_csv[8].ToString();
                    cliente.nombre_conyugue_cli = dt_csv[9].ToString();
                    cliente.sujeto_credito_cli = dt_csv[10].ToString();
                    _context.Set<Cliente>().Add(cliente);
                    await _context.SaveChangesAsync();
                }
                return "Datos importados exitosamente";
            }
            catch (Exception e)
            {
                return "Se produjo una excepcion : " + e.Message;
            }
        }
    }
}
