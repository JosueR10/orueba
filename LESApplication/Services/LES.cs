using LESApplication.Models;

namespace LESApplication.Services
{
    public class LES
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }


        public LES()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        bool EstaVacia()
        {
            return PrimerNodo == null;
        }

        public string AgregarNodoFinal(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            return "Nodo agregado al final de la lista";
        }
        public string AgregarNodoInicio(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
            return "Nodo agregado al final de la lista";
        }

        public string AgregarNodoAntesDeX(string x, string nuevoValor)
        {
            // Q actual y   T anterior
            Nodo Q = PrimerNodo; //Q y T son punteros auxiliares 
            Nodo T = null;
            int BAND = 1; //BAND será la variable de control, para saber si se encontró X
            //X es el nodo que se busca 

            //Buscar el nodo antes del que se va a agregar 
            while (Q != null && Q.Informacion != x && BAND == 1)
            {
                if (Q.Referencia != null)
                {
                    T = Q;
                    Q = Q.Referencia;
                }
                else
                {
                    BAND = 0; //si no se encuentra, Banda se pone en 0 
                }
            }

            if (BAND == 1)//Si X fue encontrado
            {
                Nodo nuevoNodo = new Nodo(nuevoValor);
                if (PrimerNodo == Q)//si X es el primer Nodo
                {
                    nuevoNodo.Referencia = PrimerNodo;
                    PrimerNodo = nuevoNodo;
                }
                else
                {
                    nuevoNodo.Referencia = Q;
                    T.Referencia = nuevoNodo;
                }
                return "Nodo agregado";

            }
            else
            {
                return ($"el nodo con valor {x} no fue encontrado en la lista");
            }

        }
        public string AgregarDespuesDeX(string x, string nuevoValor)
        {
            Nodo Q = PrimerNodo; //Q son punteros auxiliares
            int BAND = 1; //BAND será la variable de control, para saber si se encontró X
            //X es el nodo que se busca 

            //Buscar el nodo antes del que se va a agregar 
            while (Q != null && Q.Informacion != x && BAND == 1)
            {
                if (Q.Referencia != null)
                {
                    Q = Q.Referencia;
                }
                else
                {
                    BAND = 0; //si no se encuentra, Banda se pone en 0 
                }
            }

            if (BAND == 1)//Si X fue encontrado
            {
                Nodo nuevoNodo = new Nodo(nuevoValor);

                //Enlazamos el nuevo nodo 
                nuevoNodo.Referencia = Q.Referencia;
                Q.Referencia = nuevoNodo;

                return "Nodo agregado";
            }
            else
            {
                return ($"el nodo con valor {x} no fue encontrado en la lista");
            }

        }

        public string AgregarNodoEnPosicionEspecifica(int posicion, string nuevoValor)
        {
            if (posicion < 0)
            {
                return "Posición no válida.";
            }

            Nodo nuevoNodo = new Nodo(nuevoValor);

            if (EstaVacia() || posicion == 0)
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;

                // Si solo hay un nodo, también es el último
                if (UltimoNodo == null)
                {
                    UltimoNodo = nuevoNodo;
                }

                return "Nodo agregado al inicio.";
            }

            //Apuntadores auxiliares
            Nodo actual = PrimerNodo;
            Nodo anterior = null;
            int contador = 0;

            while (actual != null && contador < posicion)
            {
                anterior = actual;
                actual = actual.Referencia;
                contador++;
            }

            if (anterior != null)
            {
                nuevoNodo.Referencia = actual;
                anterior.Referencia = nuevoNodo;

                // Si el nodo se insertó al final, actualizar el último nodo
                if (actual == null)
                {
                    UltimoNodo = nuevoNodo;
                }

                return $"Nodo agregado en la posición {posicion}.";
            }

            return "No se pudo agregar el nodo.";
        }

        public string AgregarNodoAntesDePosicion(int posicion, string nuevoValor)
        {
            if (posicion < 0)
            {
                return "Posición no válida.";
            }

            Nodo nuevoNodo = new Nodo(nuevoValor);

            if (EstaVacia() || posicion == 0)
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;

                // Si solo hay un nodo, también es el último
                if (UltimoNodo == null)
                {
                    UltimoNodo = nuevoNodo;
                }

                return "Nodo agregado al inicio.";
            }

            //Apuntadores auxiliares
            Nodo actual = PrimerNodo;
            Nodo anterior = null;
            int contador = 0;

            while (actual != null && contador < posicion)
            {
                anterior = actual;
                actual = actual.Referencia;
                contador++;
            }

            if (anterior != null)
            {
                nuevoNodo.Referencia = actual;
                anterior.Referencia = nuevoNodo;

                // Si el nodo se insertó al final, actualizar el último nodo
                if (actual == null)
                {
                    UltimoNodo = nuevoNodo;
                }

                return $"Nodo agregado en la posición {posicion}.";
            }

            return "No se pudo agregar el nodo.";
        }

        public string AgregarNodoDespuesPosicionEspecifica(int posicion, string nuevoValor)
        {
            if (posicion < 0)
            {
                return "Posición no válida.";
            }

            Nodo nuevoNodo = new Nodo(nuevoValor);

            // Caso especial: si la lista está vacía, agregar al inicio
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
                return "Nodo agregado al inicio (lista vacía).";
            }

            Nodo actual = PrimerNodo;
            int contador = 0;

            // Recorrer la lista hasta la posición deseada
            while (actual != null && contador < posicion)
            {
                actual = actual.Referencia;
                contador++;
            }

            // Verificar si la posición es válida
            if (actual == null)
            {
                return "Posición fuera de rango.";
            }

            // Insertar el nuevo nodo después de la posición deseada
            nuevoNodo.Referencia = actual.Referencia; // El nuevo nodo apunta al siguiente nodo de actual
            actual.Referencia = nuevoNodo; // El nodo actual apunta al nuevo nodo

            // Si el nuevo nodo se insertó al final, actualizar el último nodo
            if (nuevoNodo.Referencia == null)
            {
                UltimoNodo = nuevoNodo;
            }

            return $"Nodo agregado después de la posición {posicion}.";
        }

        public void RecorridoRecursivo(Nodo nodoActual)
        {
            // Caso base: si el nodo actual es null, terminamos la recursión
            if (nodoActual == null)
            {
                return;
            }

            // Mostrar el valor del nodo actual (puedes usar Console.WriteLine o almacenarlo en una lista)
            Console.WriteLine(nodoActual.Informacion);

            // Llamada recursiva para el siguiente nodo
            RecorridoRecursivo(nodoActual.Referencia);
        }


        public int BuscarElemento(string valor)
        {
            Nodo? Q = PrimerNodo;
            int posicion = 0; // Contador para llevar la posición actual

            while (Q != null)
            {
                if (Q.Informacion == valor)
                {
                    return posicion; // Retornar la posición si se encuentra el valor
                }
                Q = Q.Referencia;
                posicion++; // Incrementar la posición
            }
            return -1; // Retornar -1 si no se encuentra el valor
        }


        //---------------PROCESO DE ELIMINACION DE NODOS ---------------------------
        public string EliminarNodoAlInicio()
        {
            if (EstaVacia())
            {
                return "La lista está vacía ";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo NodoTemporal;
                NodoTemporal = PrimerNodo;

                //LIGAR EL SEGUNDO COMO PRIMER NODO 
                PrimerNodo = PrimerNodo.Referencia;
                NodoTemporal = null;
            }

            return "Nodo eliminado";
        }

        public string EliminarNodoAlFinal()
        {
            if (EstaVacia())
            {
                return "La lista está vacía ";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo NodoActual;
                Nodo NodoSiguiente;

                NodoActual = PrimerNodo;
                NodoSiguiente = NodoActual.Referencia;

                while (NodoSiguiente.Referencia != null)
                {
                    NodoActual = NodoActual.Referencia;
                    NodoSiguiente = NodoActual.Referencia;
                }

                NodoSiguiente = null;
                NodoActual.Referencia = null;
                UltimoNodo = NodoActual;
            }
            return "Nodo Eliminado";
        }


        public string EliminarNodoAntesDeX(string valorReferencia)
        {
            if (EstaVacia())
                return "La lista está vacía, no puede continuar!!!";

            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;
            Nodo nodoAnteriorDelAnterior = null;

            // Buscar el nodo con el valor de referencia
            while (nodoActual != null && !nodoActual.Informacion.Equals(valorReferencia))
            {
                nodoAnteriorDelAnterior = nodoAnterior;
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Referencia;
            }

            if (nodoActual == null)
            {
                return $"El valor de referencia ({valorReferencia}) no fue encontrado en la lista!!!";
            }

            if (nodoAnterior == null)
            {
                return $"No hay nodo antes de {valorReferencia} para eliminar (es el primer nodo)";
            }

            // Eliminar el nodo anterior
            if (nodoAnteriorDelAnterior == null)
            {
                PrimerNodo = nodoActual; // Caso cuando se elimina el primer nodo
            }
            else
            {
                nodoAnteriorDelAnterior.Referencia = nodoActual;
            }

            // Actualizar UltimoNodo si es necesario
            if (nodoActual.Referencia == null)
            {
                UltimoNodo = nodoActual;
            }

            return $"Nodo con valor {nodoAnterior.Informacion} eliminado (estaba antes de {valorReferencia})";
        }
        //----------Segunda parte----------------------

        public string EliminarNodoDespuesDeX(string valorX)
        {
            if (EstaVacia()) return "La lista está vacía, no puede continuar!!!";

            Nodo actual = PrimerNodo;

            // Buscar el nodo con el valor X
            while (actual != null && !actual.Informacion.Equals(valorX))
            {
                actual = actual.Referencia;
            }

            if (actual == null)
            {
                return $"El nodo con valor {valorX} no fue encontrado!!!";
            }

            if (actual.Referencia == null)
            {
                return $"No hay nodo después de {valorX} para eliminar!!!";
            }

            Nodo nodoAEliminar = actual.Referencia;
            actual.Referencia = nodoAEliminar.Referencia;
            nodoAEliminar = null;

            // Si eliminamos el último nodo, actualizar UltimoNodo
            if (actual.Referencia == null)
            {
                UltimoNodo = actual;
            }

            return $"Nodo después de {valorX} eliminado!!!";
        }


        // Método para eliminar nodo en posición específica
        public string EliminarNodoEnPosicion(int posicion)
        {
            if (EstaVacia()) return "La lista está vacía, no puede continuar!!!";

            if (posicion < 0)
            {
                return "Posición no válida!!!";
            }

            if (posicion == 0)
            {
                return EliminarNodoAlInicio();
            }

            Nodo actual = PrimerNodo;
            Nodo anterior = null;
            int contador = 0;

            while (actual != null && contador < posicion)
            {
                anterior = actual;
                actual = actual.Referencia;
                contador++;
            }

            if (actual == null)
            {
                return $"La posición {posicion} está fuera de rango!!!";
            }

            anterior.Referencia = actual.Referencia;

            // Si eliminamos el último nodo, actualizar UltimoNodo
            if (anterior.Referencia == null)
            {
                UltimoNodo = anterior;
            }

            actual = null;
            return $"Nodo en posición {posicion} eliminado!!!";
        }

        public bool EstaOrdenada()
        {
            if (EstaVacia() || PrimerNodo.Referencia == null)
                return true;

            Nodo actual = PrimerNodo;
            while (actual.Referencia != null)
            {
                if (string.Compare(actual.Informacion, actual.Referencia.Informacion) > 0)
                    return false;
                actual = actual.Referencia;
            }
            return true;
        }


        // Método de ordenamiento (Bubble Sort para lista enlazada)
        public string OrdenarLista()
        {
            if (EstaVacia() || PrimerNodo.Referencia == null)
            {
                return "La lista está vacía o tiene un solo elemento, no es necesario ordenar";
            }

            bool huboCambios;
            do
            {
                huboCambios = false;
                Nodo actual = PrimerNodo;
                Nodo anterior = null;

                while (actual != null && actual.Referencia != null)
                {
                    // Convertir a números para comparar
                    int valorActual = int.Parse(actual.Informacion);
                    int valorSiguiente = int.Parse(actual.Referencia.Informacion);

                    if (valorActual > valorSiguiente) // <- Comparación numérica
                    {
                        // Intercambiar nodos
                        Nodo siguiente = actual.Referencia;
                        actual.Referencia = siguiente.Referencia;
                        siguiente.Referencia = actual;

                        if (anterior == null)
                        {
                            PrimerNodo = siguiente;
                        }
                        else
                        {
                            anterior.Referencia = siguiente;
                        }

                        if (actual.Referencia == null)
                        {
                            UltimoNodo = actual;
                        }

                        anterior = siguiente;
                        huboCambios = true;
                    }
                    else
                    {
                        anterior = actual;
                        actual = actual.Referencia;
                    }
                }
            } while (huboCambios);

            return "Lista ordenada!!!";
        }
    }
}
