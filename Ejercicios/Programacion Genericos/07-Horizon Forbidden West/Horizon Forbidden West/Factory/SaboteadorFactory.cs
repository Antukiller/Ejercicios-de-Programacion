using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;

namespace Horizon_Forbidden_West.Factory;

public static class SaboteadorFactory {
    public static List<Saboteador> GenerarSemilla() => new() {
        new() { Nombre = "Sylens", CodigoGaia = "SAB-0001-G", Descripcion = "Fundador del Eclipse", añosExperiencia = 35, Faccion = FaccionTecnologica.Eclipse, Certificado = CertificadoCaldero.GEMINI, AreaMaestra = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Beta", CodigoGaia = "SAB-0002-T", Descripcion = "Clon de Elisabet", añosExperiencia = 2, Faccion = FaccionTecnologica.HerederosDeApolo, Certificado = CertificadoCaldero.TAU, AreaMaestra = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Tilda", CodigoGaia = "SAB-0003-Z", Descripcion = "Inmortal Far Zenith", añosExperiencia = 70, Faccion = FaccionTecnologica.HerederosDeApolo, Certificado = CertificadoCaldero.GEMINI, AreaMaestra = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Alva", CodigoGaia = "SAB-0004-I", Descripcion = "Adivina Quen", añosExperiencia = 10, Faccion = FaccionTecnologica.CaminantesDelFoco, Certificado = CertificadoCaldero.IOTA, AreaMaestra = Especializacion.AnalisisDeMaquinas },
        new() { Nombre = "Regalla", CodigoGaia = "SAB-0005-R", Descripcion = "Rebelde Tenakth", añosExperiencia = 25, Faccion = FaccionTecnologica.HijosDePrometeo, Certificado = CertificadoCaldero.CHI, AreaMaestra = Especializacion.BalisticaDeFelchas },
        new() { Nombre = "Asera", CodigoGaia = "SAB-0006-K", Descripcion = "Líder Hijos Prometeo", añosExperiencia = 18, Faccion = FaccionTecnologica.HijosDePrometeo, Certificado = CertificadoCaldero.KAPPA, AreaMaestra = Especializacion.IngenieriaDeCalderos },
        new() { Nombre = "Helis", CodigoGaia = "SAB-0007-H", Descripcion = "Terror del Sol", añosExperiencia = 22, Faccion = FaccionTecnologica.Eclipse, Certificado = CertificadoCaldero.SIGMA, AreaMaestra = Especializacion.SigiloYSupervivencias },
        new() { Nombre = "Vash", CodigoGaia = "SAB-0008-M", Descripcion = "Técnico Quen", añosExperiencia = 5, Faccion = FaccionTecnologica.CaminantesDelFoco, Certificado = CertificadoCaldero.MU, AreaMaestra = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Kael", CodigoGaia = "SAB-0009-P", Descripcion = "Saboteador de Redes", añosExperiencia = 12, Faccion = FaccionTecnologica.HijosDePrometeo, Certificado = CertificadoCaldero.RHO, AreaMaestra = Especializacion.IngenieriaDeCalderos },
        new() { Nombre = "Elia", CodigoGaia = "SAB-0010-A", Descripcion = "Investigadora Alpha", añosExperiencia = 7, Faccion = FaccionTecnologica.HerederosDeApolo, Certificado = CertificadoCaldero.TAU, AreaMaestra = Especializacion.AnalisisDeMaquinas },
        new() { Nombre = "Malix", CodigoGaia = "SAB-0011-E", Descripcion = "Infiltrado Eclipse", añosExperiencia = 15, Faccion = FaccionTecnologica.Eclipse, Certificado = CertificadoCaldero.GEMINI, AreaMaestra = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Ronan", CodigoGaia = "SAB-0012-C", Descripcion = "Estratega de Foco", añosExperiencia = 9, Faccion = FaccionTecnologica.CaminantesDelFoco, Certificado = CertificadoCaldero.IOTA, AreaMaestra = Especializacion.IngenieriaDeCalderos },
        new() { Nombre = "Serya", CodigoGaia = "SAB-0013-F", Descripcion = "Francotiradora Élite", añosExperiencia = 14, Faccion = FaccionTecnologica.HijosDePrometeo, Certificado = CertificadoCaldero.CHI, AreaMaestra = Especializacion.BalisticaDeFelchas },
        new() { Nombre = "Torin", CodigoGaia = "SAB-0014-N", Descripcion = "Vigilante Nocturno", añosExperiencia = 11, Faccion = FaccionTecnologica.Eclipse, Certificado = CertificadoCaldero.MU, AreaMaestra = Especializacion.SigiloYSupervivencias },
        new() { Nombre = "Lanza", CodigoGaia = "SAB-0015-G", Descripcion = "Eco de Gaia", añosExperiencia = 3, Faccion = FaccionTecnologica.CaminantesDelFoco, Certificado = CertificadoCaldero.TAU, AreaMaestra = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Jaxon", CodigoGaia = "SAB-0016-B", Descripcion = "Martillo del Norte", añosExperiencia = 28, Faccion = FaccionTecnologica.HijosDePrometeo, Certificado = CertificadoCaldero.KAPPA, AreaMaestra = Especializacion.IngenieriaDeCalderos },
        new() { Nombre = "Vana", CodigoGaia = "SAB-0017-V", Descripcion = "Erudita de Datos", añosExperiencia = 4, Faccion = FaccionTecnologica.HerederosDeApolo, Certificado = CertificadoCaldero.IOTA, AreaMaestra = Especializacion.AnalisisDeMaquinas },
        new() { Nombre = "Zar", CodigoGaia = "SAB-0018-X", Descripcion = "Antiguo Hacker", añosExperiencia = 40, Faccion = FaccionTecnologica.Eclipse, Certificado = CertificadoCaldero.GEMINI, AreaMaestra = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Nyx", CodigoGaia = "SAB-0019-Y", Descripcion = "Sombra de Red", añosExperiencia = 6, Faccion = FaccionTecnologica.CaminantesDelFoco, Certificado = CertificadoCaldero.RHO, AreaMaestra = Especializacion.SigiloYSupervivencias },
        new() { Nombre = "Cyrus", CodigoGaia = "SAB-0020-Z", Descripcion = "Ingeniero de Combate", añosExperiencia = 21, Faccion = FaccionTecnologica.HijosDePrometeo, Certificado = CertificadoCaldero.CHI, AreaMaestra = Especializacion.IngenieriaDeCalderos }
    };
}