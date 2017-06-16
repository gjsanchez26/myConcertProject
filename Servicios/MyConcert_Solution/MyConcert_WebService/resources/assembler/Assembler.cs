using MyConcert.viewModels;
using System.Collections.Generic;
using System;
using MyConcert.resources.security;

namespace MyConcert.resources.assembler
{
    public class Assembler
    {
        FacadeDB _manejadorDB = new FacadeDB();
        SHA256Encriptation _encriptador= new SHA256Encriptation();

        public List<integrantes> updateintegrantes(string[] pIntegrantes)
        {
            List<integrantes> integran = new List<integrantes>();
            for (int i = 0; i < pIntegrantes.Length; i++)
            {
                Console.WriteLine(pIntegrantes[i]);
                integrantes integrante = new integrantes();
                integrante.nombreInt = pIntegrantes[i];
                integran.Add(integrante);
            }
            return integran;
        }

        public List<canciones> updatecanciones(string[] pCanciones)
        {
            List<canciones> canciones = new List<canciones>();
            for (int i = 0; i < pCanciones.Length; i++)
            {
                canciones cancion = new canciones();
                cancion.cancion = pCanciones[i];
                canciones.Add(cancion);
            }
            return canciones;
        }

        public Banda createBanda(bandas pBanda)
        {
            int id = pBanda.PK_bandas;
            string nombre = pBanda.nombreBan;
            float calificacion = _manejadorDB.getCalificacion(pBanda);
            string estado = _manejadorDB.obtenerEstado(pBanda.FK_BANDAS_ESTADOS).estado;
            Banda ban = new Banda(id, nombre, calificacion, estado);
            return ban;
        }

        public bandas updatebandas(Banda pBanda)
        {
            
            string nombre = pBanda.Nombre;
            int estado = _manejadorDB.obtenerEstado(pBanda.Estado).PK_estados;
            bandas ban = new bandas();
            ban.FK_BANDAS_ESTADOS = estado;
            ban.nombreBan = nombre;
            return ban;
        }

        public categorias updatecategorias(Categoria pCategoria)
        {
            categorias cat = new categorias();
            cat.categoria = pCategoria.Nombre;
            return cat;
        }

        public Categoria createCategoria(categorias pCategoria)
        {
            return new Categoria(pCategoria.PK_categorias, pCategoria.categoria);
        }

        public Evento createEvento(eventos pEvento)
        {
            Evento evento;
            string country, event_type, state, chef;
            country = _manejadorDB.obtenerPais(pEvento.FK_EVENTOS_PAISES).pais;
            event_type = _manejadorDB.obtenerTipoEvento(pEvento.FK_EVENTOS_TIPOSEVENTOS).tipo;
            state = _manejadorDB.obtenerEstado(pEvento.FK_EVENTOS_ESTADOS).estado;

            if (pEvento.FK_EVENTOS_TIPOSEVENTOS == 1)
            {
                

                evento =
                new Cartelera(pEvento.PK_eventos,
                                pEvento.nombreEve,
                                pEvento.ubicacion,
                                country,
                                pEvento.fechaInicio,
                                pEvento.fechaFinal,
                                pEvento.finalVotacion.Value,
                                event_type,
                                state);
            }
            else
            {
                chef = _manejadorDB.obtenerBanda((int)pEvento.FK_EVENTOS_BANDAS_CHEF).nombreBan;
                evento =
                new Festival(pEvento.PK_eventos,
                            pEvento.nombreEve,
                            pEvento.ubicacion,
                            country,
                            pEvento.fechaInicio,
                            pEvento.finalVotacion.Value,
                            event_type,
                            state,
                            pEvento.comida,
                            pEvento.transporte,
                            pEvento.servicios,
                            chef);
            }

            return evento;
        }

        public Evento[] createListaEventos(List<eventos> evens)
        {
            Evento[] arreglo = new Evento[evens.Count];
            int contador = 0;
            foreach (eventos i in evens)
            {
                arreglo[contador] = createEvento(i);
                contador++;
            }
            return arreglo;
        }

