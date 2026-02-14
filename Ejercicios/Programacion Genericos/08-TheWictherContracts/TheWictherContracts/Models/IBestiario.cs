namespace TheWictherContracts.Models;

public interface IBestiario : IContrato {
    void PrepararAceite();
    
    string SeleccionarSeñal();
    
    void MostraDebilidades();
    
}