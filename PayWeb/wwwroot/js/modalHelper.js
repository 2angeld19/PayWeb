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

            // Eliminar restricción de max-width
            const modalDialog = document.getElementById('sharedModal').querySelector('.modal-dialog');
            if (modalDialog) {
                modalDialog.style.maxWidth = 'none';
            }

            // Mostrar el modal
            try {
                modalInstance.show();
                console.log("Modal compartido mostrado correctamente");

                // Reafirmar eliminación de max-width después de mostrar el modal
                if (modalDialog) {
                    setTimeout(() => {
                        modalDialog.style.maxWidth = 'none';
                    }, 0);
                }
            } catch (error) {
                console.error("Error al mostrar el modal compartido:", error);
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
    // Determinar qué controlador usar según el nombre del formulario
    let controller;

    if (['Branches', 'Departments', 'Positions', 'Schedules', 'CostCenters', 'Projects', 'Phases', 'Division'].includes(formName)) {
        controller = 'GeneralData';
    } else if (['Banks', 'PaymentMethods', 'PayFrequency', 'FileFormats'].includes(formName)) {
        controller = 'Banks';
    } else if (['CreateCompany'].includes(formName)) {
        controller = 'Company';
    } else {
        controller = 'Employees';
    }

    const modalElement = document.getElementById('dynamicModal');
    const modalDialog = modalElement.querySelector('.modal-dialog');

    // Reiniciar estilos personalizados
    modalDialog.style.maxWidth = 'none'; // Eliminar max-width que limita el ancho personalizado
    modalDialog.style.width = '';
    modalDialog.className = 'modal-dialog'; // Eliminar clases anteriores

    // Configurar anchos personalizados según el formulario
    if (formName === 'CostCenters') {
        modalDialog.style.width = '65em'; // ~1040px
        console.log('Aplicando ancho personalizado para CostCenters: 65em');
    } else if (formName === 'Schedules') {
        modalDialog.style.width = '82em'; // ~1200px
        console.log('Aplicando ancho personalizado para Schedules: 75em');
    } else if (['EmployeeData', 'EmployeeNotes', 'PaymentMethods'].includes(formName)) {
        modalDialog.style.width = '60em'; // ~960px
        console.log(`Aplicando ancho personalizado para ${formName}: 60em`);
    } else if (['GeneralEmployeeData', 'IncomeConfig', 'DefaultIncome'].includes(formName)) {
        modalDialog.style.width = '70em'; // ~1120px
        console.log(`Aplicando ancho personalizado para ${formName}: 70em`);
    } else if (['Branches', 'Departments', 'Positions'].includes(formName)) {
        modalDialog.style.width = '50em'; // ~800px
        console.log(`Aplicando ancho personalizado para ${formName}: 50em`);
    } else if (['Projects', 'Phases', 'Division'].includes(formName)) {
        modalDialog.style.width = '55em'; // ~880px
        console.log(`Aplicando ancho personalizado para ${formName}: 55em`);
    } else {
        // Formularios más pequeños con ancho predeterminado
        modalDialog.style.width = '40em'; // ~640px
        console.log(`Aplicando ancho predeterminado para ${formName}: 40em`);
    }

    // Asegurarse que max-width sea reemplazado definitivamente por nuestro ancho personalizado
    setTimeout(() => {
        modalDialog.style.maxWidth = 'none';
    }, 0);

    document.getElementById('dynamicModalLabel').textContent = title;
    const modal = new bootstrap.Modal(modalElement);

    // Mostrar indicador de carga
    document.getElementById('modalContent').innerHTML = `
        <div class="text-center p-4">
            <i class="fas fa-spinner fa-spin fa-3x"></i>
            <p class="mt-3">Cargando...</p>
        </div>
    `;

    fetch(`/${controller}/${formName}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`Error HTTP: ${response.status}`);
            }
            return response.text();
        })
        .then(html => {
            document.getElementById('modalContent').innerHTML = html;

            // Añadimos un pequeño retraso para asegurar que el contenido se haya renderizado
            // antes de mostrar el modal, evitando posibles problemas de layout
            setTimeout(() => {
                modal.show();

                // Volver a aplicar max-width: none después de que se muestre el modal
                modalDialog.style.maxWidth = 'none';

                // Inicializar contenido específico después de mostrar el modal
                initModalContent(formName);
            }, 50);
        })
        .catch(error => {
            console.error('Error:', error);
            document.getElementById('modalContent').innerHTML = `
                <div class="alert alert-danger">
                    <i class="fas fa-exclamation-circle me-2"></i>
                    Error al cargar el formulario: ${error.message}
                </div>
            `;
            modal.show();
        });
}

// Función para inicializar scripts específicos después de cargar el contenido del modal
function initModalContent(formName) {
    // Para formularios que tienen su propio script de inicialización
    if (formName === 'CostCenters' && typeof initCostCenterForm === 'function') {
        initCostCenterForm();
    }

    if (formName === 'Schedules' && typeof initScheduleForm === 'function') {
        initScheduleForm();
    }

    // Para formularios de empleados que puedan tener inicialización específica
    const employeeForms = ['EmployeeData', 'EmployeeNotes', 'PaymentMethods',
        'IncomeConfig', 'DefaultIncome', 'GeneralEmployeeData'];

    if (employeeForms.includes(formName)) {
        // Si la función init{FormName}Form existe, llámala
        const initFunctionName = 'init' + formName.charAt(0).toUpperCase() + formName.slice(1) + 'Form';
        if (typeof window[initFunctionName] === 'function') {
            window[initFunctionName]();
        }
    }

    // Ejecutar cualquier inicialización adicional específica por tipo de formulario
    if (['Branches', 'Departments', 'Positions', 'CostCenters'].includes(formName)) {
        // Inicializar selectores o componentes especiales que puedan necesitarlo
        initializeSelects();
    }
}

// Función auxiliar para inicializar selectores después de cargar contenido
function initializeSelects() {
    // Inicializar selectores Bootstrap si existen en el modal
    const selects = document.querySelectorAll('#modalContent select.form-select');

    if (selects.length > 0) {
        // Si estás usando algún plugin para mejorar los selectores, inicialízalo aquí
        console.log(`Inicializando ${selects.length} selectores en el modal`);
    }
}

function submitForm(formId, url) {
    window.modalHelper.submitForm(formId, url);
}