        public List<categoriasevento> updatecategoriasevento(CategoriaBanda[] pArrayCategoriaBanda)
        {
            List<categoriasevento> categoriasBandas = new List<categoriasevento>();
            categoriasevento cat_even_aux = null;
            for (int i = 0; i < pArrayCategoriaBanda.Length; i++)
            {
                for (int j = 0; j < pArrayCategoriaBanda[i]._bandasID.Length; j++)
                {
                    cat_even_aux = new categoriasevento();
                    cat_even_aux.FK_CATEGORIASEVENTO_BANDAS = pArrayCategoriaBanda[i]._bandasID[j];
                    cat_even_aux.FK_CATEGORIASEVENTO_CATEGORIAS = pArrayCategoriaBanda[i]._categoriaID;
                    categoriasBandas.Add(cat_even_aux);
                }
            }
            return categoriasBandas;
        }

        public eventos updateeventos(Cartelera pEvento)
        {
            eventos event_carte = new eventos();
            event_carte.PK_eventos = pEvento.Id;
            event_carte.nombreEve = pEvento.Nombre;
            event_carte.ubicacion = pEvento.Ubicacion;
            event_carte.FK_EVENTOS_PAISES = _manejadorDB.obtenerPais(pEvento.Pais).PK_paises;
            event_carte.fechaInicio = pEvento.FechaInicioFestival;
            event_carte.fechaFinal = pEvento.FechaInicioFestival;
            event_carte.finalVotacion = pEvento.FechaFinalVotacion;
            event_carte.FK_EVENTOS_TIPOSEVENTOS = _manejadorDB.obtenerTipoEvento(pEvento.TipoEvento).PK_tiposEventos;
            event_carte.FK_EVENTOS_ESTADOS = _manejadorDB.obtenerEstado(pEvento.Estado).PK_estados;

            return event_carte;
        }

        public eventos updateeventos(Festival pEvento)
        {
            eventos event_feste = new eventos();
            event_feste.PK_eventos = pEvento.Id;
            event_feste.nombreEve = pEvento.Nombre;
            event_feste.ubicacion = pEvento.Ubicacion;
            event_feste.FK_EVENTOS_PAISES = _manejadorDB.obtenerPais(pEvento.Pais).PK_paises;
            event_feste.fechaInicio = pEvento.FechaInicioFestival;
            event_feste.fechaFinal = pEvento.FechaInicioFestival;
            event_feste.ubicacion = pEvento.Ubicacion;
            event_feste.transporte = pEvento.Transporte;
            event_feste.servicios = pEvento.Servicios;
            event_feste.comida = pEvento.Comida;
            bandas banda = _manejadorDB.obtenerBanda(pEvento.RecomendacionChef);
            event_feste.FK_EVENTOS_BANDAS_CHEF = banda == null ? 0 : banda.PK_bandas;
            event_feste.FK_EVENTOS_TIPOSEVENTOS = _manejadorDB.obtenerTipoEvento(pEvento.TipoEvento).PK_tiposEventos;
            event_feste.FK_EVENTOS_ESTADOS = _manejadorDB.obtenerEstado(pEvento.Estado).PK_estados;

            return event_feste;
        }
        public usuarios updateusuarios(Usuario pUser)
        {

            string tipoFanatico = _manejadorDB.obtenerTipoUsuario(2).tipo;

            usuarios usuario = new usuarios();
            usuario.nombre = pUser.Nombre;
            usuario.apellido = pUser.Apellido;
            usuario.username = pUser.NombreUsuario;
            usuario.contraseña = _encriptador.sha256Encrypt(pUser.Contrasena);
            usuario.correo = pUser.Email;
            usuario.FK_USUARIOS_ESTADOS = _manejadorDB.obtenerEstado(pUser.Estado).PK_estados;
            usuario.fechaInscripcion = pUser.FechaInscripcion;

            if (pUser.TipoUsuario == tipoFanatico)
            {
                Fanatico fanatico = (Fanatico)pUser;
                usuario.fechaNacimiento = fanatico.FechaNacimiento;
                usuario.telefono = fanatico.Telefono;
                usuario.FK_USUARIOS_PAISES = _manejadorDB.obtenerPais(fanatico.Pais).PK_paises;
                usuario.descripcion = fanatico.DescripcionPersonal;
                usuario.FK_USUARIOS_TIPOSUSUARIOS = _manejadorDB.obtenerTipoUsuario(fanatico.TipoUsuario).PK_tiposUsuarios;
                usuario.FK_USUARIOS_UNIVERSIDADES = _manejadorDB.obtenerUniversidad(fanatico.Universidad).PK_universidades;
                usuario.ubicacion = fanatico.Ubicacion;
                usuario.foto = fanatico.FotoPerfil;
            }
            else
            {
                usuario.FK_USUARIOS_TIPOSUSUARIOS = _manejadorDB.obtenerTipoUsuario(pUser.TipoUsuario).PK_tiposUsuarios;
            }
            return usuario;
        }

