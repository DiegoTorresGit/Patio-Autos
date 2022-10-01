using arquetipo.Repository.Context;
using arquetipo.Entity.Models;
using arquetipo.Domain.Interfaces;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace arquetipo.Infrastructure.Services
{
    public class MarcaImplementacion :  IMarca
    {

        private readonly BlogContext _context;

        public MarcaImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marca>> GetMarca()
        {
            return await _context.Marca.ToListAsync();
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
                              group row by row.Field<string>("marcas") into g
                              where g.Count() > 1
                              select new
                              {
                                  codigo = g.Key
                              }).Count();


                if (result > 0)
                {
                    return "Existen datos duplicados ";
                }
                foreach (DataRow dt_csv in csvData.Rows)
                {
                    Marca _marca = new Marca();
                    _marca.descripcion_mar = dt_csv[0].ToString();
                    _context.Set<Marca>().Add(_marca);
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
