using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Common
{
        public class JsonReturn
        {
            //0 - Todo ok. 1 - Error. 2 - Error (redireccionar)
            public short TipoError
            {
                get;
                set;
            }

            public bool Success
            {
                get;
                set;
            }

            public string? MensajeError
            {
                get;
                set;
            }

            public object? InnerObject
            {
                get;
                set;
            }

            public long TotalCount
            {
                get;
                set;
            }

            public static JsonReturn SuccessSinRetorno()
            {
                return new JsonReturn
                {
                    InnerObject = null,
                    MensajeError = "",
                    Success = true,
                    TipoError = 0,
                    TotalCount = 0
                };
            }

            public static JsonReturn SuccessConRetorno(object obj)
            {
                return new JsonReturn
                {
                    InnerObject = obj,
                    MensajeError = "",
                    Success = true,
                    TipoError = 0,
                    TotalCount = 0
                };
            }

            public static JsonReturn ErrorConMsjSimple(string msj = null)
            {
                return new JsonReturn
                {
                    InnerObject = null,
                    MensajeError = string.IsNullOrEmpty(msj) ? "Ocurrió un problema, reintente la operación por favor." : msj,
                    Success = false,
                    TipoError = 1,
                    TotalCount = 0
                };
            }

            public static JsonReturn ErrorConLista(string title, List<string> listaErrores)
            {
                return new JsonReturn
                {
                    InnerObject = listaErrores,
                    MensajeError = title,
                    Success = false,
                    TipoError = 1,
                    TotalCount = 0
                };
            }

            public static JsonReturn Redireccionar(string url)
            {
                return new JsonReturn
                {
                    InnerObject = null,
                    MensajeError = url,
                    Success = false,
                    TipoError = 2,
                    TotalCount = 0
                };
            }

            public static JsonReturn RedireccionarIndex()
            {
                return new JsonReturn
                {
                    InnerObject = null,
                    MensajeError = "",
                    Success = false,
                    TipoError = 2,
                    TotalCount = 0
                };
            }

            public static JsonReturn SuccessListaPaginada(object lista, long cantidad)
            {
                return new JsonReturn
                {
                    InnerObject = lista,
                    MensajeError = "",
                    Success = true,
                    TipoError = 0,
                    TotalCount = cantidad
                };
            }
        }
    }

