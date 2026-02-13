using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;

namespace Horizon_Forbidden_West.Factory;

public static class SaboteadorFactory {
    public static ILista<Saboteador> Seed() {
        var lista = new Lista<Saboteador>();
        
        lista.AddLast(new Saboteador { Nombre = "Sylens", CodigoGaia = "SAB-0001-F", Descripcion = "Fundador de los Eclipse", añosExperiencia = 35, Certificado = CertificadoCaldero.GEMINI});
        lista.AddLast(new Saboteador { Nombre = "Alva", CodigoGaia = "SAB-0002-Q", Descripcion = "Adivina de los Quen", añosExperiencia = 12, Certificado = CertificadoCaldero.TAU});
        lista.AddLast(new Saboteador { Nombre = "Olin", CodigoGaia = "SAB-0003-O", Descripcion = "Explorador Oseram", añosExperiencia = 22, Certificado = CertificadoCaldero.SIGMA});
        lista.AddLast(new Saboteador { Nombre = "Beta", CodigoGaia = "SAB-0004-Z", Descripcion = "Clon de Elisabet Sobeck", añosExperiencia = 19, Certificado = CertificadoCaldero.GEMINI});
        lista.AddLast(new Saboteador { Nombre = "Tilda", CodigoGaia = "SAB-0005-Z", Descripcion = "Miembro de Far Zenith", añosExperiencia = 900, Certificado = CertificadoCaldero.GEMINI});
        lista.AddLast(new Saboteador { Nombre = "Gerard", CodigoGaia = "SAB-0006-Z", Descripcion = "Líder de Far Zenith", añosExperiencia = 950, Certificado = CertificadoCaldero.IOTA});
        lista.AddLast(new Saboteador { Nombre = "Erik", CodigoGaia = "SAB-0007-Z", Descripcion = "Ejecutor Zenith", añosExperiencia = 800, Certificado = CertificadoCaldero.CHI});
        lista.AddLast(new Saboteador { Nombre = "Vashuv", CodigoGaia = "SAB-0008-T", Descripcion = "Técnico Tenakth", añosExperiencia = 15, Certificado = CertificadoCaldero.MU});
        lista.AddLast(new Saboteador { Nombre = "Morlund", CodigoGaia = "SAB-0009-O", Descripcion = "Showman de Las Vegas", añosExperiencia = 25, Certificado = CertificadoCaldero.KAPPA});
        lista.AddLast(new Saboteador { Nombre = "Abadund", CodigoGaia = "SAB-0010-O", Descripcion = "Comerciante de piezas", añosExperiencia = 30, Certificado = CertificadoCaldero.SIGMA});
        lista.AddLast(new Saboteador { Nombre = "Stemmur", CodigoGaia = "SAB-0011-O", Descripcion = "Contador de historias", añosExperiencia = 40, Certificado = CertificadoCaldero.MU});
        lista.AddLast(new Saboteador { Nombre = "Ceo", CodigoGaia = "SAB-0012-Q", Descripcion = "Líder Quen", añosExperiencia = 20, Certificado = CertificadoCaldero.RHO});
        lista.AddLast(new Saboteador { Nombre = "Bohai", CodigoGaia = "SAB-0013-Q", Descripcion = "Asesor Quen", añosExperiencia = 28, Certificado = CertificadoCaldero.KAPPA});
        lista.AddLast(new Saboteador { Nombre = "Harrihet", CodigoGaia = "SAB-0014-Q", Descripcion = "Adivina Senior", añosExperiencia = 33, Certificado = CertificadoCaldero.GEMINI});
        lista.AddLast(new Saboteador { Nombre = "Varga", CodigoGaia = "SAB-0015-O", Descripcion = "Experta en armas", añosExperiencia = 18, Certificado = CertificadoCaldero.SIGMA});
        lista.AddLast(new Saboteador { Nombre = "Kallo", CodigoGaia = "SAB-0016-T", Descripcion = "Ingeniero de campo", añosExperiencia = 14, Certificado = CertificadoCaldero.MU});
        lista.AddLast(new Saboteador { Nombre = "Larend", CodigoGaia = "SAB-0017-O", Descripcion = "Chatarrero", añosExperiencia = 21, Certificado = CertificadoCaldero.SIGMA});
        lista.AddLast(new Saboteador { Nombre = "Runda", CodigoGaia = "SAB-0018-O", Descripcion = "Líder de caravana", añosExperiencia = 19, Certificado = CertificadoCaldero.KAPPA});
        lista.AddLast(new Saboteador { Nombre = "Hander", CodigoGaia = "SAB-0019-O", Descripcion = "Mecánico", añosExperiencia = 24, Certificado = CertificadoCaldero.MU});
        lista.AddLast(new Saboteador { Nombre = "Gildun", CodigoGaia = "SAB-0020-O", Descripcion = "Explorador curioso", añosExperiencia = 45, Certificado = CertificadoCaldero.SIGMA});
        
        return lista;
    }
}