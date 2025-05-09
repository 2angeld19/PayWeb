// modalHelper.js - versión mejorada
window.modalHelper = (function () {
    // Variable para almacenar la instancia del modal
    let modalInstance = null;

    // Inicializar el modal compartido
    function initSharedModal() {
        const modalElement = document.getElementById('sharedModal');
        if (modalElement && !modalInstance) {
            try {
                modalInstance = new bootstrap.Modal(modalElement);
                console.log("Modal compartido inicializado correctamente");
            } catch (error) {
                console.error("Error al inicializar el modal compartido:", error);
            }
        }
    }

    // Función para mostrar el modal compartido
    function showSharedModal(title, content) {
        // Inicializar si aún no se ha hecho
        if (!modalInstance) {
            initSharedModal();
        }

        if (modalInstance) {
            // Actualizar título
            const titleElement = document.getElementById('sharedModalLabel');
            if (titleElement) {
                titleElement.textContent = title || 'Modal';
            }

            // Actualizar contenido
            const contentElement = document.getElementById('sharedModalContent');
            if (contentElement) {
                contentElement.innerHTML = content || '';
            }

            // Mostrar el modal
            try {
                modalInstance.show();
                console.log("Modal mostrado correctamente");
            } catch (error) {
                console.error("Error al mostrar el modal:", error);
            }
        } else {
            console.error("No se pudo inicializar el modal compartido");
        }
    }

    // Función para mostrar formularios en modal
    function showFormModal(formName, title) {
        // Verificar si es un formulario de construcción
        const isConstructionForm = ['Projects', 'Phases', 'Division'].includes(formName);

        // Aplicar la clase adecuada
        const modalElement = document.getElementById('sharedModal');
        if (modalElement) {
            if (isConstructionForm) {
                modalElement.classList.add('construction-modal');
            } else {
                modalElement.classList.remove('construction-modal');
            }
        }

        // Mostrar un indicador de carga
        showSharedModal(title, '<div class="text-center p-4"><i class="fas fa-spinner fa-spin fa-3x"></i><p class="mt-3">Cargando...</p></div>');

        // Cargar el contenido del formulario vía AJAX
        fetch(`/Form/${formName}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Error al cargar el formulario: ${response.status}`);
                }
                return response.text();
            })
            .then(html => {
                // Actualizar contenido
                const contentElement = document.getElementById('sharedModalContent');
                if (contentElement) {
                    contentElement.innerHTML = html;
                }
            })
            .catch(error => {
                console.error('Error al cargar el formulario:', error);
                const contentElement = document.getElementById('sharedModalContent');
                if (contentElement) {
                    contentElement.innerHTML = `
                        <div class="alert alert-danger">
                            <i class="fas fa-exclamation-circle me-2"></i>
                            Error al cargar el formulario: ${error.message}
                        </div>
                    `;
                }
            });
    }

    // Función para habilitar los botones de construcción
    function enableConstructionButtons() {
        const toggleSwitch = document.getElementById('toggleSwitch');
        if (toggleSwitch) {
            toggleSwitch.addEventListener('change', function () {
                document.querySelectorAll('.construction-button').forEach(button => {
                    if (this.checked) {
                        button.classList.add('btn-warning');
                        button.classList.remove('btn-outline-warning');
                    } else {
                        button.classList.remove('btn-warning');
                        button.classList.add('btn-outline-warning');
                    }
                });
            });
        }
    }

    // Función para enviar formularios
    function submitForm(formId, url) {
        const form = document.getElementById(formId);
        if (!form) {
            console.error('Formulario no encontrado:', formId);
            return;
        }

        const formData = new FormData(form);

        // Mostrar indicador de carga
        const submitButton = form.querySelector('[type="submit"]');
        if (submitButton) {
            submitButton.disabled = true;
            submitButton.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i>Procesando...';
        }

        fetch(url, {
            method: 'POST',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    if (modalInstance) {
                        modalInstance.hide();
                    }

                    // Mostrar notificación de éxito
                    showNotification('Éxito', 'Datos guardados correctamente', 'success');
                } else {
                    showNotification('Error', data.message || 'Error al guardar los datos', 'error');
                }
            })
            .catch(error => {
                console.error('Error:', error);
                showNotification('Error', 'Error al procesar la solicitud', 'error');
            })
            .finally(() => {
                // Restaurar botón
                if (submitButton) {
                    submitButton.disabled = false;
                    submitButton.innerHTML = 'Guardar';
                }
            });
    }

    // Función para mostrar notificaciones
    function showNotification(title, message, type) {
        // Si tienes una librería de notificaciones, úsala aquí
        // De lo contrario, un simple alert
        alert(`${title}: ${message}`);
    }

    // Inicializar cuando el DOM esté listo
    document.addEventListener('DOMContentLoaded', function () {
        initSharedModal();
        enableConstructionButtons();
    });

    // Exponer funciones públicas
    return {
        showModal: showSharedModal,
        showFormModal: showFormModal,
        submitForm: submitForm,
        enableConstructionButtons: enableConstructionButtons
    };
})();

// Para compatibilidad con el código existente
function showModal(formName, title) {
    window.modalHelper.showFormModal(formName, title);
}

function submitForm(formId, url) {
    window.modalHelper.submitForm(formId, url);
}