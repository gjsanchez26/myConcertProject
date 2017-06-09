using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService
{
    public class ManejadorBD
    {
        public bool conexionBaseDatos()
        {
            using (myconcertEntities dbContext = new myconcertEntities())
            {
                 return dbContext.Database.Exists();

            }

        }
        //OBTENER ALGUN OBJETO BASE DE DATOS
        public bandas obtenerBanda(int PK_banda)
        {
            bandas obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.bandas.FirstOrDefault(r => r.PK_bandas == PK_banda);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public canciones obtenerCancion(int PK_cancion)
        {
            canciones obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.canciones.FirstOrDefault(r => r.PK_canciones == PK_cancion);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public categorias obtenerCategoria(int PK_categoria)
        {
            categorias obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.categorias.FirstOrDefault(r => r.PK_categorias == PK_categoria);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public categoriasevento obtenerCategoriasEvento(int PK_categoriasEvento)
        {
            categoriasevento obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.categoriasevento.FirstOrDefault(r => r.PK_categoriasEvento == PK_categoriasEvento);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public comentarios obtenerComentario(int PK_comentario)
        {
            comentarios obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.comentarios.FirstOrDefault(r => r.PK_comentarios == PK_comentario);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public estados obtenerEstado(int PK_estado)
        {
            estados obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.estados.FirstOrDefault(r => r.PK_estados == PK_estado);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public eventos obtenerEvento (int PK_evento)
        {
            eventos obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.eventos.FirstOrDefault(r => r.PK_eventos == PK_evento);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public generos obtenerGenero(int PK_genero)
        {
            generos ge = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    ge = context.generos.FirstOrDefault(g => g.PK_generos == PK_genero);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return ge;
        }

        public generosbanda obtenerGenerosBanda(int PK_generosBanda)
        {
            generosbanda obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.generosbanda.FirstOrDefault(g => g.PK_generosBanda == PK_generosBanda);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public generosusuario obtenerGenerosUsuario(int PK_generosUsuario)
        {
            generosusuario obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.generosusuario.FirstOrDefault(g => g.PK_generosUsuario == PK_generosUsuario);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public integrantes obtenerIntegrante(int PK_integrante)
        {
            integrantes obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.integrantes.FirstOrDefault(g => g.PK_integrantes == PK_integrante);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public paises obtenerPais(int PK_pais)
        {
            paises obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.paises.FirstOrDefault(g => g.PK_paises == PK_pais);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public tiposeventos obtenerTipoEvento(int PK_tipoEvento)
        {
            tiposeventos obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.tiposeventos.FirstOrDefault(g => g.PK_tiposEventos == PK_tipoEvento);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public tiposusuarios obtenerTipoUsuario(int PK_tipoUsuario)
        {
            tiposusuarios obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.tiposusuarios.FirstOrDefault(g => g.PK_tiposUsuarios == PK_tipoUsuario);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public universidades obtenerUniversidad(int PK_universidad)
        {
            universidades obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.universidades.FirstOrDefault(g => g.PK_universidades == PK_universidad);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public usuarios obtenerUsuario(string username)
        {
            usuarios us = null;
            try
            {
                
                using (myconcertEntities context = new myconcertEntities())
                {
                    us = context.usuarios.FirstOrDefault(r => r.username == username);
                }
                
            }
            catch(Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return us;
        }

        public votos obtenerVoto(int PK_voto)
        {
            votos obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.votos.FirstOrDefault(g => g.PK_votos == PK_voto);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }


        //AÑADIR ALGUN OBJETO A BASE DE DATOS

        public void añadirBanda (bandas banda, List<integrantes> integ, List<canciones> canciones, List<generosbanda> genBan)
        {
            

                using (myconcertEntities context = new myconcertEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                    try
                    {
                        banda = context.bandas.Add(banda);

                        foreach (integrantes i in integ)
                        {
                            i.FK_INTEGRANTES_BANDAS = banda.PK_bandas;
                            context.integrantes.Add(i);
                        }
                        foreach (canciones c in canciones)
                        {
                            c.FK_CANCIONES_BANDAS = banda.PK_bandas;
                            context.canciones.Add(c);
                        }
                        foreach (generosbanda gB in genBan)
                        {
                            gB.FK_GENEROSBANDA_BANDAS = banda.PK_bandas;
                            context.generosbanda.Add(gB);
                        }

                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.InnerException.ToString());
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public void añadirCancion(canciones cancion)
        {
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    context.canciones.Add(cancion);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
        }

        public void añadirUsuario (usuarios us, List<generosusuario> generosUs)
        {
            
                using (myconcertEntities context = new myconcertEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {


                            us= context.usuarios.Add(us);

                            foreach (generosusuario genUs in generosUs)
                            {
                                genUs.FK_GENEROSUSUARIO_USUARIOS = us.username;
                                context.generosusuario.Add(genUs);
                            }

                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            Console.Write(ex.InnerException.ToString());

                        }
                    }
                }

            
            
        }

        public void añadirGeneroUsuario(generosusuario genUs)
        {
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    context.generosusuario.Add(genUs);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
        }

        
        public List<generos> obtenerGeneros()
        {
            List<generos> gen = null;
            
    
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    gen = context.generos.ToList();

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return gen;
        }
    
        public List <paises> obtenerPaises()
        {
            List<paises> lista = null;


            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    lista = context.paises.ToList();

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return lista;
        }
    
        public List<universidades> obtenerUniversidades()
        {
            List<universidades> lista = null;


            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    lista = context.universidades.ToList();

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return lista;
        }

        public List<bandas> obtenerBandasNoCartelera(eventos cartelera)
        {
            List<bandas> bandasCarte=null;
            string query = @"SELECT B.PK_bandas, B.nombreBan, B.FK_BANDAS_ESTADOS " +
                            "FROM bandas as B INNER JOIN categoriasevento as CE " +
                            "on CE.FK_CATEGORIASEVENTO_BANDAS = B.PK_bandas " +
                            "where CE.FK_CATEGORIASEVENTO_EVENTOS != ?PK_eventos";

            MySqlParameter[] parameters = {
            new MySqlParameter("?PK_eventos", cartelera.PK_eventos)
        };
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                  
                    bandasCarte = context.bandas.SqlQuery(query, parameters).ToList<bandas>();
                    
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return bandasCarte;
        }
        
        public int getCantidadComentarios (bandas banda)
        {
            int cantidadComen = 0;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    cantidadComen = context.comentarios.Count(r => r.FK_COMENTARIOS_BANDAS == banda.PK_bandas);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return cantidadComen;
        }
        
        public float getCalificacion(bandas banda)
        {
            float calificacion = 0;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    calificacion = (float)context.comentarios.Where(r=> r.FK_COMENTARIOS_BANDAS==banda.PK_bandas).Average(r=>r.calificacion);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return calificacion;
        } 
    }
}
