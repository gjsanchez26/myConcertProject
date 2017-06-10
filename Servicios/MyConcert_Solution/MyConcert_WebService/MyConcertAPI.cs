using MyConcert_WebService.models;
using MyConcert_WebService.res;
using MyConcert_WebService.res.usr;
using MyConcert_WebService.security;
using MyConcert_WebService.server;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert_WebService
{
    class MyConcertAPI
    {
        
        public static void Main(string[] args)
        {
            using (myconcertEntities context = new myconcertEntities())
            {
               var gen = context.generos.Join(context.generosusuario,
                                           g => g.PK_generos,
                                           gu => gu.FK_GENEROSUSUARIO_GENEROS,
                                           (g, gu) => new { g, gu })
                                     .Where(r => r.gu.FK_GENEROSUSUARIO_USUARIOS == "gigi")
                                     .Select(z => new {
                                         PK_generos = z.g.PK_generos,
                                         genero = z.g.genero
                                     }).ToList();

                foreach (var i in gen)
                {
                    Console.WriteLine(context.generos.FirstOrDefault(g => g.PK_generos == i.PK_generos).genero);
                }
            }
            Console.ReadLine();
        }

       
        
    }   
        
}
