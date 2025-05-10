/**
 * PayWeb - Módulo de Empleados
 * Script compartido para todos los formularios relacionados con empleados
 */

// Función para inicializar los formularios cuando el DOM está listo
document.addEventListener('DOMContentLoaded', function () {
    initializeEmployeeForms();
    setupEmployeeAccordions();
});

/**
 * Inicializa todos los formularios de empleados
 */
function initializeEmployeeForms() {
    // Inicializar el formulario de datos de empleado
    initEmployeeDataForm();

    // Inicializar el formulario de notas de empleado
    initEmployeeNotesForm();

    // Inicializar el formulario de métodos de pago
    initPaymentMethodsForm();

    // Inicializar el formulario de configuración de ingresos
    initIncomeConfigForm();

    // Inicializar el formulario de ingresos predeterminados
    initDefaultIncomeForm();

    // Inicializar el formulario de datos generales
    initGeneralEmployeeDataForm();
}

/**
 * Configura los acordeones para las secciones de empleados
 */
function setupEmployeeAccordions() {
    const headers = document.querySelectorAll('.employee-section-card .card-header');

    headers.forEach(function (header, index) {
        const existingIcon = header.querySelector('i');

        if (existingIcon) {
            // Crear contenedor para el título
            const titleContainer = document.createElement('div');
            titleContainer.className = 'd-flex align-items-center';

            // Mover el ícono existente y el título al contenedor
            const headerTitle = header.querySelector('h6');

            // Clonar los elementos originales
            const iconClone = existingIcon.cloneNode(true);
            let titleClone = headerTitle;

            if (headerTitle) {
                titleClone = headerTitle.cloneNode(true);
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

                if (cardBody) {
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
            }
        }
    });
}

/**
 * Inicializa el formulario de datos de empleado
 */
function initEmployeeDataForm() {
    const form = document.getElementById('employeeDataForm');
    if (!form) return;

    // Configurar el botón de guardar del modal compartido
    const saveButton = document.getElementById('sharedModalSaveButton');
    if (saveButton) {
        saveButton.addEventListener('click', function () {
            submitFormWithFetch(form, '/Form/SaveEmployeeData', 'Los datos del empleado se han guardado correctamente');
        });
    }
}

/**
 * Inicializa el formulario de notas de empleado
 */
function initEmployeeNotesForm() {
    const form = document.getElementById('employeeNotesForm');
    if (!form) return;

    // Configurar el botón de guardar del modal compartido
    const saveButton = document.getElementById('sharedModalSaveButton');
    if (saveButton) {
        saveButton.addEventListener('click', function () {
            submitFormWithFetch(form, '/Employees/SaveEmployeeNotes', 'Las observaciones del empleado se han guardado correctamente');
        });
    }
}

/**
 * Inicializa el formulario de métodos de pago
 */
function initPaymentMethodsForm() {
    const form = document.getElementById('paymentMethodsForm');
    if (!form) return;

    // Configurar el botón de guardar del modal compartido
    const saveButton = document.getElementById('sharedModalSaveButton');
    if (saveButton) {
        saveButton.addEventListener('click', function () {
            submitFormWithFetch(form, '/Banks/SavePaymentMethods', 'La información de pago se ha guardado correctamente');
        });
    }
}

/**
 * Inicializa el formulario de configuración de ingresos
 */
function initIncomeConfigForm() {
    const form = document.getElementById('incomeConfigForm');
    if (!form) return;

    // Configurar el botón de guardar del modal compartido
    const saveButton = document.getElementById('sharedModalSaveButton');
    if (saveButton) {
        saveButton.addEventListener('click', function () {
            submitFormWithFetch(form, '/Employees/SaveIncomeConfig', 'La configuración de ingresos se ha guardado correctamente');
        });
    }
}

/**
 * Inicializa el formulario de ingresos predeterminados
 */
function initDefaultIncomeForm() {
    const form = document.getElementById('defaultIncomeForm');
    if (!form) return;

    // Configurar el botón de guardar del modal compartido
    const saveButton = document.getElementById('sharedModalSaveButton');
    if (saveButton) {
        saveButton.addEventListener('click', function () {
            submitFormWithFetch(form, '/Employees/SaveDefaultIncome', 'Los ingresos predeterminados se han guardado correctamente');
        });
    }

    // Modal de frecuencia
    let frequencyModal = null;
    const frequencyModalElement = document.getElementById('frequencyModal');
    if (frequencyModalElement) {
        frequencyModal = new bootstrap.Modal(frequencyModalElement);
        let currentIncomeBtn = null;

        // Configurar los botones de "Cambiar" para abrir el modal de frecuencia
        document.querySelectorAll('.btn-outline-secondary').forEach(function (btn, index) {
            btn.addEventListener('click', function () {
                document.getElementById('currentIncomeIndex').value = index;
                currentIncomeBtn = btn;
                frequencyModal.show();
            });
        });

        // Configurar el botón "Aplicar" del modal de frecuencia
        const applyFrequencyBtn = document.getElementById('applyFrequencyBtn');
        if (applyFrequencyBtn) {
            applyFrequencyBtn.addEventListener('click', function () {
                const frequencyType = document.getElementById('frequencyType').value;
                const frequencyText = document.getElementById('frequencyType').options[
                    document.getElementById('frequencyType').selectedIndex
                ].text;

                const index = document.getElementById('currentIncomeIndex').value;

                // Actualizar el texto del botón
                if (currentIncomeBtn) {
                    currentIncomeBtn.textContent = frequencyText;

                    // Agregar un campo oculto para enviar la frecuencia
                    const hiddenInput = document.createElement('input');
                    hiddenInput.type = 'hidden';
                    hiddenInput.name = `DefaultIncomes[${index}].FrequencyType`;
                    hiddenInput.value = frequencyType;

                    // Remover cualquier campo oculto previo para esa frecuencia
                    const prevHidden = form.querySelector(`input[name="DefaultIncomes[${index}].FrequencyType"]`);
                    if (prevHidden) {
                        prevHidden.remove();
                    }

                    form.appendChild(hiddenInput);
                }

                frequencyModal.hide();
            });
        }
    }
}

/**
 * Inicializa el formulario de datos generales de empleado
 */
function initGeneralEmployeeDataForm() {
    const form = document.getElementById('generalEmployeeDataForm');
    if (!form) return;

    // Configurar el botón de guardar del modal compartido
    const saveButton = document.getElementById('sharedModalSaveButton');
    if (saveButton) {
        saveButton.addEventListener('click', function () {
            submitFormWithFetch(form, '/Employees/SaveGeneralEmployeeData', 'Los datos generales se han guardado correctamente');
        });
    }

    // Configurar la previsualización de foto
    const photoUpload = document.getElementById('photoUpload');
    const photoPreview = document.getElementById('photoPreview');
    const photoPath = document.getElementById('photoPath');

    if (photoUpload) {
        photoUpload.addEventListener('change', function () {
            const file = this.files[0];
            if (file) {
                const reader = new FileReader();
                reader.onload = function (e) {
                    photoPreview.innerHTML = `<img src="${e.target.result}" class="img-fluid" alt="Foto de empleado">`;
                    photoPath.value = file.name;
                };
                reader.readAsDataURL(file);
            }
        });
    }

    // Botón para tomar foto (simulado)
    const takePhotoButton = document.getElementById('takePhotoButton');
    if (takePhotoButton) {
        takePhotoButton.addEventListener('click', function () {
            alert('Funcionalidad de cámara no implementada. Por favor, seleccione un archivo manualmente.');
        });
    }

    // Botón para examinar
    const browseButton = document.getElementById('browseButton');
    if (browseButton && photoUpload) {
        browseButton.addEventListener('click', function () {
            photoUpload.click();
        });
    }
}

/**
 * Envía un formulario mediante fetch
 * @param {HTMLFormElement} form - El formulario a enviar
 * @param {string} url - La URL a la que se enviará el formulario
 * @param {string} successMessage - El mensaje de éxito
 */
function submitFormWithFetch(form, url, successMessage) {
    if (!form) return;

    const formData = new FormData(form);

    fetch(url, {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                // Cerrar el modal manualmente usando Bootstrap
                const modal = bootstrap.Modal.getInstance(document.getElementById('dynamicModal'));
                if (modal) modal.hide();

                // Mostrar mensaje de éxito
                showToast('Éxito', successMessage, 'success');
            } else {
                showToast('Error', 'Hubo un problema al guardar la información', 'error');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            showToast('Error', 'Hubo un problema al procesar la solicitud', 'error');
        });
}

/**
 * Muestra un toast (notificación)
 * @param {string} title - El título del toast
 * @param {string} message - El mensaje del toast
 * @param {string} type - El tipo de toast (success, error, info, warning)
 */
function showToast(title, message, type) {
    // Si existe un sistema de toast en la aplicación, usarlo aquí
    console.log(`${title}: ${message} (${type})`);

    // Si se ha implementado un componente de toast personalizado
    const toastContainer = document.getElementById('toastContainer');
    if (toastContainer && typeof createToast === 'function') {
        createToast(title, message, type);
    }
}