// scheduleForm.js - Funcionalidades para el formulario de horarios

/**
 * Maneja la funcionalidad del formulario de horarios
 */
const scheduleFormManager = (function () {
    // Función de inicialización
    function init() {
        setupHorarioCopy();
        setupFormValidation();
    }

    // Función para copiar los horarios de un día a todos los demás
    function setupHorarioCopy() {
        // Para horarios de entrada
        const entryTimeFirst = document.getElementById('EntryTime_0');
        if (entryTimeFirst) {
            entryTimeFirst.addEventListener('change', function () {
                if (confirm('¿Desea aplicar este horario de entrada a todos los días?')) {
                    const value = this.value;
                    for (let i = 1; i < 7; i++) {
                        document.getElementById(`EntryTime_${i}`).value = value;
                    }
                }
            });
        }

        // Para horarios de salida
        const exitTimeFirst = document.getElementById('ExitTime_0');
        if (exitTimeFirst) {
            exitTimeFirst.addEventListener('change', function () {
                if (confirm('¿Desea aplicar este horario de salida a todos los días?')) {
                    const value = this.value;
                    for (let i = 1; i < 7; i++) {
                        document.getElementById(`ExitTime_${i}`).value = value;
                    }
                }
            });
        }
    }

    // Validación del formulario
    function setupFormValidation() {
        const form = document.getElementById('schedulesForm');
        if (!form) return;

        form.addEventListener('submit', function (event) {
            // Validar que si hay entrada para un día, también debe haber salida
            let hasError = false;
            for (let i = 0; i < 7; i++) {
                const entryTime = document.getElementById(`EntryTime_${i}`).value;
                const exitTime = document.getElementById(`ExitTime_${i}`).value;

                if ((entryTime && !exitTime) || (!entryTime && exitTime)) {
                    alert('Si define un horario de entrada, debe definir también la salida y viceversa.');
                    hasError = true;
                    break;
                }
            }

            if (hasError) {
                event.preventDefault();
                return false;
            }
        });
    }

    // Observa cambios en el DOM para detectar cuando se carga el formulario de horarios
    function setupModalObserver() {
        // Crear un observador de mutaciones que observe cambios en el contenido del modal
        const observer = new MutationObserver(function (mutations) {
            mutations.forEach(function (mutation) {
                // Verificar si se ha añadido el formulario de horarios
                if (document.getElementById('schedulesForm')) {
                    // Si encontramos el formulario de horarios, ajustamos el ancho del modal
                    const modalDialog = document.querySelector('#sharedModal .modal-dialog');
                    if (modalDialog) {
                        modalDialog.style.width = '82em';
                        modalDialog.style.maxWidth = '100%';
                        console.log('Modal de horarios detectado, ancho ajustado a 80em');
                    }
                    // Inicializar el formulario
                    init();
                    // Desconectar el observador una vez que hemos hecho los ajustes
                    observer.disconnect();
                }
            });
        });

        // Configurar el observador para que observe el contenido del modal
        const modalContent = document.getElementById('sharedModalContent');
        if (modalContent) {
            observer.observe(modalContent, { childList: true, subtree: true });
        }
    }

    // También configuramos un listener para el evento de apertura del modal
    function setupModalEventListener() {
        // Añadir un listener para cuando se muestre cualquier modal
        document.addEventListener('show.bs.modal', function (event) {
            // Verificar si el objeto que activó el evento es nuestro modal compartido
            if (event.target && event.target.id === 'sharedModal') {
                // Configurar el observador para detectar cuando se cargue el formulario de horarios
                setupModalObserver();
            }
        });

        // Añadir un listener para cuando se cierre el modal
        document.addEventListener('hidden.bs.modal', function (event) {
            // Verificar si el objeto que activó el evento es nuestro modal compartido
            if (event.target && event.target.id === 'sharedModal') {
                // Restaurar el tamaño predeterminado del modal
                const modalDialog = document.querySelector('#sharedModal .modal-dialog');
                if (modalDialog) {
                    modalDialog.style.width = '';
                    modalDialog.style.maxWidth = '';
                }
            }
        });
    }

    // Inicializar cuando el documento esté listo
    document.addEventListener('DOMContentLoaded', function () {
        // Configurar los listeners para el modal
        setupModalEventListener();

        // Si el formulario ya está presente en el DOM (caso no-modal), inicializarlo
        if (document.getElementById('schedulesForm')) {
            init();
        }
    });

    // Función para inicializar manualmente (para compatibilidad)
    function initScheduleForm() {
        init();
    }

    // Exponer funciones públicas
    return {
        init: initScheduleForm
    };
})();