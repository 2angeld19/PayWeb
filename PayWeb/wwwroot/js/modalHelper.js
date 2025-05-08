window.modalHelper = {
    showModal: function (modalId) {
        console.log("Llamando a showModal para elemento: " + modalId);
        var modalElement = document.getElementById(modalId);
        if (modalElement) {
            console.log("Elemento modal encontrado");
            try {
                var modal = new bootstrap.Modal(modalElement);
                modal.show();
                console.log("Modal mostrado correctamente");
            } catch (error) {
                console.error("Error al crear o mostrar el modal: " + error);
            }
        } else {
            console.error('Elemento modal no encontrado: ' + modalId);
        }
    },

    // Función para habilitar los botones del módulo de construcción
    enableConstructionButtons: function () {
        const toggleSwitch = document.getElementById('toggleSwitch');

        if (toggleSwitch) {
            toggleSwitch.addEventListener('change', function () {
                // Habilitar todos los botones de construcción
                document.querySelectorAll('.construction-button').forEach(button => {
                    button.disabled = !this.checked;
                });
            });
        }
    }
};

// Función global para mostrar modal con formulario
function showModal(formName, title) {
    // Actualizar el título del modal
    document.getElementById('dynamicModalLabel').textContent = title;

    // Obtener el elemento modal
    const modalElement = document.getElementById('dynamicModal');

    // Verificar si es un formulario de construcción
    const isConstructionForm = ['Projects', 'Phases', 'Division'].includes(formName);

    // Aplicar la clase adecuada
    if (isConstructionForm) {
        modalElement.classList.add('construction-modal');
    } else {
        modalElement.classList.remove('construction-modal');
    }

    // Cargar el contenido del formulario vía AJAX
    fetch(`/Form/${formName}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.text();
        })
        .then(html => {
            document.getElementById('modalContent').innerHTML = html;
            // Eliminar la llamada a transformInputFields();
            var modal = new bootstrap.Modal(modalElement);
            modal.show();
        })
        .catch(error => {
            console.error('Error al cargar el formulario:', error);
            document.getElementById('modalContent').innerHTML = '<div class="alert alert-danger">Error al cargar el formulario</div>';
            var modal = new bootstrap.Modal(modalElement);
            modal.show();
        });
}

// Eliminar toda la función transformInputFields()

// Función para enviar formularios
function submitForm(formId, url) {
    const form = document.getElementById(formId);
    const formData = new FormData(form);

    fetch(url, {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                bootstrap.Modal.getInstance(document.getElementById('dynamicModal')).hide();
                alert('Datos guardados con éxito');
            } else {
                alert('Error al guardar los datos: ' + data.message);
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Error al procesar la solicitud');
        });
}

// Inicializar las funcionalidades cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', function () {
    // Habilitar los botones de construcción
    modalHelper.enableConstructionButtons();
});