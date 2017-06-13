using MyConcert_WebService.viewModels;
using MyConcert_WebService.security;
using System.Collections.Generic;

namespace MyConcert_WebService.res.assembler
{
    class Assembler
    {
        ManejadorBD _manejadorDB = new ManejadorBD();
        SHA256Encriptation _encriptador= new SHA256Encriptation();

        public List<integrantes> updateintegrantes(string[] pIntegrantes)
        {
            List<integrantes> integran = new List<integrantes>();
            for (int i = 0; i < integran.Count; i++)
            {
                integrantes integrante = new integrantes();
                integrante.nombreInt = pIntegrantes[i];
                integran.Add(integrante);
            }
            return integran;
        }

        public List<canciones> updatecanciones(string[] pCanciones)
        {
            List<canciones> canciones = new List<canciones>();
            for (int i = 0; i < canciones.Count; i++)
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
                for (int j = 0; j < pArrayCategoriaBanda[i]._bandasID.Length; i++)
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
            event_carte.FK_EVENTOS_PAISES = manejadorDB.obtenerPais(pEvento.Pais).PK_paises;
            event_carte.fechaInicio = pEvento.FechaInicioFestival;
            event_carte.fechaFinal = pEvento.FechaInicioFestival;
            event_carte.finalVotacion = pEvento.FechaFinalVotacion;
            event_carte.FK_EVENTOS_TIPOSEVENTOS = manejadorDB.obtenerTipoEvento(pEvento.TipoEvento).PK_tiposEventos;
            event_carte.FK_EVENTOS_ESTADOS = manejadorDB.obtenerEstado(pEvento.Estado).PK_estados;

            return event_carte;
        }

        public eventos updateeventos(Festival pEvento)
        {
            eventos event_feste = new eventos();
            event_feste.PK_eventos = pEvento.Id;
            event_feste.nombreEve = pEvento.Nombre;
            event_feste.ubicacion = pEvento.Ubicacion;
            event_feste.FK_EVENTOS_PAISES = manejadorDB.obtenerPais(pEvento.Pais).PK_paises;
            event_feste.fechaInicio = pEvento.FechaInicioFestival;
            event_feste.fechaFinal = pEvento.FechaInicioFestival;
            event_feste.ubicacion = pEvento.Ubicacion;
            event_feste.transporte = pEvento.Transporte;
            event_feste.servicios = pEvento.Servicios;
            event_feste.comida = pEvento.Comida;
            event_feste.FK_EVENTOS_BANDAS_CHEF = manejadorDB.obtenerBanda(pEvento.RecomendacionChef).PK_bandas;
            event_feste.FK_EVENTOS_TIPOSEVENTOS = manejadorDB.obtenerTipoEvento(pEvento.TipoEvento).PK_tiposEventos;
            event_feste.FK_EVENTOS_ESTADOS = manejadorDB.obtenerEstado(pEvento.Estado).PK_estados;

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

        public GeneroMusical createGenero(generos pGenero)
        {
            int id = pGenero.PK_generos;
            string nombre = _manejadorDB.obtenerGenero(id).genero;
            GeneroMusical gene = new GeneroMusical(id, nombre);
            return gene;
        }

        public List<generos> createGenerosFavoritos(int[] pGeneros)
        {
            List<generos> listaGeneros = new List<generos>();

            foreach (int genero in pGeneros)
            {
                listaGeneros.Add(_manejadorDB.obtenerGenero(genero));
            }

            return listaGeneros;
        }
    }
}