        public Usuario createUsuario(usuarios pUser)
        {
            Usuario user = null;
            string tipoColaborador = _manejadorDB.obtenerTipoUsuario(1).tipo;
            string tipoFanatico = _manejadorDB.obtenerTipoUsuario(2).tipo;

            if (_manejadorDB.obtenerTipoUsuario(pUser.FK_USUARIOS_TIPOSUSUARIOS).tipo == tipoFanatico)
            {
                string country = _manejadorDB.obtenerPais((int)pUser.FK_USUARIOS_PAISES).pais;
                string state = _manejadorDB.obtenerEstado(pUser.FK_USUARIOS_ESTADOS).estado;
                string university = _manejadorDB.obtenerUniversidad((int)pUser.FK_USUARIOS_UNIVERSIDADES).nombreUni;
                string user_type = _manejadorDB.obtenerTipoUsuario(pUser.FK_USUARIOS_TIPOSUSUARIOS).tipo;
                user =
                    new Fanatico(pUser.nombre,
                                pUser.apellido,
                                pUser.username,
                                pUser.contraseña,
                                pUser.correo,
                                state,
                                pUser.fechaInscripcion,
                                pUser.foto,
                                pUser.fechaNacimiento.Value,
                                pUser.telefono,
                                country,
                                pUser.descripcion,
                                university,
                                user_type,
                                pUser.ubicacion);

            }
            else if (_manejadorDB.obtenerTipoUsuario(pUser.FK_USUARIOS_TIPOSUSUARIOS).tipo == tipoColaborador)
            {
                string stateColaborador = _manejadorDB.obtenerEstado(pUser.FK_USUARIOS_ESTADOS).estado;
                string user_typeColaborador = _manejadorDB.obtenerTipoUsuario(pUser.FK_USUARIOS_TIPOSUSUARIOS).tipo;
                user =
                    new Colaborador(pUser.nombre,
                                    pUser.apellido,
                                    pUser.username,
                                    pUser.contraseña,
                                    pUser.correo,
                                    stateColaborador,
                                    pUser.fechaInscripcion,
                                    user_typeColaborador);
            }

            return user;
        }

        public Universidad createUniversidad(universidades pUniversidad)
        {

            int id = pUniversidad.PK_universidades;
            string nombre = _manejadorDB.obtenerUniversidad(id).nombreUni;
            Universidad uni = new Universidad(id, nombre);
            return uni;


        }

        public Pais createPais(paises pPais)
        {
            int id = pPais.PK_paises;
            string nombre = _manejadorDB.obtenerPais(id).pais;
            Pais pais = new Pais(id, nombre);
            return pais;
        }

        public Universidad[] createListaUniversidad(List<universidades> uni)
        {
            Universidad[] arreglo = new Universidad[uni.Count];
            int contador = 0;
            foreach (universidades i in uni)
            {
                arreglo[contador] = createUniversidad(i);
                contador++;
            }
            return arreglo;
        }

        public Pais[] createListaPais(List<paises> paises) 
        {
            Pais[] arreglo = new Pais[paises.Count];
            int contador = 0;
            foreach (paises i in paises)
            {
                arreglo[contador] = createPais(i);
                contador++;
            }
            return arreglo;
        }

        public GeneroMusical[] createListaGenero(List<generos> gens)
        {
            GeneroMusical[] arreglo = new GeneroMusical[gens.Count];
            int contador = 0;
            foreach (generos i in gens)
            {   
                arreglo[contador] = createGenero(i);
                contador++;
            }
            return arreglo;
        }
        public GeneroMusical createGenero(generos pGenero)
        {
            int id = pGenero.PK_generos;
            string nombre = _manejadorDB.obtenerGenero(id).genero;
            GeneroMusical gene = new GeneroMusical(id, nombre);
            return gene;
        }

        public List<generos> updateListaGeneros(int[] pGeneros)
        {
            List<generos> listaGeneros = new List<generos>();

            foreach (int genero in pGeneros)
            {
                listaGeneros.Add(_manejadorDB.obtenerGenero(genero));
            }

            return listaGeneros;
        }

