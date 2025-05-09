/**
 * toggleSwitcher.js
 * Script global para transformar checkboxes en toggle switches con espacio para etiquetas.
 */
(function () {
    'use strict';

    /**
     * Transforma checkbox normales en toggle switches
     */
    function initToggleSwitches() {
        // Seleccionar todos los checkboxes que no tengan ya la clase form-switch
        const checkboxes = document.querySelectorAll('input[type="checkbox"]:not(.no-toggle):not(.form-check-input.company-toggle-switch)');

        checkboxes.forEach(checkbox => {
            // Verificar si ya está dentro de un form-switch
            if (!checkbox.closest('.form-switch')) {
                const parent = checkbox.parentElement;
                
                // Verificar si ya tiene o está dentro de form-check
                let formCheckContainer;
                if (parent.classList.contains('form-check')) {
                    formCheckContainer = parent;
                    formCheckContainer.classList.add('form-switch');
                } else {
                    // Crear un contenedor si no existe
                    formCheckContainer = document.createElement('div');
                    formCheckContainer.className = 'form-check form-switch';
                    
                    // Buscar la etiqueta asociada al checkbox
                    let label = document.querySelector(`label[for="${checkbox.id}"]`);
                    
                    // Si no hay etiqueta con for, buscar una etiqueta hermana
                    if (!label) {
                        const siblings = Array.from(parent.childNodes);
                        for (const sibling of siblings) {
                            if (sibling.nodeName === 'LABEL') {
                                label = sibling;
                                break;
                            }
                        }
                    }
                    
                    // Insertar el contenedor nuevo
                    parent.insertBefore(formCheckContainer, checkbox);
                    
                    // Mover el checkbox al contenedor
                    formCheckContainer.appendChild(checkbox);
                    
                    // Mover la etiqueta si existe
                    if (label) {
                        formCheckContainer.appendChild(label);
                        label.classList.add('form-check-label');
                        label.style.marginLeft = '0.5rem';
                    }
                }
                
                // Añadir la clase form-check-input si no la tiene
                checkbox.classList.add('form-check-input');
                
                // Estilizar el toggle con tamaño más adecuado y distancia para la etiqueta
                checkbox.style.cursor = 'pointer';
                
                // Opcionalmente, añadir un poco de margen para la separación de elementos adyacentes
                formCheckContainer.style.marginBottom = '0.5rem';
            }
        });
    }

    /**
     * Observa cambios en el DOM para aplicar estilos a checkboxes dinámicos
     */
    function setupMutationObserver() {
        const observer = new MutationObserver(function(mutations) {
            mutations.forEach(function(mutation) {
                if (mutation.type === 'childList' && mutation.addedNodes.length > 0) {
                    // Verificar si se agregaron checkboxes
                    mutation.addedNodes.forEach(node => {
                        if (node.nodeType === 1) { // Es un elemento
                            // Buscar checkboxes dentro del nodo añadido
                            const newCheckboxes = node.querySelectorAll('input[type="checkbox"]:not(.no-toggle):not(.form-check-input.company-toggle-switch)');
                            if (newCheckboxes.length > 0 || node.nodeName === 'INPUT' && node.type === 'checkbox') {
                                // Inicializar los nuevos checkboxes
                                setTimeout(initToggleSwitches, 10);
                            }
                        }
                    });
                }
            });
        });

        // Configurar el observador para monitorear todo el documento
        observer.observe(document.body, {
            childList: true,
            subtree: true
        });
    }

    // Inicializar cuando el DOM esté completamente cargado
    document.addEventListener('DOMContentLoaded', function() {
        initToggleSwitches();
        setupMutationObserver();
    });

    // Exponer funciones para uso manual si es necesario
    window.toggleSwitcher = {
        init: initToggleSwitches
    };
})();