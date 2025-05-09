// costcenterform.js - Funcionalidades para el formulario de centros de costo y modales de empleados

/**
 * Maneja la funcionalidad del formulario de centros de costo y modales de empleados
 */
const costCenterFormManager = (function () {
    // Lista de IDs de formularios de empleados
    const employeeFormIds = [
        'employeeDataForm',       // Datos del Empleado
        'paymentMethodsForm',     // Forma de Pago
        'generalEmployeeDataForm', // Datos Generales
        'incomeConfigForm',       // Configuración Ingresos
        'defaultIncomeForm',      // Ingresos Predeterminados
        'employeeNotesForm'       // Observaciones
    ];

    // Verifica si el formulario actual es un formulario de empleados
    function isEmployeeForm() {
        for (const formId of employeeFormIds) {
            if (document.getElementById(formId)) {
                return true;
            }
        }
        return false;
    }

    // Función de inicialización para formulario de centros de costo
    function init() {
        setupFormValidation();
    }

    // Inicializar el acordeón para formularios de empleados
    function initEmployeeAccordion() {
        // Encontrar todos los card-header en el formulario de empleados
        const cardHeaders = document.querySelectorAll('.employee-section-card .card-header');

        // Para cada card-header, añadir la funcionalidad de acordeón
        cardHeaders.forEach((header, index) => {
            // Añadir cursor pointer y estilo de acordeón
            header.style.cursor = 'pointer';
            header.classList.add('accordion-header');

            // Añadir un contenedor para el ícono existente y un ícono de expansión/colapso
            const existingIcon = header.querySelector('i');
            if (existingIcon) {
                // Ajustar el estilo para incluir un indicador de acordeón
                header.classList.add('d-flex', 'justify-content-between', 'align-items-center');

                // Crear contenedor para el título
                const titleContainer = document.createElement('div');
                titleContainer.className = 'd-flex align-items-center';

                // Mover el ícono existente y el título al contenedor
                const headerTitle = header.querySelector('h6');

                // Clonar los elementos originales
                const iconClone = existingIcon.cloneNode(true);
                const titleClone = headerTitle.cloneNode(true);

                // Añadirlos al nuevo contenedor
                titleContainer.appendChild(iconClone);
                titleContainer.appendChild(titleClone);

                // Limpiar el header
                header.innerHTML = '';

                // Añadir el nuevo contenedor al header
                header.appendChild(titleContainer);

                // Añadir el ícono de expansión/colapso
                const collapseIcon = document.createElement('i');
                collapseIcon.className = 'fas fa-chevron-down';
                collapseIcon.style.transition = 'transform 0.3s';
                header.appendChild(collapseIcon);

                // Buscar el cuerpo de la tarjeta relacionado
                const cardBody = header.nextElementSibling;

                // Añadir clase de acordeón al cuerpo
                cardBody.classList.add('accordion-collapse');

                // Si no es el primer panel, colapsar al inicio
                if (index > 0) {
                    cardBody.style.display = 'none';
                    collapseIcon.style.transform = 'rotate(-90deg)';
                }

                // Añadir evento de clic para mostrar/ocultar el contenido
                header.addEventListener('click', function () {
                    // Toggle del cuerpo del acordeón
                    if (cardBody.style.display === 'none') {
                        cardBody.style.display = 'block';
                        collapseIcon.style.transform = 'rotate(0deg)';
                    } else {
                        cardBody.style.display = 'none';
                        collapseIcon.style.transform = 'rotate(-90deg)';
                    }
                });
            }
        });

        console.log('Acordeón de empleados inicializado');
    }

    // Validación básica del formulario
    function setupFormValidation() {
        const form = document.getElementById('costCentersForm');
        if (!form) return;

        form.addEventListener('submit', function (event) {
            // Aquí puedes añadir validaciones específicas para el formulario de centros de costo
            // Por ejemplo, validar que el código y nombre no estén vacíos
            const code = document.getElementById('costCenterCode');
            const name = document.getElementById('costCenterName');

            if (code && !code.value.trim()) {
                alert('El código del centro de costo es obligatorio.');
                event.preventDefault();
                return false;
            }

            if (name && !name.value.trim()) {
                alert('El nombre del centro de costo es obligatorio.');
                event.preventDefault();
                return false;
            }
        });
    }

    // Ajusta el tamaño del modal según el formulario cargado
    function adjustModalSize() {
        const modalDialog = document.querySelector('#sharedModal .modal-dialog');
        if (!modalDialog) return;

        if (document.getElementById('costCentersForm') || isEmployeeForm()) {
            // Aplicar el mismo tamaño para centros de costo y formularios de empleados
            modalDialog.style.width = '70em';
            modalDialog.style.maxWidth = '95%';
            console.log('Modal detectado, ancho ajustado a 70em');

            // Inicializar el formulario si es un centro de costos
            if (document.getElementById('costCentersForm')) {
                init();
            }

            // Inicializar acordeón si es un formulario de empleados
            if (isEmployeeForm()) {
                initEmployeeAccordion();
            }
        }
    }

    // Observa cambios en el DOM para detectar cuando se carga un formulario en el modal
    function setupModalObserver() {
        // Crear un observador de mutaciones que observe cambios en el contenido del modal
        const observer = new MutationObserver(function (mutations) {
            mutations.forEach(function (mutation) {
                // Verificar si se ha añadido alguno de nuestros formularios
                if (document.getElementById('costCentersForm') || isEmployeeForm()) {
                    // Ajustar el tamaño del modal
                    adjustModalSize();
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
                // Configurar el observador para detectar cuando se cargue nuestros formularios
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
        if (document.getElementById('costCentersForm')) {
            init();
        }

        // También verificar si hay algún formulario de empleados cargado
        if (isEmployeeForm()) {
            adjustModalSize();
            initEmployeeAccordion();
        }
    });

    // Función para inicializar manualmente (para compatibilidad)
    function initCostCenterForm() {
        init();
    }

    // Exponer funciones públicas
    return {
        init: initCostCenterForm,
        initEmployeeAccordion: initEmployeeAccordion
    };
})();