using Entity.Entities;

namespace DesafioProsegur.Models
{
    public class MateriaPrimaViewModel
    {
        public ICollection<MateriaPrima> MateriasPrima {  get; set; }

        public string ValidarModelo(MateriaPrimaViewModel oViewModel, out string msjError)
        {
            msjError = string.Empty;

            foreach (var materiaPrima in oViewModel.MateriasPrima)
            {
                if (materiaPrima.Stock <= 0)
                    msjError += "La cantidad de la materia prima: " + materiaPrima.Nombre + "</br> Tiene que ser mayor que 0. </br>";
            }

            return msjError;
        }
    }
}