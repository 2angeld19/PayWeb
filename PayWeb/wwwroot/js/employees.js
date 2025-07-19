/**
 * Configura los acordeones para las secciones de empleados
 */
function setupEmployeeAccordions() {
    // Primero, intentemos buscar los elementos dentro de los modales dinámicos
    const modalContent = document.querySelector('.modal-body');
    if (!modalContent) {
        console.log('El modal no está cargado aún. Los acordeones se inicializarán al abrir el modal.');
        return;
    }

    // Buscar todos los encabezados de sección dentro del modal
    const headers = modalContent.querySelectorAll('.section-header');

    if (headers.length === 0) {
        console.log('No se encontraron encabezados de sección. Verificando elementos alternativos.');
        // Buscar elementos alternativos que podrían servir como encabezados de acordeón
        const altHeaders = modalContent.querySelectorAll('.card-header, h5.mb-0, .accordion-header');

        if (altHeaders.length > 0) {
            console.log(`Se encontraron ${altHeaders.length} encabezados alternativos.`);
            setupAccordionFor(altHeaders);
        }
    } else {
        console.log(`Se encontraron ${headers.length} encabezados de sección.`);
        setupAccordionFor(headers);
    }
}

/**
 * Configura acordeones para los elementos proporcionados
 * @param {NodeList} headers - Los elementos de encabezado para configurar como acordeones
 */
function setupAccordionFor(headers) {
    headers.forEach(function (header, index) {
        // Asegurar que el header sea clickeable
        header.style.cursor = 'pointer';

        // Buscar un ícono existente o crear uno nuevo
        let collapseIcon = header.querySelector('.collapse-icon');
        if (!collapseIcon) {
            collapseIcon = document.createElement('i');
            collapseIcon.className = 'fas fa-chevron-down collapse-icon ms-2';
            collapseIcon.style.transition = 'transform 0.3s';
            header.appendChild(collapseIcon);
        }

        // Buscar el cuerpo del acordeón (el siguiente elemento después del encabezado)
        const cardBody = header.nextElementSibling;

        if (cardBody) {
            // Generar un ID único para el contenedor del acordeón si no tiene uno
            if (!cardBody.id) {
                cardBody.id = 'accordion-body-' + index;
            }

            // Si no es el primer panel, colapsar inicialmente
            if (index > 0) {
                cardBody.style.display = 'none';
                collapseIcon.style.transform = 'rotate(-90deg)';
            }

            // Añadir evento de clic para mostrar/ocultar el contenido
            header.addEventListener('click', function (event) {
                // Evitar que el clic se propague a otros elementos
                event.preventDefault();
                event.stopPropagation();

                // Toggle del cuerpo del acordeón
                if (cardBody.style.display === 'none') {
                    // Animación de despliegue
                    cardBody.style.display = 'block';
                    collapseIcon.style.transform = 'rotate(0deg)';
                } else {
                    // Animación de colapso
                    cardBody.style.display = 'none';
                    collapseIcon.style.transform = 'rotate(-90deg)';
                }
            });
        }
    });
}

/**
 * Muestra un modal dinámico con el contenido de un formulario y configura los acordeones
 * @param {string} formKey - La clave del formulario a mostrar
 * @param {string} title - El título del modal
 */
function showModal(formKey, title) {
    // Lógica existente para mostrar el modal...

    // Una vez cargado el modal, inicializar los acordeones
    fetch(`/Wizard/GetFormContent?formKey=${formKey}`)
        .then(response => response.text())
        .then(html => {
            const modalBody = document.querySelector('#dynamicModal .modal-body');
            if (modalBody) {
                modalBody.innerHTML = html;

                // Actualizar el título del modal
                document.querySelector('#dynamicModal .modal-title').textContent = title;

                // Mostrar el modal
                const modal = new bootstrap.Modal(document.getElementById('dynamicModal'));
                modal.show();

                // Inicializar los acordeones dentro del modal recién cargado
                setTimeout(setupEmployeeAccordions, 300); // Pequeño retraso para asegurar que el DOM esté listo
            }
        })
        .catch(error => {
            console.error('Error al cargar el contenido del formulario:', error);
            showToast('Error', 'No se pudo cargar el formulario', 'error');
        });
}

// Observador para detectar cuando se agrega contenido al DOM
const observer = new MutationObserver(function (mutations) {
    mutations.forEach(function (mutation) {
        if (mutation.type === 'childList' && mutation.addedNodes.length > 0) {
            // Verificar si se agregó un modal o contenido relevante
            const modalContent = document.querySelector('.modal-body');
            if (modalContent) {
                setupEmployeeAccordions();
            }
        }
    });
});

// Iniciar la observación del documento cuando esté listo
document.addEventListener('DOMContentLoaded', function () {
    observer.observe(document.body, { childList: true, subtree: true });

    // También intentar inicializar los acordeones ahora
    setupEmployeeAccordions();
});