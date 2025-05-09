// wizard.js - Funcionalidad para el asistente de creación de compañía

let currentStep = 0;
const totalSteps = 5;

// Al cargar la página, asegúrate de que solo el primer paso sea visible
document.addEventListener('DOMContentLoaded', function () {
    updateWizardVisibility();
});

// Agregar event listeners a los botones de navegación
function initWizardNavigation() {
    document.getElementById('nextStep').addEventListener('click', function () {
        if (currentStep < totalSteps - 1) {
            currentStep++;
            updateWizard();
        }
    });

    document.getElementById('prevStep').addEventListener('click', function () {
        if (currentStep > 0) {
            currentStep--;
            updateWizard();
        }
    });
}

function updateWizard() {
    // Ya no deshabilitamos el botón de anterior
    // document.getElementById('prevStep').disabled = (currentStep === 0);

    if (currentStep === totalSteps - 1) {
        document.getElementById('nextStep').innerHTML = 'Finalizar<i class="fas fa-check ms-2"></i>';
    } else {
        document.getElementById('nextStep').innerHTML = 'Siguiente<i class="fas fa-arrow-right ms-2"></i>';
    }

    // Actualizar indicadores de paso
    document.querySelectorAll('.step').forEach((step, index) => {
        if (index === currentStep) {
            step.classList.add('active');
        } else {
            step.classList.remove('active');
        }
    });

    // Actualizar visibilidad de los pasos
    updateWizardVisibility();

    // Inicializar cualquier funcionalidad específica del paso
    initCurrentStepFunctionality();
}

function updateWizardVisibility() {
    // Ocultar todos los pasos
    document.querySelectorAll('.wizard-step').forEach(step => {
        step.classList.remove('active');
        step.style.display = 'none';
    });

    // Mostrar solo el paso actual
    const currentStepElement = document.getElementById(`step-${currentStep}`);
    if (currentStepElement) {
        currentStepElement.classList.add('active');
        currentStepElement.style.display = 'block';
    }
}

function initCurrentStepFunctionality() {
    console.log(`Inicializando funcionalidad para paso ${currentStep}`);

    // Inicializar funcionalidades específicas según el paso actual
    switch (currentStep) {
        case 1: // _GeneralData
            setTimeout(initGeneralDataStep, 100); // Usar setTimeout para asegurar que el DOM esté listo
            break;
        case 2: // _Employees
            // Inicializar funcionalidad específica para empleados
            break;
        case 3: // _Banks
            // Inicializar funcionalidad específica para bancos
            break;
        case 4: // _Confirmation
            // Inicializar funcionalidad específica para confirmación
            break;
    }
}

function initGeneralDataStep() {
    console.log("Inicializando funcionalidad para Datos Generales");

    // Inicializar el toggle switch para construcción
    const toggleSwitch = document.getElementById("toggleSwitch");
    const constructionButtons = document.querySelectorAll(".construction-button");

    if (toggleSwitch && constructionButtons.length > 0) {
        console.log("Toggle switch y botones encontrados");

        // Estado inicial - por defecto los botones están deshabilitados
        constructionButtons.forEach(button => {
            button.disabled = !toggleSwitch.checked;
            console.log("Botón establecido como: " + (button.disabled ? "deshabilitado" : "habilitado"));
        });

        // Evento para el interruptor - eliminar event listeners anteriores para evitar duplicidad
        toggleSwitch.removeEventListener("change", handleToggleChange);
        toggleSwitch.addEventListener("change", handleToggleChange);

        console.log("Event listener agregado al toggle switch");
    } else {
        console.warn("No se encontró el toggle switch o los botones de construcción");
    }
}

// Función separada para manejar el cambio del toggle - permite eliminar el listener fácilmente
function handleToggleChange() {
    console.log("Toggle cambiado a: " + (this.checked ? "activado" : "desactivado"));

    const constructionButtons = document.querySelectorAll(".construction-button");
    constructionButtons.forEach(button => {
        // Cambiar disabled según el estado del toggle
        button.disabled = !this.checked;

        // Actualizar clases para cambiar la apariencia
        if (this.checked) {
            button.classList.add('btn-warning');
            button.classList.remove('btn-outline-warning');
        } else {
            button.classList.remove('btn-warning');
            button.classList.add('btn-outline-warning');
        }

        console.log("Botón actualizado a: " + (button.disabled ? "deshabilitado" : "habilitado"));
    });
}

// Inicializar la navegación al cargar la página
document.addEventListener('DOMContentLoaded', initWizardNavigation);