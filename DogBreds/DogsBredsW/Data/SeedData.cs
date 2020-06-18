using DogBredsModel;
using DogBredsModel.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogsBredsW.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new DogsContext(serviceProvider.GetRequiredService<DbContextOptions<DogsContext>>()))
            {
                context.Database.EnsureCreated();

                #region Origenes
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Alemania))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Alemania
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.America))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.America
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Asia))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Asia
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.China))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.China
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Europa))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Europa
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Italia))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Italia
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Irlanda))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Irlanda
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Francia))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Francia
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Turquia))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Turquia
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.UK))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.UK
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Canada))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Canada
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Suiza))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Suiza
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Espana))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Espana
                    });
                if (!context.Origenes.Any(pt => pt.Nombre == Origenes.Rusia))
                    context.Origenes.Add(new Origin
                    {
                        Nombre = Origenes.Rusia
                    });
                #endregion

                #region Caracteristicas
                if (!context.Caracteristicas.Any(pt => pt.Nombre == Caracteristicas.Rustico))
                    context.Caracteristicas.Add(new CaracFisic
                    {
                        Nombre = Caracteristicas.Rustico
                    });
                if (!context.Caracteristicas.Any(pt => pt.Nombre == Caracteristicas.Alargado))
                    context.Caracteristicas.Add(new CaracFisic
                    {
                        Nombre = Caracteristicas.Alargado
                    });
                if (!context.Caracteristicas.Any(pt => pt.Nombre == Caracteristicas.Musculoso))
                    context.Caracteristicas.Add(new CaracFisic
                    {
                        Nombre = Caracteristicas.Musculoso
                    });
                if (!context.Caracteristicas.Any(pt => pt.Nombre == Caracteristicas.Fino))
                    context.Caracteristicas.Add(new CaracFisic
                    {
                        Nombre = Caracteristicas.Fino
                    });
                if (!context.Caracteristicas.Any(pt => pt.Nombre == Caracteristicas.LongEars))
                    context.Caracteristicas.Add(new CaracFisic
                    {
                        Nombre = Caracteristicas.LongEars
                    });
                if (!context.Caracteristicas.Any(pt => pt.Nombre == Caracteristicas.Proporcionado))
                    context.Caracteristicas.Add(new CaracFisic
                    {
                        Nombre = Caracteristicas.Proporcionado
                    });
                #endregion

                #region Tipos de pelo
                if (!context.HairTypes.Any(pt => pt.Nombre == HairTypes.Duro))
                    context.HairTypes.Add(new HairType
                    {
                        Nombre = HairTypes.Duro
                    });
                if (!context.HairTypes.Any(pt => pt.Nombre == HairTypes.Largo))
                    context.HairTypes.Add(new HairType
                    {
                        Nombre = HairTypes.Largo
                    });
                if (!context.HairTypes.Any(pt => pt.Nombre == HairTypes.Corto))
                    context.HairTypes.Add(new HairType
                    {
                        Nombre = HairTypes.Corto
                    });
                if (!context.HairTypes.Any(pt => pt.Nombre == HairTypes.Seco))
                    context.HairTypes.Add(new HairType
                    {
                        Nombre = HairTypes.Seco
                    });
                if (!context.HairTypes.Any(pt => pt.Nombre == HairTypes.Grueso))
                    context.HairTypes.Add(new HairType
                    {
                        Nombre = HairTypes.Grueso
                    });
                if (!context.HairTypes.Any(pt => pt.Nombre == HairTypes.Medio))
                    context.HairTypes.Add(new HairType
                    {
                        Nombre = HairTypes.Medio
                    });
                if (!context.HairTypes.Any(pt => pt.Nombre == HairTypes.Liso))
                    context.HairTypes.Add(new HairType
                    {
                        Nombre = HairTypes.Liso
                    });
                #endregion

                context.SaveChangesAsync().Wait();
                #region Razas

                var caracteristicas = context.Caracteristicas.ToListAsync().Result;
                var origenes = context.Origenes.ToListAsync().Result;
                var tipospelo = context.HairTypes.ToListAsync().Result;
                if (!context.Razas.Any())
                {
                    // Lobero Irlandes
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Alta,
                        Nombre = RazasNames.LobIrlandes,
                        Altura = Alturas._80More,
                        EsperanzaDeVida = Esperanzas._8a10,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Rustico)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Musculoso)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Alargado)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Europa)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Irlanda)}
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Largo)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Grueso)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Duro)}
                        }
                    });
                    // Mastin tibetano
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Media,
                        Nombre = RazasNames.MastinTib,
                        Altura = Alturas._70a80,
                        EsperanzaDeVida = Esperanzas._12a14,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Rustico)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Musculoso)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Alargado)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Asia)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.China)}
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Medio)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Grueso)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Duro)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Liso)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Seco)}
                        }
                    });
                    // Schnauzer Gigante
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Alta,
                        Nombre = RazasNames.SchnauzerG,
                        Altura = Alturas._55a70,
                        EsperanzaDeVida = Esperanzas._12a14,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Rustico)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Musculoso)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Europa)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Alemania)},
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Medio)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Grueso)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Duro)}
                        }
                    });
                    // San Bernardo
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Media,
                        Nombre = RazasNames.SanBernardo,
                        Altura = Alturas._80More,
                        EsperanzaDeVida = Esperanzas._8a10,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Rustico)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Musculoso)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Proporcionado)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Europa)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Italia)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Suiza)}
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Largo)}
                        }
                    });
                    // Perro de los pirineos
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Media,
                        Nombre = RazasNames.PerroPirineos,
                        Altura = Alturas._70a80,
                        EsperanzaDeVida = Esperanzas._10a12,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Rustico)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Musculoso)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Alargado)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Europa)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Francia)},
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Medio)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Liso)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Duro)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Grueso)}
                        }
                    });
                    // Perro terranova
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Baja,
                        Nombre = RazasNames.PerroTerranova,
                        Altura = Alturas._55a70,
                        EsperanzaDeVida = Esperanzas._8a10,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Rustico)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Musculoso)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Proporcionado)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.LongEars)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.America)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Canada)},
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Medio)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Grueso)}
                        }
                    });
                    // Gran danes
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Media,
                        Nombre = RazasNames.GranDanes,
                        Altura = Alturas._80More,
                        EsperanzaDeVida = Esperanzas._8a10,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Proporcionado)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.LongEars)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Alargado)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Europa)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Alemania)},
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Corto)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Liso)}
                        }
                    });
                    // Lebrel escoces
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Alta,
                        Nombre = RazasNames.LebrelEscoces,
                        Altura = Alturas._70a80,
                        EsperanzaDeVida = Esperanzas._8a10,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Fino)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Europa)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.UK)},
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Largo)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Grueso)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Duro)}
                        }
                    });
                    // Kagnal
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Alta,
                        Nombre = RazasNames.Kagnal,
                        Altura = Alturas._80More,
                        EsperanzaDeVida = Esperanzas._12a14,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Rustico)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Musculoso)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Europa)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Turquia)},
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Corto)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Grueso)}
                        }
                    });
                    // Pastor caucásico
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Alta,
                        Nombre = RazasNames.PastorCaucasico,
                        Altura = Alturas._55a70,
                        EsperanzaDeVida = Esperanzas._10a12,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Rustico)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Musculoso)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Proporcionado)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.LongEars)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Europa)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Rusia)},
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Largo)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Medio)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Liso)}
                        }
                    });
                    // Mastín español
                    context.Razas.Add(new Raza
                    {
                        Actividad = Actividades.Alta,
                        Nombre = RazasNames.MastinEspañol,
                        Altura = Alturas._70a80,
                        EsperanzaDeVida = Esperanzas._12a14,
                        CaracFisics = new List<RazaCaracFisic>(){
                            new RazaCaracFisic { CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Rustico)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.Musculoso)},
                            new RazaCaracFisic{ CaracFisic = caracteristicas.SingleOrDefault(x => x.Nombre == Caracteristicas.LongEars)}
                        },
                        Origenes = new List<RazaOrigen>(){
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Europa)},
                            new RazaOrigen { Origin = origenes.SingleOrDefault(x => x.Nombre == Origenes.Espana)},
                        },
                        TiposDePelo = new List<RazaHairType>
                        {
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Medio)},
                            new RazaHairType { HairType = tipospelo.SingleOrDefault(x => x.Nombre == HairTypes.Grueso)}
                        }
                    });
                }

                #endregion

                context.SaveChangesAsync().Wait();
            }
        }
    }
}
