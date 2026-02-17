using TheWictherContracts.Models;

namespace TheWictherContracts.Service;

public interface IContratoService {
    int TotalContratos { get; }

    IEnumerable<ContratoBase> GetAll();

    ContratoBase GetById(int id);

    ContratoBase Save(ContratoBase contrato);

    ContratoBase Update(int id, ContratoBase contrato);

    ContratoBase Delete(int id);

    InformeContratos GenerarInformeContratos();



}