        public Comentario createComentario(comentarios coment)
        {
            int id = coment.PK_comentarios;
            string fanatico = _manejadorDB.obtenerUsuario(coment.FK_COMENTARIOS_USUARIOS).username;
            DateTime fecha = coment.fechaCreacion;
            string contenido = coment.comentario;
            float calificacion = coment.calificacion;
            string estado = _manejadorDB.obtenerEstado(coment.FK_COMENTARIOS_ESTADOS).estado;
            string banda = _manejadorDB.obtenerBanda(coment.FK_COMENTARIOS_BANDAS).nombreBan;

            Comentario nuevoComentario = new Comentario(id, fanatico, fecha, contenido, calificacion, estado, banda);
            return nuevoComentario;
        }

        public comentarios updatecomentarios(Comentario coment)
        {
            comentarios nComent = new comentarios();
            nComent.FK_COMENTARIOS_USUARIOS = coment.Fanatico;
            nComent.fechaCreacion = coment.Fecha;
            nComent.comentario = coment.Contenido;
            nComent.calificacion = coment.Calificacion;
            nComent.FK_COMENTARIOS_ESTADOS = _manejadorDB.obtenerEstado(coment.Estado).PK_estados;
            nComent.FK_COMENTARIOS_BANDAS = _manejadorDB.obtenerBanda(coment.Banda).PK_bandas;

            return nComent;
        }

        public Comentario[] createListaComentario(List<comentarios> coments)
        {
            Comentario[] arreglo = new Comentario[coments.Count];
            int contador = 0;
            foreach (comentarios i in coments)
            {
                arreglo[contador] = createComentario(i);
                contador++;
            }
            return arreglo;
        }

        public MiembroBanda createMiembroBanda(integrantes integra)
        {
            int id = integra.PK_integrantes;
            string nombre = integra.nombreInt;
            string banda = _manejadorDB.obtenerBanda(integra.FK_INTEGRANTES_BANDAS).nombreBan;

            MiembroBanda miembro = new MiembroBanda(id, nombre, banda);
            return miembro;
        }
        public MiembroBanda[] createListaIntegrantes(List<integrantes> integrantes)
        {
            MiembroBanda[] arreglo = new MiembroBanda[integrantes.Count];
            int contador = 0;
            foreach (integrantes i in integrantes)
            {
                arreglo[contador] = createMiembroBanda(i);
                contador++;
            }
            return arreglo;
        }

        public Cancion createCancion(canciones canc)
        {
            int id = canc.PK_canciones;
            string nombre = canc.cancion;
            string banda = _manejadorDB.obtenerBanda(canc.FK_CANCIONES_BANDAS).nombreBan;
            Cancion nuevaCancion = new Cancion(id, nombre, banda);
            return nuevaCancion;
        }

        public Cancion[] createListaCancion(List<canciones> canciones)
        {
            Cancion[] arreglo = new Cancion[canciones.Count];
            int contador = 0;
            foreach (canciones i in canciones)
            {
                arreglo[contador] = createCancion(i);
                contador++;
            }
            return arreglo;
        }

        public votos updatevotos (Voto voto)
        {
            votos votacion = new votos();
            votacion.valor = voto.Cantidad;
            votacion.FK_VOTOS_BANDAS = _manejadorDB.obtenerBanda(voto.Banda).PK_bandas;
            votacion.FK_VOTOS_CATEGORIAS = _manejadorDB.obtenerCategoria(voto.Categoria).PK_categorias;
            votacion.FK_VOTOS_EVENTOS = voto.Cartelera;
            votacion.FK_VOTOS_USUARIOS = voto.Fanatico;
            return votacion;
        }

        public List<votos> updateListavotos(Voto[] votaciones)
        {
            List<votos> lista = new List<votos>();
            
            foreach (Voto i in votaciones)
            {
                lista.Add(updatevotos(i));
            }
            return lista;
        }

        public Categoria[] createListaCategorias(List<categorias> cate)
        {
            Categoria[] arreglo = new Categoria[cate.Count];
            int contador = 0;
            foreach (categorias i in cate)
            {
                arreglo[contador] = createCategoria(i);
                contador++;
            }
            return arreglo;
        }
        
        public Banda[] createListaBandas(List<bandas> bandas)
        {
            Banda[] arreglo = new Banda[bandas.Count];
            int contador = 0;
            foreach (bandas i in bandas)
            {
                arreglo[contador] = createBanda(i);
                contador++;
            }
            return arreglo;
        }
    }
}
