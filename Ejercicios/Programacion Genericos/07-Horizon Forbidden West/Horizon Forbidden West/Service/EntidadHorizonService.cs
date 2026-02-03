using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Exception;
using Horizon_Forbidden_West.Models;
using Horizon_Forbidden_West.Repositories;
using Horizon_Forbidden_West.Validator.Common;
using Serilog;

namespace Horizon_Forbidden_West.Service;

public class EntidadHorizonService(
    IEntidadHorizonRepository repository,
    IValidador<EntidadHorizon> valMaquina,
    IValidador<EntidadHorizon> valCazador,
    IValidador<EntidadHorizon> valSaboteador) : IEntidadHorizonService {
    
    private readonly ILogger _log = Log.ForContext<EntidadHorizonService>();



    public int TotalEntidades => repository.GetAll().Size;
    
    
    public ILista<EntidadHorizon> GetAll() {
        _log.Information("Obteniendo todas las entidades");
        return repository.GetAll();
    }

    public ILista<EntidadHorizon> GetAllOrdeBy(TipoOrdenamiento orden = TipoOrdenamiento.CodigoGaia, Predicate<EntidadHorizon>? filtro = null) {
        _log.Information("Obteniendo todas las entidades ordenadad por {orden} con filtro: {filtro}", orden, filtro != null ? "Si" : "No");
        
        var lista = repository.GetAll();

        if (filtro != null)
            lista = lista.Where(filtro);
        Comparison<EntidadHorizon> comparador = orden switch {
            TipoOrdenamiento.Id => (a, b) => a.Id.CompareTo(b.Id),

            TipoOrdenamiento.CodigoGaia => (a, b) =>
                string.Compare(a.CodigoGaia, b.CodigoGaia, StringComparison.Ordinal),

            TipoOrdenamiento.Nombre => (a, b) => string.Compare(a.Nombre, b.Nombre, StringComparison.Ordinal),
            
            // --- Maquinas ---

            TipoOrdenamiento.Peligrosidad => (a, b) => {
                var peligrosidadA = a is Maquina m1 ? (int)m1.Peligrosidad : -1;
                var peligrosidadB = b is Maquina m2 ? (int)m2.Peligrosidad : -1;
                return peligrosidadA.CompareTo(peligrosidadB);
            },
            
            TipoOrdenamiento.Tipo => (a, b) => {
                var tipoA = a is Maquina m1 ? (int)m1.Tipo : -1;
                var tipoB = b is Maquina m2 ? (int)m2.Tipo : -1;
                return tipoA.CompareTo(tipoB);
            },
            
            TipoOrdenamiento.Debilidad => (a, b) => {
                var debilidadA = a is Maquina m1 ? m1.DebilidadElemental : string.Empty;
                var debilidadB = b is Maquina m2 ? m2.DebilidadElemental : string.Empty;
                return string.Compare(debilidadA, debilidadB, StringComparison.Ordinal);
            },
            
            
            // --- Cazadores ---
            TipoOrdenamiento.Tribu => (a, b) => {
                var tribuA = a is Cazador c1 ? (int)c1.Tribu : -1;
                var tribuB = b is Cazador c2 ? (int)c2.Tribu : -1;

                return tribuB.CompareTo(tribuA);
            },
            
            // --- Saboteadores ---
            TipoOrdenamiento.Experiencia => (a, b) => {
                var xpA = a is Saboteador s1 ? s1.añosExperiencia : -1;
                var xpB = b is Saboteador s2 ? s2.añosExperiencia : -1;
                return xpB.CompareTo(xpA);
            },
            
            TipoOrdenamiento.Certificado => (a, b) => {
                var certificadoA = a is Saboteador s1 ? (int)s1.Certificado : -1;
                var cerfificadoB = b is Saboteador s2 ? (int)s2.Certificado : -1;
                return certificadoA.CompareTo(cerfificadoB);
            },
            _ => (a, b) => a.Id.CompareTo(b.Id)
        };
        return lista.Sort(comparador);
    }

    public ILista<Maquina> GetMaquinasOrdeBy(TipoOrdenamiento ordenamiento = TipoOrdenamiento.CodigoGaia) {
        _log.Information("Obteniendo maquinas ordenados por {ordenamiento}.", ordenamiento);
        return GetAllOrdeBy(ordenamiento, e => e is Maquina)
            .Select(e => (Maquina)e);
    }

    public ILista<Cazador> GetCazadoresOrdeBy(TipoOrdenamiento ordenamiento = TipoOrdenamiento.CodigoGaia) {
        _log.Information("Obteniendo cazadores ordenados por {ordenamiento}", ordenamiento);
        return GetAllOrdeBy(ordenamiento, e => e is Cazador)
            .Select(e => (Cazador)e);
    }

    public ILista<Saboteador> GetSaboteadores(TipoOrdenamiento ordenamiento = TipoOrdenamiento.CodigoGaia) {
        _log.Information("Obteniendo saboteadores por ordenamiento {ordenamiento}", ordenamiento);
        return GetAllOrdeBy(ordenamiento, e => e is Saboteador)
            .Select(e => (Saboteador)e);
    }

    public EntidadHorizon GetById(int id) {
        _log.Information("Obteniendo entidades por Id {id}");
        return repository.GetById(id) ?? throw new EntidadHorizonException.NotFound(id.ToString());
    }

    public EntidadHorizon GetByCodigoGaia(string codigoGaia) {
        _log.Information("Obteniendo entidades mediante el Codigo Gaia {CodigoGaia}", codigoGaia);
        return repository.GetByCodigoGaia(codigoGaia) ?? throw new EntidadHorizonException.NotFound(codigoGaia);
    }

    public EntidadHorizon Save(EntidadHorizon entidad) {
        _log.Information("Guardando nueva entidad: {entidad}", entidad);
        
        ValidarPerosnaConLogicaPolimorfica(entidad);

        return repository.Create(entidad) ?? throw new EntidadHorizonException.AlreadyExist(entidad.CodigoGaia);

    }

    public EntidadHorizon Update(int id, EntidadHorizon entidad) {
        ValidarPerosnaConLogicaPolimorfica(entidad);

        return repository.Update(id, entidad) ?? throw new EntidadHorizonException.NotFound(id.ToString());
    }

    public EntidadHorizon Delete(int id) {
        _log.Information("Eliminamos entidad con Id {id}", id);
        return repository.Delete(id) ?? throw new EntidadHorizonException.NotFound(id.ToString());
    }

    public InformeMaquina GenerarInformeMaquina() {
        var todas = repository.GetAll();

        int criticas = 0;
        int menores = 0;
        int saboteables = 0;
        var soloMaquinas = new Lista<Maquina>();


        foreach (var entidad in todas ) {
            if (entidad is Maquina m) {
                soloMaquinas.AddLast(m);

                if (m.EsSaboteabale) {
                    saboteables++;
                }

                _ = m.Peligrosidad switch {
                    NivelAmenaza.Elevada or NivelAmenaza.Extrema => criticas++,
                    NivelAmenaza.Moderada or NivelAmenaza.Minima => menores++,
                    _ => 0
                };
            }
            soloMaquinas.Sort((a, b) => b.Peligrosidad.CompareTo(a.Peligrosidad)); 
        }

        return new InformeMaquina {
            TotalMaquinas = soloMaquinas.Count(),
            AmenazasCriticas = criticas,
            AmenazasMenores = menores,
            PorPeligrosidad = soloMaquinas
        };
    }

    public InformeCazador GenerarInformeCazador(CicloEntrenamiento? cicloEntrenamiento = null) {
        var todos = repository.GetAll();

        int veteranos = 0;
        int iniciados = 0;

        var soloCazadores = new Lista<Cazador>();

        foreach (var e in todos ) {
            if (e is Cazador c) {
                soloCazadores.AddLast(c);

                _ = c.Entrenamiento switch {
                    CicloEntrenamiento.Veterano => veteranos++,
                    CicloEntrenamiento.Iniciado => iniciados++,
                    _ => 0
                };
            }
            soloCazadores.Sort((a, b) => b.Entrenamiento.CompareTo(a.Entrenamiento));
        }

        return new InformeCazador {
            TotalCazadores = soloCazadores.Count(),
            Veteranos = veteranos,
            Iniciados = iniciados,
            PorRango = soloCazadores
        };
    }

    public InformeSaboteador GenerarInformeSaboteador() {
        var todos = repository.GetAll();

        int maestrosAlpha = 0;
        int certificadosOmega = 0;
        double sumaExperiencia = 0.0;

        var soloSaboteadores = new Lista<Saboteador>();

        foreach (var e in todos ) {
            if (e is Saboteador s) {
                soloSaboteadores.AddLast(s);
                sumaExperiencia += s.añosExperiencia;

                if (s is { añosExperiencia: > 20 }) maestrosAlpha++;

                if (s is { Certificado: CertificadoCaldero.GEMINI }) certificadosOmega++;
            }

            double media = soloSaboteadores.Count() > 0 ? sumaExperiencia / soloSaboteadores.Count() : 0;

            soloSaboteadores.Sort((a, b) => b.añosExperiencia.CompareTo(a.añosExperiencia));
        }

        return new InformeSaboteador {
            TotalSaboteadores = soloSaboteadores.Count(),
            MaestrosAlpha = maestrosAlpha,
            CertificadosNivelOmega = certificadosOmega,
            PorExperiencia = soloSaboteadores
        };
    }


    private void ValidarPerosnaConLogicaPolimorfica(EntidadHorizon entidad) {
        var errores = entidad switch {
            Maquina => valMaquina.Validar(entidad),
            Cazador => valCazador.Validar(entidad),
            Saboteador => valSaboteador.Validar(entidad),
            _ => ErrorDeTipo("Tipo de entidad no soportado para validacion")
        };
        if (errores.Size > 0) {
            _log.Warning("Errores de validacion encontradps: {errores}", errores);
            throw new EntidadHorizonException.Validation(errores);
        }
    }

    private static ILista<string> ErrorDeTipo(string msg) {
        var a = new Lista<string>();
        a.AddLast(msg);
        return a;
    }
}